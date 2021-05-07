using System;
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

        public MainForm()
        {
            // Initialize lists
            _cards = new List<Card>();
            _pictureBoxIds = new List<string>();

            MainFormRef = this;

            InitializeComponent();

            // Get the id's of all the picture box controls
            _pictureBoxIds.AddRange(from PictureBox pictureBox in panelCards.Controls select pictureBox.Name);

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
            var rnd = new Random();
            var pictureBox =
                (PictureBox) panelCards.Controls.Find(_pictureBoxIds.ElementAt(rnd.Next(0, _pictureBoxIds.Count)),
                    false)[0];

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
            }

            else if ((e.Button & MouseButtons.Right) != 0)
            {
                label1.Text = $@"Card clicked: {card.id}";

                MessageBox.Show($"{card.name}\n{card.card_prices[0].amazon_price}");
            }
        }
    }
}