
namespace YuGiOh
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelCards = new System.Windows.Forms.Panel();
            this.timerCheckCards = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelCards
            // 
            this.panelCards.Location = new System.Drawing.Point(15, 25);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(293, 333);
            this.panelCards.TabIndex = 0;
            // 
            // timerCheckCards
            // 
            this.timerCheckCards.Interval = 500;
            this.timerCheckCards.Tick += new System.EventHandler(this.timerCheckCards_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(321, 383);
            this.Controls.Add(this.panelCards);
            this.Name = "MainForm";
            this.Text = "Yu-Gi-Oh!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCards;
        private System.Windows.Forms.Timer timerCheckCards;
    }
}