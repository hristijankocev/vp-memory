
namespace YuGiOh
{
    partial class EndForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDownNumCards = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumCards)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(215, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(215, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Restart";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDownNumCards
            // 
            this.numericUpDownNumCards.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumCards.Location = new System.Drawing.Point(306, 12);
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
            this.numericUpDownNumCards.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownNumCards.TabIndex = 6;
            this.numericUpDownNumCards.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(197, 118);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "You won!\r\nStart a new game or view the cards info by right clicking them.";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(215, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(85, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Number of cards";
            // 
            // EndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(365, 140);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDownNumCards);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "EndForm";
            this.Text = "Yu-Gi-Oh!";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumCards;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}