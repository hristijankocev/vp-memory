﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using static YuGiOh.MenuScreenForm;

namespace YuGiOh
{
    public partial class MainForm : Form
    {
        private readonly List<Card> _cards;
        private readonly List<string> _pictureBoxIds;
        private readonly int _numCards;
        private CardInfoForm _cardInfoForm;

        public MainForm(int numCards)
        {
            _numCards = numCards;

            // Initialize lists
            _cards = new List<Card>();
            _pictureBoxIds = new List<string>();

            MainFormRef = this;

            InitializeComponent();

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
                        if (card != null)
                            break;
                    }
                }

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
                    true)[0];

            _pictureBoxIds.Remove(pictureBox.Name);

            pictureBox.MouseClick += (sender, mouseEventArgs) =>
            {
                PictureClick(sender, mouseEventArgs, card, pictureBox);
            };
        }


        private void PictureClick(object sender, MouseEventArgs e, Card card, PictureBox pictureBox)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                pictureBox.LoadAsync(card.card_images[0].image_url);

                // Open a new form display the card information
                CardInformation(card);
            }

            else if ((e.Button & MouseButtons.Right) != 0)
            {
                MessageBox.Show($"{card.name}\n{card.card_prices[0].amazon_price}");
            }
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

            var placementPoint = new Point(MainFormRef.Size.Width, MainFormRef.Size.Height);

            _cardInfoForm = new CardInfoForm(card);
            _cardInfoForm.Show();

            _cardInfoForm.StartPosition = FormStartPosition.Manual;
            _cardInfoForm.SetDesktopLocation(MainFormRef.Right - 10, MainFormRef.Location.Y);
        }
    }
}