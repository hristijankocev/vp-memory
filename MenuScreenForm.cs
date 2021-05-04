using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace YuGiOh
{
    public partial class MenuScreenForm : Form
    {
        public static MenuScreenForm MenuFormRef;
        public static MainForm MainFormRef;

        public MenuScreenForm()
        {
            MenuFormRef = this;

            InitializeComponent();
        }


        private void LoadGame(object sender, EventArgs e)
        {
            MenuFormRef.Hide();

            MainFormRef = new MainForm();

            MainFormRef.ShowDialog();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = @"{
                'set_code':'Blazing Vortex',
                'set_Name':'BLVO-EN001',
                'SetPrice':'Secret Rare',
                'SetRarity':'$9.05'
            }";

            CardSet cardSet = JsonConvert.DeserializeObject<CardSet>(json);

            CardSet newCardSet = new CardSet
                {set_code = "ASX2", set_name = "Name", set_price = "$12", set_rarity = "Very Rare"};

            string deserialized = JsonConvert.SerializeObject(newCardSet);

            MessageBox.Show(cardSet.set_name);

            MessageBox.Show(deserialized);
        }
    }
}