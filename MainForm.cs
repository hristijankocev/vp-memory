using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using static YuGiOh.MenuScreenForm;

namespace YuGiOh
{
    public partial class MainForm : Form
    {
        private readonly HashSet<int> _cards;
        private readonly List<string> _pictureBoxIds;
        private readonly int _numCards;
        private CardInfoForm _cardInfoForm;
        private Point _formPreviousLocation;
        private EndForm _endForm;

        private Card _firstCard;
        private Card _secondCard;

        public MainForm(int numCards)
        {
            _firstCard = new Card();
            _secondCard = new Card();

            _numCards = numCards;

            // Set will contain id's of pictures, will use it to check if we matched all cards
            _cards = new HashSet<int>();

            _pictureBoxIds = new List<string>();

            MainFormRef = this;

            InitializeComponent();

            _formPreviousLocation = new Point(MainFormRef.Location.X, MainFormRef.Location.Y);

            CreatePictureBoxes();

            // Get the id's of all the picture box controls
            _pictureBoxIds.AddRange(from PictureBox pictureBox in panelCards.Controls select pictureBox.Name);

            // "Shuffle" cards
            _pictureBoxIds = _pictureBoxIds.OrderBy(pid => Guid.NewGuid()).ToList();

            // Initialize each picture box with the default yu-gi-oh! backside card picture
            InitPictureBoxImages();

            // Fill each picture box with a pic
            FillPictures();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitPictureBoxImages()
        {
            foreach (PictureBox pictureBox in panelCards.Controls)
            {
                pictureBox.Image = Properties.Resources.Back_AE;
            }
        }

        private static Card GetRandomCard()
        {
            WebRequest request = WebRequest.Create("https://db.ygoprodeck.com/api/v7/randomcard.php");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader streamReader = new StreamReader(dataStream ?? throw new InvalidOperationException());

            dynamic cardJson = JsonConvert.DeserializeObject(streamReader.ReadToEnd());

            response.Close();

            return cardJson == null ? null : (Card) JsonConvert.DeserializeObject<Card>(cardJson.ToString());
        }

        private void FillPictures()
        {
            panelCards.Height = ClientRectangle.Height - 50;
            panelCards.Width = ClientRectangle.Width - 50;

            while (_pictureBoxIds.Count != 0)
            {
                var card = GetRandomCard();

                // Ensure we get a valid card
                if (card == null)
                {
                    while (true)
                    {
                        card = GetRandomCard();
                        if (card == null) continue;
                        break;
                    }
                }

                // Add card id to the hashset
                _cards.Add(card.id);

                card.clicked = false;
                card.uniqueId = Guid.NewGuid().ToString();

                // Process a pair of picture boxes
                ProcessPictureBox(card);
                ProcessPictureBox(card);
            }
        }

        private void ProcessPictureBox(Card card)
        {
            // Get a random picture box from the panel and give it a card 
            var rnd = new Random();
            var pictureBox =
                (PictureBox) panelCards.Controls.Find(_pictureBoxIds.ElementAt(rnd.Next(0, _pictureBoxIds.Count)),
                    false)[0];

            _pictureBoxIds.Remove(pictureBox.Name);

            if (card.pictureBoxes == null)
            {
                card.pictureBoxes = new List<string>();
            }

            card.pictureBoxes.Add(pictureBox.Name);

            pictureBox.MouseClick += (sender, mouseEventArgs) =>
            {
                PictureClick(sender, mouseEventArgs, card, pictureBox);
            };
        }


        private void PictureClick(object sender, MouseEventArgs e, Card card, PictureBox pictureBox)
        {
            if (((e.Button & MouseButtons.Left) != 0) && _cards.Count != 0)
            {
                if (_firstCard.clicked && _secondCard.clicked)
                    return;

                // Open a new form display the card information
                CardInformation(card);

                pictureBox.LoadAsync(card.card_images[0].image_url);

                // First card is not clicked at the start or when we get a card match
                if (!_firstCard.clicked)
                {
                    pictureBox.Enabled = false;

                    _firstCard = card;
                    _firstCard.clicked = true;
                    return;
                }

                // With the previous check if statement, we are sure that this will be the second card
                _secondCard = card;
                _secondCard.clicked = true;

                if (_firstCard.id == _secondCard.id)
                {
                    // Remove card from the hashset
                    _cards.Remove(_firstCard.id);

                    if (_cards.Count == 0)
                    {
                        _endForm?.Close();
                        _endForm = new EndForm(MainFormRef, _cardInfoForm);
                        _endForm.Show();

                        // Enable all picture boxes so we can still preview them
                        foreach (PictureBox pb in panelCards.Controls)
                        {
                            pb.Enabled = true;
                        }

                        return;
                    }

                    // Disable both picture boxes associated with the image
                    foreach (var pb in _firstCard.pictureBoxes)
                    {
                        panelCards.Controls.Find(pb, true)[0].Enabled = false;
                    }

                    _firstCard = new Card();
                    _secondCard = new Card();
                    return;
                }

                timerCheckCards.Start();
            }
            // We finished the game, but you can still preview the cards info with right clicking them
            else if ((e.Button & MouseButtons.Right) != 0 && _cards.Count == 0)
            {
                CardInformation(card);
            }
        }

        private void timerCheckCards_Tick(object sender, EventArgs e)
        {
            timerCheckCards.Stop();

            foreach (var pb in _firstCard.pictureBoxes)
            {
                var pictureBox = (PictureBox) panelCards.Controls.Find(pb, false)[0];

                // If the pic has the back image already, it means the other pic box needs to be changed
                if (pictureBox.Image == Properties.Resources.Back_AE)
                    continue;

                // If we got to this point, two cards have been opened and they were not the same one
                // Gotta enable the card which we disabled previously to prevent clicking the same card
                pictureBox.Enabled = true;
                pictureBox.Image = Properties.Resources.Back_AE;
            }

            foreach (var pb in _secondCard.pictureBoxes)
            {
                var pictureBox = (PictureBox) panelCards.Controls.Find(pb, false)[0];

                // If the pic has the back image already, it means the other pic box needs to be changed
                if (pictureBox.Image == Properties.Resources.Back_AE)
                    continue;

                pictureBox.Image = Properties.Resources.Back_AE;
            }

            // Reset active cards
            _firstCard = new Card();
            _secondCard = new Card();
        }

        private void CreatePictureBoxes()
        {
            // Scale the form based on how many cards we have chosen to play with
            if (_numCards == 6)
                MainFormRef.Width += 140;
            else if (_numCards % 8 == 0 && _numCards != 24 || _numCards == 12)
                MainFormRef.Width += 280;
            else if (_numCards == 24)
                MainFormRef.Width += 580;
            else if (_numCards % 5 == 0)
                MainFormRef.Width += 440;
            else if (_numCards == 22)
                MainFormRef.Width += 1340;
            else if (_numCards == 14)
                MainFormRef.Width += 740;
            else if (_numCards == 18)
                MainFormRef.Width += 580;


            panelCards.Height = ClientRectangle.Height;
            panelCards.Width = ClientRectangle.Width;


            var pointXCounter = 0;
            const int pointXFactor = 150;
            var pointY = 0;
            const int pointYFactor = 180;
            for (var i = 0; i < _numCards; i++)
            {
                var pointX = pointXCounter * pointXFactor;


                // Check width boundary
                if (pointX > panelCards.Width - 100)
                {
                    pointY += pointYFactor;
                    pointXCounter = 0;
                    pointX = pointXCounter * pointXFactor;
                }

                // Check height boundary
                if (pointY > panelCards.Height - 100)
                {
                    panelCards.Height += pointYFactor;
                }

                var box = new PictureBox
                {
                    Name = $"pictureBox{i}",
                    Width = 120,
                    Height = 170,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(pointX, pointY)
                };
                panelCards.Controls.Add(box);

                pointXCounter++;
            }
        }

        private void CardInformation(Card card)
        {
            // If there's already a form showing a card info, close it
            _cardInfoForm?.Close();

            _cardInfoForm = new CardInfoForm(card);
            _cardInfoForm.Show();

            _cardInfoForm.StartPosition = FormStartPosition.Manual;
            _cardInfoForm.SetDesktopLocation(MainFormRef.Right - 10, MainFormRef.Location.Y);
        }


        private void MainForm_LocationChanged_1(object sender, EventArgs e)
        {
            // If the main form has been moved...
            if (_cardInfoForm == null)
                return;
            if (_formPreviousLocation != new Point(MainFormRef.Location.X, MainFormRef.Location.Y))
                _cardInfoForm.Location = new Point(
                    _cardInfoForm.Location.X + Location.X - _formPreviousLocation.X,
                    _cardInfoForm.Location.Y + Location.Y - _formPreviousLocation.Y
                );

            _formPreviousLocation = MainFormRef.Location;
        }
    }
}