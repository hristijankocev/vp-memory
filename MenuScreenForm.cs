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

            lblNumCards.Text = $@"Number of cards: {numericUpDownNumCards.Value}";
        }


        private void LoadGame(object sender, EventArgs e)
        {
            MenuFormRef.Hide();

            MainFormRef = new MainForm((int) numericUpDownNumCards.Value);

            MainFormRef.Show();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void numericUpDownNumCards_ValueChanged(object sender, EventArgs e)
        {
            lblNumCards.Text = $@"Number of cards: {numericUpDownNumCards.Value}";
        }
    }
}