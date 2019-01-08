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

        public Form1() =>                   InitializeComponent();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartSetUp();         
        }

        void ChartSetUp()
        {
            Series series = new Series("Price");            series.ChartType = SeriesChartType.Line;            series.BorderWidth = 3;
            series.Color = Color.Gray;            series.IsVisibleInLegend = false;           chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;           chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;            chart.ChartAreas[0].AxisY.IsMarginVisible = false;
        }




        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            await GetIntraData(); AddChartData();
        }


        Dictionary<DateTime, decimal[]> IntraDataDict = new Dictionary<DateTime, decimal[]>();
        async Task GetIntraData()
        {
            IntraDataDict.Clear();
            var client = new AlphaVantageStocksClient(APIKey);
            StockTimeSeries timeSeries = await client.RequestIntradayTimeSeriesAsync("GE", IntradayInterval.FiveMin, TimeSeriesSize.Compact);    // client.RequestDailyTimeSeriesAsync("GE", TimeSeriesSize.Compact, false);
            foreach (var dataPoint in timeSeries.DataPoints)
            {
                if (DateTime.Now.Date == dataPoint.Time.Date)
                {
                    decimal[] tempDecimal = new decimal[4];
                    tempDecimal[0] = dataPoint.HighestPrice;
                    tempDecimal[1] = dataPoint.LowestPrice;
                    tempDecimal[2] = dataPoint.OpeningPrice;
                    tempDecimal[3] = dataPoint.ClosingPrice;
                    IntraDataDict[dataPoint.Time] = tempDecimal;
                }
            }
        }



        void AddChartData()
        {
            chart.Series["Price"].Points.Clear();
            double low = 0; double high = 0;
            for (int i = IntraDataDict.Count-1; i >= 0; i--)
            {            
                double close = Convert.ToDouble(IntraDataDict.ElementAt(i).Value[3]);
                chart.Series["Price"].Points.AddXY(IntraDataDict.ElementAt(i).Key.ToString("hh:mm:ss"), close);
                if (low > close || low == 0) low = close; if (high < close) high = close;
                chart.ChartAreas[0].AxisY.Maximum = (high + .25); chart.ChartAreas[0].AxisY.Minimum = (low - .25);

                textBox1.Text = IntraDataDict.ElementAt(i).Key.ToString("hh:mm:ss") + " : " + IntraDataDict.ElementAt(i).Value[3] + Environment.NewLine + textBox1.Text;
            }
        }




        void BuildMovingAverage(int intervals)
        {
            foreach (var item in )
            {

            }




        }











    }
}
