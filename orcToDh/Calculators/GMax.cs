
using System.Data;
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
            List<OfsetFile.Station> portStations = ofsetFile.stations;
            OfsetFile.Station bestGmaxPortStation = portStations[0];
            List<OfsetFile.DataPoint> bestGmaxPortDataPoints = portStations[0].dataPoints;
            double bestGmaxPort = 0;

            //<OfsetFile.Station> starboardStations = ofsetFile.StarboardStations.OrderBy(s => s.X).ToList();
            List<OfsetFile.Station> starboardStations = ofsetFile.stations;
            OfsetFile.Station bestGmaxStarboardStation = starboardStations[0];
            List<OfsetFile.DataPoint> bestGmaxStarboardDataPoints = portStations[0].dataPoints;
            double bestGmaxStarboard = 0;

            double bestGmax = -1;

            int portIndex = 0;
            int starboardIndex = 0;
            //cal gmax  over all stations and keep the best
            while (portIndex < portStations.Count && starboardIndex < starboardStations.Count)
            {
                double portGMax = calGMaxOnStation(portStations[portIndex], out List<OfsetFile.DataPoint> portDataPoints);
                double starboardGMax = calGMaxOnStation(starboardStations[starboardIndex], out List<OfsetFile.DataPoint> starboardDataPoints);
                double distanceBetweenLowerDataPoints = Math.Abs(portDataPoints[0].Y - starboardDataPoints[0].Y);

                double tempGmax = portGMax + starboardGMax + distanceBetweenLowerDataPoints;
                if (tempGmax > bestGmax)
                {
                    bestGmax = tempGmax;
                    bestGmaxPort = portGMax;
                    bestGmaxStarboard = starboardGMax;
                    bestGmaxPortStation = portStations[portIndex];
                    bestGmaxPortDataPoints = portDataPoints;
                    bestGmaxStarboardStation = starboardStations[starboardIndex];
                    bestGmaxStarboardDataPoints = starboardDataPoints;
                }
                
                if (portStations[portIndex].X < starboardStations[starboardIndex].X)
                {
                    portIndex++;
                }
                else if (portStations[portIndex].X > starboardStations[starboardIndex].X)
                {
                    starboardIndex++;
                }
                else
                {
                    portIndex++;
                    starboardIndex++;
                }
            }

            chart.Series.Clear();
            chart.Series.Add("PortLine");
            chart.Series.Add("StarboardLine");
            chart.Series.Add("GMaxLine");

            chart.Series["PortLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["StarboardLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["GMaxLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            foreach (OfsetFile.DataPoint datePoint in bestGmaxPortStation.dataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(datePoint.Y, datePoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 8;
                chartPoint.MarkerColor = Color.Red;
                chart.Series["PortLine"].Points.Add(chartPoint);
            }

            foreach (OfsetFile.DataPoint datePoint in bestGmaxStarboardStation.dataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(-datePoint.Y, datePoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 8;
                chartPoint.MarkerColor = Color.Green;
                chart.Series["StarboardLine"].Points.Add(chartPoint);
            }

            for (int i = bestGmaxStarboardDataPoints.Count - 1; i >= 0; i--)
            {
                OfsetFile.DataPoint dataPoint = bestGmaxStarboardDataPoints[i];
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(-dataPoint.Y, dataPoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 5;
                chartPoint.MarkerColor = Color.Blue;
                chart.Series["GMaxLine"].Points.Add(chartPoint);
            }

            foreach (OfsetFile.DataPoint dataPoint in bestGmaxPortDataPoints)
            {
                var chartPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(dataPoint.Y, dataPoint.Z);
                chartPoint.MarkerStyle = MarkerStyle.Circle;
                chartPoint.MarkerSize = 5;
                chartPoint.MarkerColor = Color.Blue;
                chart.Series["GMaxLine"].Points.Add(chartPoint);
            }
            gMaxLengthLabel.Text = "GMax: " + bestGmax.ToString("0.00");
            PortStationLabel.Text = "Port Station - x: " + bestGmaxPortStation.X + " - gmax: " + bestGmaxPort;
            StarboardStationLabel.Text = "Starboard Station - x: " + bestGmaxStarboardStation.X + " - gmax: " + bestGmaxStarboard;
        }

        private double calGMaxOnStation(OfsetFile.Station station, out List<OfsetFile.DataPoint> dataPoints)
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
    }
}
