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
        private List<Card> cards;

        public MainForm()
        {
            cards = new List<Card>();

            MainFormRef = this;

            InitializeComponent();

            FillPictures();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private Card GetRandomCard()
        {
            WebRequest request = WebRequest.Create("https://db.ygoprodeck.com/api/v7/randomcard.php");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader streamReader = new StreamReader(dataStream ?? throw new InvalidOperationException());

            dynamic cardJson = JsonConvert.DeserializeObject(streamReader.ReadToEnd());

            response.Close();

            Card card = JsonConvert.DeserializeObject<Card>(cardJson?.ToString());

            return card;
        }

        private void FillPictures()
        {
            panelCards.Height = ClientRectangle.Height - 50;
            panelCards.Width = ClientRectangle.Width - 50;

            foreach (PictureBox pictureBox in panelCards.Controls)
            {
                var card = GetRandomCard();

                cards.Add(card);

                pictureBox.LoadAsync(card.card_images[0].image_url);

                pictureBox.Click += (sender, EventArgs) => { picture_Click(sender, EventArgs, 5); };
            }
        }


        public void picture_Click(object sender, EventArgs e, int i)
        {
            MessageBox.Show($@"Test {i}");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}