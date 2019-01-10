using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlphaVantage___HistoricalData
{
    public partial class Form1 : Form
    {

        string APIKey = "XZG6SFKFFJUEOHBX";

        public Form1() => InitializeComponent();


        private void Form1_Load(object sender, EventArgs e)
        {
            MonthDataBttn.PerformClick();
        }





        List<int> IntraIntrvls = new List<int>() { 5, 10, 15 };
        List<int> DayIntrvls = new List<int>() { 5, 10, 30 };
        List<int> MonthIntrvls = new List<int>(){ 3, 6, 8 };
        int DataType = 1;
        private async void IntraDataBttn_ClickAsync(object sender, EventArgs e)
        {
            try { await GetData(1); chart.Visible = true; } catch (Exception ex) { chart.Visible = false; ErrorLabel.Text = "Error : " + ex.Message; }
            ChangeChartData();
            AddChartPriceData("Price", DataDict, "HH:mm:ss");
            BuildMovingAverage(IntraIntrvls, DataDict, DataType);
        }
        private async void DayDataBttn_ClickAsync(object sender, EventArgs e)
        {
            try { await GetData(2); chart.Visible = true; } catch (Exception ex) { chart.Visible = false; ErrorLabel.Text = "Error : " + ex.Message; }
            ChangeChartData();
            AddChartPriceData("Price", DataDict, "yyyy-MM-dd");
            BuildMovingAverage(DayIntrvls, DataDict, DataType);
        }
        private async void MonthDataBttn_ClickAsync(object sender, EventArgs e)
        {
            try { await GetData(3); chart.Visible = true; } catch (Exception ex) { chart.Visible = false; ErrorLabel.Text = "Error : " + ex.Message; }
            ChangeChartData();
            AddChartPriceData("Price", DataDict, "yyyy-MM-dd");
            BuildMovingAverage(MonthIntrvls, DataDict, DataType);
        }

        void ChangeChartData()
        {
            textBox1.Clear();
            foreach (Series series in chart.Series) series.Points.Clear();
            ChartHigh = 0; ChartLow = 0;
        }


        Dictionary<DateTime, decimal[]> DataDict = new Dictionary<DateTime, decimal[]>();
        async Task GetData(int type)
        {
            DataType = type;            DataDict.Clear();
            var client = new AlphaVantageStocksClient(APIKey);

            StockTimeSeries timeSeries;
            TimeSeriesSize TSS = TimeSeriesSize.Compact; if (!DataSizeCheck.Checked) TSS = TimeSeriesSize.Full;

            if (type == 1) timeSeries = await client.RequestIntradayTimeSeriesAsync("GE", IntradayInterval.OneMin, TSS);
            else if (type == 2) timeSeries = await client.RequestDailyTimeSeriesAsync("GE", TSS, false);
            else timeSeries = await client.RequestMonthlyTimeSeriesAsync("GE", false);




            foreach (var dataPoint in timeSeries.DataPoints)
            {
                if (type == 3 && (DateTime.Now - dataPoint.Time).TotalDays > (365 * 3)) continue;
                else if (type == 2 && (DateTime.Now - dataPoint.Time).TotalDays > 365) continue;
                else if (type == 1 && dataPoint.Time.Day != DateTime.Now.Day) continue;

                decimal[] tempDecimal = new decimal[4];
                tempDecimal[0] = dataPoint.HighestPrice;
                tempDecimal[1] = dataPoint.LowestPrice;
                tempDecimal[2] = dataPoint.OpeningPrice;
                tempDecimal[3] = dataPoint.ClosingPrice;
                DataDict[dataPoint.Time] = tempDecimal;
            }
        }




        void AddChartSeries(string name, Color color, int width, SeriesChartType chartType)
        {
            Series series = new Series(name); series.ChartType = chartType; series.BorderWidth = width;
            series.Color = color; series.IsVisibleInLegend = false; chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true; chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.IsMarginVisible = false; chart.ChartAreas[0].AxisY.IsMarginVisible = false;
        }

        double ChartHigh = 0;
        double ChartLow = 0;
        void AddChartPriceData(string name, Dictionary<DateTime, decimal[]> data, string timeFormat)
        {
            if (chart.Series.IndexOf(name) != -1) chart.Series[name].Points.Clear();
            else AddChartSeries(name, Color.DarkGray, 3, SeriesChartType.Line);

            for (int i = data.Count - 1; i >= 0; i--)
            {
                double close = Convert.ToDouble(data.ElementAt(i).Value[3]);
                chart.Series[name].Points.AddXY(data.ElementAt(i).Key.ToString(timeFormat), close);
                CheckChartSpacing(close);
                textBox1.Text = data.ElementAt(i).Key.ToString(timeFormat) + " : " + data.ElementAt(i).Value[3] + Environment.NewLine + textBox1.Text;
            }
        }

        List<Color> ColorList = new List<Color>() { Color.Blue, Color.Red, Color.LightGreen, Color.DarkOliveGreen, Color.DarkMagenta };
        void AddCharMAtData(string name, Dictionary<DateTime, double> data, int type)
        {
            Color color = ColorList[0]; ColorList.RemoveAt(0); ColorList.Add(color);
            if (chart.Series.IndexOf(name) != -1) { chart.Series[name].Points.Clear(); chart.Series[name].Color = color;  }
            else AddChartSeries(name, color, 1, SeriesChartType.Line);


            foreach (var item in data)
            {
                chart.Series[name].Points.AddXY(item.Key.ToString("hh:mm:ss"), item.Value);
                CheckChartSpacing(item.Value);
            }

            string inttype = " Minute";
            if (type == 2) inttype = " Day"; else if (type == 3) inttype = " Month";
            LegendItem LI = new LegendItem();
            LI.Init(this, name.Substring(0, name.Length - 5) + inttype, color, name);
            LegendPanel.Controls.Add(LI);
        }





        void CheckChartSpacing(double newPoint)
        {
            if (ChartLow > newPoint || ChartLow == 0) ChartLow = newPoint; if (ChartHigh < newPoint || ChartHigh == 0) ChartHigh = newPoint;
            chart.ChartAreas[0].AxisY.Maximum = (ChartHigh + .25); chart.ChartAreas[0].AxisY.Minimum = (ChartLow - .25);
        }


        Dictionary<int, Dictionary<DateTime, double>> MovingAveragesDict = new Dictionary<int, Dictionary<DateTime, double>>();

        void BuildMovingAverage(List<int> intervals, Dictionary<DateTime, decimal[]> data, int type)
        {
            MovingAveragesDict.Clear();
            foreach (Series series in chart.Series) { if (series.Name != "Price") series.Points.Clear(); }
            while (LegendPanel.Controls.Count > 0) { LegendPanel.Controls[0].Dispose(); }

            foreach (int intrvl in intervals)
            {
                MovingAveragesDict.Add(intrvl, new Dictionary<DateTime, double>());
                List<double> tempList = new List<double>();
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    tempList.Add(Convert.ToDouble(data.ElementAt(i).Value[3]));
                    if (tempList.Count > intrvl) tempList.RemoveAt(0);
                    MovingAveragesDict[intrvl].Add(data.ElementAt(i).Key, tempList.Average());
                }
                AddCharMAtData(intrvl + "IntMA", MovingAveragesDict[intrvl], type);
            }
        }



        private void AddMABttn_Click(object sender, EventArgs e)
        {
            int tempInt = Convert.ToInt32(NewIntrvlNum.Value);
            if (DataType == 1 && !IntraIntrvls.Contains(tempInt))
            {
                IntraIntrvls.Add(tempInt);
                BuildMovingAverage(IntraIntrvls, DataDict, DataType);
            }
            else if (DataType == 2 && !DayIntrvls.Contains(tempInt))
            {
                DayIntrvls.Add(tempInt);
                BuildMovingAverage(DayIntrvls, DataDict, DataType);
            }
            else if (DataType == 3 && !MonthIntrvls.Contains(tempInt))
            {
                MonthIntrvls.Add(tempInt);
                BuildMovingAverage(MonthIntrvls, DataDict, DataType);
            }
            
        }

        public void SubMABttn(string name)
        {
            int tempInt = Convert.ToInt32(name.Substring(0, name.Length - 5));
            if (DataType == 1 && IntraIntrvls.Contains(tempInt))
            {
                IntraIntrvls.Remove(tempInt);
                BuildMovingAverage(IntraIntrvls, DataDict, DataType);
            }
            else if (DataType == 2 && DayIntrvls.Contains(tempInt))
            {
                DayIntrvls.Remove(tempInt);
                BuildMovingAverage(DayIntrvls, DataDict, DataType);
            }
            else if (DataType == 3 && MonthIntrvls.Contains(tempInt))
            {
                MonthIntrvls.Remove(tempInt);
                BuildMovingAverage(MonthIntrvls, DataDict, DataType);
            }
        }





        public void HoverMsg(string name)
        {
            chart.Series[chart.Series.IndexOf(name)].BorderWidth = 3;
        }
        public void LeaveMsg(string name)
        {
            chart.Series[chart.Series.IndexOf(name)].BorderWidth = 1;
        }

        public void LegendClick(string name, bool select)
        {
            foreach (LegendItem LI in LegendPanel.Controls) LI.BackColor = Color.White;
            foreach (Series series in chart.Series)
            {
                series.Enabled = true;
                if (select)
                    if (series.Name != "Price" && series.Name != name)
                        series.Enabled = false;
                    else
                        series.BorderWidth = 3;
                else
                    if (series.Name == "Price")
                    series.BorderWidth = 3;
                else
                    series.BorderWidth = 1;
            }
        }





    }




}

