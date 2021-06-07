using System;
using System.Windows.Forms;

namespace YuGiOh
{
    public partial class EndForm : Form
    {
        private readonly EndForm _endForm;
        private MainForm _mainForm;
        private CardInfoForm _infoForm;

        public EndForm(MainForm mainForm, CardInfoForm infoForm)
        {
            _mainForm = mainForm;
            _infoForm = infoForm;

            InitializeComponent();

            _endForm = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _mainForm.Dispose();

            _mainForm = new MainForm((int) numericUpDownNumCards.Value);
            _mainForm.Show();

            _infoForm.Close();
            _endForm.Close();
        }
    }
}