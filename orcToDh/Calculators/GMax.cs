
using System;
using System.Data;
using System.IO;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using static orcToDh.OffsetFile;

namespace orcToDh.Calculators
{
    public partial class GMax : Form
    {
        OffsetFile ofsetFile;
        public GMax(OffsetFile ofsetFile)
        {
            InitializeComponent();
            this.ofsetFile = ofsetFile;
            calGmax();
        }

        private void calGmax(int index = 0)
        {
            //List<OfsetFile.Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            double bestGmax = ofsetFile.GMax;
            double bestGmaxStationX = ofsetFile.bestGmaxStation.X;
            int i = 0;
            for (; i < ofsetFile.Stations.Count; i++)
            {
                if (ofsetFile.Stations[i].X == bestGmaxStationX)
                    break;
            }
            i = i + index;
            OffsetFile.Station bestGmaxStation = ofsetFile.Stations[i];
            bestGmax = bestGmaxStation.GMax;
            List<OffsetFile.DataPoint> bestGmaxDataPoints = bestGmaxStation.GMaxDataPoints;


            chart.Series.Clear();
            chart.Series.Add("PortLine");
            chart.Series.Add("GMaxLine");
            chart.Series.Add("VandLinje");

            chart.Series["PortLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["GMaxLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["VandLinje"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;



            foreach (OffsetFile.DataPoint datePoint in bestGmaxStation.dataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(datePoint.Y, datePoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 8;
                chartPoint.MarkerColor = Color.Red;
                if (chartPoint.XValue > 0)
                    chart.Series["PortLine"].Points.Add(chartPoint);
            }

            foreach (OffsetFile.DataPoint dataPoint in bestGmaxDataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(dataPoint.Y, dataPoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 5;
                chartPoint.MarkerColor = Color.Blue;
                chart.Series["GMaxLine"].Points.Add(chartPoint);
            }




            gMaxLengthLabel.Text = "GMax: " + bestGmax.ToString("0");
            StationInfoLabel.Text = bestGmaxStation.SID.ToString() + "station  - x: " + bestGmaxStation.X;
            wLZlabel.Text = "WLZ: " + bestGmaxStation.WLZ;
            fribordHoejdeLabel.Text = "Fribord: " + bestGmaxStation.FribordHoejde;
            wLBreddelabel.Text = "WLBredde: " + bestGmaxStation.WLBredde;
            udfaldLabel.Text = "Udfald: " + bestGmaxStation.Udfald;
            gLable.Text = "G: " + bestGmaxStation.G;

            //display a horizontal line at the waterline, in the fulle width of the chart
            chart.Series["VandLinje"].Points.AddXY(bestGmaxStation.WLBredde / 2 - 150, bestGmaxStation.WLZ);
            chart.Series["VandLinje"].Points.AddXY(bestGmaxStation.WLBredde / 2 + 150, bestGmaxStation.WLZ);




            // Customize the X and Y axes
            chart.ChartAreas[0].AxisX.Interval = 500; // Set the interval for X-axis
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0"; // Format labels as integers
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray; // Set grid line color
            chart.ChartAreas[0].AxisX.Minimum = 0;

            chart.ChartAreas[0].AxisY.Interval = 500; // Set the interval for Y-axis
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0"; // Format labels as integers
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; // Set grid line color
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int t = trackBar1.Value;
            trackBarLabel.Text = t.ToString();
            calGmax(t);
        }

        private void GMax_Load(object sender, EventArgs e)
        {

        }
    }
}
