using System;
using System.Windows.Forms;

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

            MainFormRef = new MainForm((int) numericUpDownNumCards.Value);
            MainFormRef.Show();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}