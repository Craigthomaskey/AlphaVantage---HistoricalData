namespace AlphaVantage___HistoricalData
{
    partial class LegendItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColorBox = new System.Windows.Forms.PictureBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SubMABttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ColorBox
            // 
            this.ColorBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ColorBox.Location = new System.Drawing.Point(5, 7);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(12, 12);
            this.ColorBox.TabIndex = 0;
            this.ColorBox.TabStop = false;
            this.ColorBox.Click += new System.EventHandler(this.LegendItem_Click);
            this.ColorBox.MouseLeave += new System.EventHandler(this.LegendItem_MouseLeave);
            this.ColorBox.MouseHover += new System.EventHandler(this.LegendItem_MouseHover);
            // 
            // MainLabel
            // 
            this.MainLabel.Location = new System.Drawing.Point(23, 3);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(65, 19);
            this.MainLabel.TabIndex = 1;
            this.MainLabel.Text = "5 Minute";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainLabel.Click += new System.EventHandler(this.LegendItem_Click);
            this.MainLabel.MouseLeave += new System.EventHandler(this.LegendItem_MouseLeave);
            this.MainLabel.MouseHover += new System.EventHandler(this.LegendItem_MouseHover);
            // 
            // SubMABttn
            // 
            this.SubMABttn.Location = new System.Drawing.Point(93, 2);
            this.SubMABttn.Name = "SubMABttn";
            this.SubMABttn.Size = new System.Drawing.Size(20, 20);
            this.SubMABttn.TabIndex = 8;
            this.SubMABttn.Text = "-";
            this.SubMABttn.UseVisualStyleBackColor = true;
            this.SubMABttn.Click += new System.EventHandler(this.SubMABttn_Click);
            // 
            // LegendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SubMABttn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.ColorBox);
            this.Name = "LegendItem";
            this.Size = new System.Drawing.Size(116, 25);
            this.Click += new System.EventHandler(this.LegendItem_Click);
            this.MouseLeave += new System.EventHandler(this.LegendItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.LegendItem_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ColorBox;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Button SubMABttn;
    }
}
