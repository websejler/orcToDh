
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

        private void calGmax()
        {
            //List<OfsetFile.Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            double bestGmax = ofsetFile.GMax;
            List<OffsetFile.Station> stations = ofsetFile.stations;
            OffsetFile.Station bestGmaxStation = ofsetFile.bestGmaxStation;
            List<OffsetFile.DataPoint> bestGmaxDataPoints = ofsetFile.bestGmaxDataPoints;
           
            
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
            chart.Series["VandLinje"].Points.AddXY(bestGmaxStation.WLBredde/2 - 150, bestGmaxStation.WLZ);
            chart.Series["VandLinje"].Points.AddXY(bestGmaxStation.WLBredde/2 + 150, bestGmaxStation.WLZ);



            // Find the minimum X value in the data points
            double minX = Math.Min(bestGmaxStation.dataPoints.Min(dp => dp.Y), bestGmaxDataPoints.Min(dp => dp.Y));

            // Customize the X and Y axes
            chart.ChartAreas[0].AxisX.Interval = 500; // Set the interval for X-axis
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0"; // Format labels as integers
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray; // Set grid line color
            chart.ChartAreas[0].AxisX.Minimum = Math.Floor(minX / 500) * 500; // Set the minimum value for X-axis to the nearest lower multiple of 500

            chart.ChartAreas[0].AxisY.Interval = 500; // Set the interval for Y-axis
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0"; // Format labels as integers
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; // Set grid line color
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
