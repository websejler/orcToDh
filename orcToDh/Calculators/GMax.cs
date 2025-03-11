
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
            chart.Series.Add("StarboardLine");
            chart.Series.Add("GMaxLine");
            chart.Series.Add("VandLinje");

            chart.Series["PortLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["StarboardLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
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
        }

        private double calGMaxOnStationOld(OffsetFile.Station station, out List<OffsetFile.DataPoint> dataPoints)
        {
            dataPoints = new();
            dataPoints.Add(station.dataPoints[0]);
            //extracts the datapoints in GMax
            for (int i = 0; i < station.dataPoints.Count; i++)
            {
                int j = i + 1;
                double currentGradient = double.MaxValue;
                int currentGradientIndex = -1;
                for (; j < station.dataPoints.Count; j++)
                {
                    double tempGradient = (station.dataPoints[j].Z - station.dataPoints[i].Z) / (station.dataPoints[j].Y - station.dataPoints[i].Y);

                    if (station.dataPoints[i].Y > station.dataPoints[j].Y)
                        continue;

                    if (station.dataPoints[j].Y < 0)
                        continue;

                    if (tempGradient < currentGradient)
                    {
                        currentGradient = tempGradient;
                        currentGradientIndex = j;
                    }
                }
                if (currentGradientIndex != -1)
                {
                    i = currentGradientIndex - 1;
                    dataPoints.Add(station.dataPoints[currentGradientIndex]);
                }
            }
            //calculates the distance
            double gMax = 0;
            for (int i = 0; i < dataPoints.Count - 1; i++)
            {
                Point p1 = new Point((int)dataPoints[i].Y, (int)dataPoints[i].Z);
                Point p2 = new Point((int)dataPoints[i + 1].Y, (int)dataPoints[i + 1].Z);
                double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                gMax += distance;
            }
            Console.WriteLine("Station.x;" + station.X + ";GMax;" + gMax);
            return gMax;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
