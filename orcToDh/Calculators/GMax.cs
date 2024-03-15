
using System;
using System.Data;
using System.IO;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using static orcToDh.OfsetFile;

namespace orcToDh.Calculators
{
    public partial class GMax : Form
    {
        OfsetFile ofsetFile;
        public GMax(OfsetFile ofsetFile)
        {
            InitializeComponent();
            this.ofsetFile = ofsetFile;
            calGmax();
        }

        private void calGmax()
        {
            //List<OfsetFile.Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            List<OfsetFile.Station> stations = ofsetFile.stations;
            OfsetFile.Station bestGmaxStation = stations[0];
            List<OfsetFile.DataPoint> bestGmaxDataPoints = stations[0].dataPoints;
            double bestGmax = 0;



            int index = 0;
            //cal gmax  over all stations and keep the best
            while (index < stations.Count)
            {
                double gMax = calGMaxOnStation(stations[index], out List<OfsetFile.DataPoint> dataPoints);

                double distanceBetweenLowerDataPoints = dataPoints[0].Y >= 0 ? dataPoints[0].Y : 0.0;

                double tempGmax = gMax + distanceBetweenLowerDataPoints;
                if (tempGmax > bestGmax)
                {
                    bestGmax = tempGmax;
                    bestGmaxStation = stations[index];
                    bestGmaxDataPoints = dataPoints;
                }

                index++;
            }
            bestGmax *= 2;
            chart.Series.Clear();
            chart.Series.Add("PortLine");
            chart.Series.Add("StarboardLine");
            chart.Series.Add("GMaxLine");

            chart.Series["PortLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["StarboardLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["GMaxLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            foreach (OfsetFile.DataPoint datePoint in bestGmaxStation.dataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(datePoint.Y, datePoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 8;
                chartPoint.MarkerColor = Color.Red;
                chart.Series["PortLine"].Points.Add(chartPoint);
            }

            //foreach (OfsetFile.DataPoint datePoint in bestGmaxStation.dataPoints)
            //{
            //    var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(-datePoint.Y, datePoint.Z);
            //    chartPoint.MarkerStyle = MarkerStyle.Circle;
            //    chartPoint.MarkerSize = 8;
            //    chartPoint.MarkerColor = Color.Green;
            //    chart.Series["StarboardLine"].Points.Add(chartPoint);
            //}

            //for (int i = bestGmaxDataPoints.Count - 1; i >= 0; i--)
            //{
            //    OfsetFile.DataPoint dataPoint = bestGmaxDataPoints[i];
            //    var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(-dataPoint.Y, dataPoint.Z);
            //    chartPoint.MarkerStyle = MarkerStyle.Circle;
            //    chartPoint.MarkerSize = 5;
            //    chartPoint.MarkerColor = Color.Blue;
            //    chart.Series["GMaxLine"].Points.Add(chartPoint);
            //}

            foreach (OfsetFile.DataPoint dataPoint in bestGmaxDataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(dataPoint.Y, dataPoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 5;
                chartPoint.MarkerColor = Color.Blue;
                chart.Series["GMaxLine"].Points.Add(chartPoint);
            }
            gMaxLengthLabel.Text = "GMax: " + bestGmax.ToString("0.00");
            StationInfoLabel.Text = bestGmaxStation.SID.ToString() + "station  - x: " + bestGmaxStation.X;

        }

        private double calGMaxOnStationOld(OfsetFile.Station station, out List<OfsetFile.DataPoint> dataPoints)
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

        private double calGMaxOnStation(OfsetFile.Station station, out List<OfsetFile.DataPoint> dataPoints)
        {
            dataPoints = new();
            dataPoints.Add(station.dataPoints[0]);
            Vector2 dir = new Vector2(0, -1);
            //extracts the datapoints in GMax
            for (int i = 0; i < station.dataPoints.Count - 1; i++)
            {
                int smallestAngleIndex = -1;
                double smallestAngle = double.MaxValue;
                List<OfsetFile.DataPoint> points = station.dataPoints.Skip(i).ToList();
                for (int j = 1; j < points.Count; j++)
                {
                    Vector2 v = Vector2.Subtract(points[0].GetVector2(), points[j].GetVector2());

                    // dot product
                    float dotProduct = Vector2.Dot(dir, v);
                    float crossProduct = dir.X * v.Y - dir.Y * v.X;
                    float sign = Math.Sign(crossProduct);

                    // magnitudes
                    float magD = dir.Length();
                    float magV = v.Length();


                    // angle in radians
                    float theta = (float)(Math.Acos(dotProduct / (magD * magV)) * sign);

                    theta = (float)(theta * (180 / Math.PI));

                    if (theta < smallestAngle)
                    {
                        smallestAngle = theta;
                        smallestAngleIndex = i+j;
                    }
                }
                if (smallestAngleIndex != -1)
                {
                    dir = Vector2.Subtract(station.dataPoints[i].GetVector2(), station.dataPoints[smallestAngleIndex].GetVector2());
                    i = smallestAngleIndex - 1;
                    dataPoints.Add(station.dataPoints[smallestAngleIndex]);

                }
                else
                {
                    break;
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
    }
}
