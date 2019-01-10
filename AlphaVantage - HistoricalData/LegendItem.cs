using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaVantage___HistoricalData
{
    public partial class LegendItem : UserControl
    {
        public LegendItem()
        {
            InitializeComponent();
        }

        Form1 MainForm;
        public void Init(Form1 f, string text, Color color, string n)
        {
            Name = n;
            MainForm = f;
            MainLabel.Text = text;
            ColorBox.BackColor = color;
        }

        private void LegendItem_MouseHover(object sender, EventArgs e)
        {
            MainForm.HoverMsg(Name);
        }

        private void LegendItem_MouseLeave(object sender, EventArgs e)
        {
            if(BackColor != SystemColors.ControlDark)
            MainForm.LeaveMsg(Name);
        }

        private void LegendItem_Click(object sender, EventArgs e)
        {
            if (BackColor != SystemColors.ControlDark)
            {
                MainForm.LegendClick(Name, true);
                BackColor = SystemColors.ControlDark;
            }
            else
            {
                MainForm.LegendClick(Name, false);
                BackColor = SystemColors.Control;
            }
        }

        private void SubMABttn_Click(object sender, EventArgs e)
        {
            MainForm.SubMABttn(Name);
        }
    }
}
