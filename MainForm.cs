using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using static Yu_Gi_Oh____Memory_game.MenuScreenForm;

namespace Yu_Gi_Oh____Memory_game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            MainFormRef = this;

            InitializeComponent();

            FillPictures();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private string GetRandomPicUrl()
        {
            WebRequest request = WebRequest.Create("https://db.ygoprodeck.com/api/v7/randomcard.php");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader streamReader = new StreamReader(dataStream);

            dynamic card = JsonConvert.DeserializeObject(streamReader.ReadToEnd());

            response.Close();

            return card?.card_images[0].image_url;
        }

        private void FillPictures()
        {
            panelCards.Height = ClientRectangle.Height - 50;
            panelCards.Width = ClientRectangle.Width - 50;

            foreach (PictureBox pictureBox in panelCards.Controls)
            {
                pictureBox.LoadAsync(GetRandomPicUrl());
            }
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