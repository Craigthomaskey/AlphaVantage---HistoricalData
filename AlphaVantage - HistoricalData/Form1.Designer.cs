namespace AlphaVantage___HistoricalData
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.IntraDataBttn = new System.Windows.Forms.Button();
            this.DayDataBttn = new System.Windows.Forms.Button();
            this.DataSizeCheck = new System.Windows.Forms.CheckBox();
            this.MonthDataBttn = new System.Windows.Forms.Button();
            this.LegendPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.NewIntrvlNum = new System.Windows.Forms.NumericUpDown();
            this.AddMABttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewIntrvlNum)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(208, 426);
            this.textBox1.TabIndex = 0;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(227, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(561, 361);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // IntraDataBttn
            // 
            this.IntraDataBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IntraDataBttn.Location = new System.Drawing.Point(704, 415);
            this.IntraDataBttn.Name = "IntraDataBttn";
            this.IntraDataBttn.Size = new System.Drawing.Size(84, 23);
            this.IntraDataBttn.TabIndex = 2;
            this.IntraDataBttn.Text = "Get Intra Data";
            this.IntraDataBttn.UseVisualStyleBackColor = true;
            this.IntraDataBttn.Click += new System.EventHandler(this.IntraDataBttn_ClickAsync);
            // 
            // DayDataBttn
            // 
            this.DayDataBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DayDataBttn.Location = new System.Drawing.Point(614, 415);
            this.DayDataBttn.Name = "DayDataBttn";
            this.DayDataBttn.Size = new System.Drawing.Size(84, 23);
            this.DayDataBttn.TabIndex = 2;
            this.DayDataBttn.Text = "Get Day Data";
            this.DayDataBttn.UseVisualStyleBackColor = true;
            this.DayDataBttn.Click += new System.EventHandler(this.DayDataBttn_ClickAsync);
            // 
            // DataSizeCheck
            // 
            this.DataSizeCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSizeCheck.AutoSize = true;
            this.DataSizeCheck.Checked = true;
            this.DataSizeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DataSizeCheck.Location = new System.Drawing.Point(227, 420);
            this.DataSizeCheck.Name = "DataSizeCheck";
            this.DataSizeCheck.Size = new System.Drawing.Size(94, 17);
            this.DataSizeCheck.TabIndex = 3;
            this.DataSizeCheck.Text = "Compact Data";
            this.DataSizeCheck.UseVisualStyleBackColor = true;
            // 
            // MonthDataBttn
            // 
            this.MonthDataBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthDataBttn.Location = new System.Drawing.Point(515, 416);
            this.MonthDataBttn.Name = "MonthDataBttn";
            this.MonthDataBttn.Size = new System.Drawing.Size(93, 23);
            this.MonthDataBttn.TabIndex = 2;
            this.MonthDataBttn.Text = "Get Month Data";
            this.MonthDataBttn.UseVisualStyleBackColor = true;
            this.MonthDataBttn.Click += new System.EventHandler(this.MonthDataBttn_ClickAsync);
            // 
            // LegendPanel
            // 
            this.LegendPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendPanel.BackColor = System.Drawing.Color.White;
            this.LegendPanel.Location = new System.Drawing.Point(227, 379);
            this.LegendPanel.Name = "LegendPanel";
            this.LegendPanel.Size = new System.Drawing.Size(494, 30);
            this.LegendPanel.TabIndex = 4;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorLabel.Location = new System.Drawing.Point(268, 106);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(475, 148);
            this.ErrorLabel.TabIndex = 5;
            this.ErrorLabel.Text = "Error : ";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewIntrvlNum
            // 
            this.NewIntrvlNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewIntrvlNum.Location = new System.Drawing.Point(727, 384);
            this.NewIntrvlNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NewIntrvlNum.Name = "NewIntrvlNum";
            this.NewIntrvlNum.Size = new System.Drawing.Size(37, 20);
            this.NewIntrvlNum.TabIndex = 6;
            this.NewIntrvlNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddMABttn
            // 
            this.AddMABttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddMABttn.Location = new System.Drawing.Point(768, 384);
            this.AddMABttn.Name = "AddMABttn";
            this.AddMABttn.Size = new System.Drawing.Size(20, 20);
            this.AddMABttn.TabIndex = 7;
            this.AddMABttn.Text = "+";
            this.AddMABttn.UseVisualStyleBackColor = true;
            this.AddMABttn.Click += new System.EventHandler(this.AddMABttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddMABttn);
            this.Controls.Add(this.NewIntrvlNum);
            this.Controls.Add(this.LegendPanel);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.DataSizeCheck);
            this.Controls.Add(this.MonthDataBttn);
            this.Controls.Add(this.DayDataBttn);
            this.Controls.Add(this.IntraDataBttn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ErrorLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewIntrvlNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button IntraDataBttn;
        private System.Windows.Forms.Button DayDataBttn;
        private System.Windows.Forms.CheckBox DataSizeCheck;
        private System.Windows.Forms.Button MonthDataBttn;
        private System.Windows.Forms.FlowLayoutPanel LegendPanel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.NumericUpDown NewIntrvlNum;
        private System.Windows.Forms.Button AddMABttn;
    }
}

