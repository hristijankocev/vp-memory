
namespace YuGiOh
{
    partial class MenuScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreenForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNumCards = new System.Windows.Forms.Label();
            this.numericUpDownNumCards = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumCards)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.Location = new System.Drawing.Point(110, 104);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(98, 30);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.LoadGame);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(128, 149);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 25);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ExitGame);
            // 
            // lblNumCards
            // 
            this.lblNumCards.AutoSize = true;
            this.lblNumCards.Font = new System.Drawing.Font("Yu Gothic UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCards.Location = new System.Drawing.Point(29, 60);
            this.lblNumCards.Name = "lblNumCards";
            this.lblNumCards.Size = new System.Drawing.Size(158, 13);
            this.lblNumCards.TabIndex = 4;
            this.lblNumCards.Text = "Number of cards to play with:";
            // 
            // numericUpDownNumCards
            // 
            this.numericUpDownNumCards.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numericUpDownNumCards.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumCards.Location = new System.Drawing.Point(193, 58);
            this.numericUpDownNumCards.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownNumCards.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNumCards.Name = "numericUpDownNumCards";
            this.numericUpDownNumCards.ReadOnly = true;
            this.numericUpDownNumCards.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownNumCards.TabIndex = 5;
            this.numericUpDownNumCards.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yu-Gi-Oh! Card Memory Game";
            // 
            // MenuScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(324, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownNumCards);
            this.Controls.Add(this.lblNumCards);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuScreenForm";
            this.Text = "Yu-Gi-Oh!";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNumCards;
        private System.Windows.Forms.NumericUpDown numericUpDownNumCards;
        private System.Windows.Forms.Label label1;
    }
}

