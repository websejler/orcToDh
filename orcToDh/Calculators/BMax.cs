using System;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using static orcToDh.OfsetFile;

namespace orcToDh.Calculators
{
    public partial class BMax : Form
    {
        OfsetFile ofsetFile;
        public double bMax = 0.0;

        public BMax(OfsetFile ofsetFile)
        {
            InitializeComponent();
            this.ofsetFile = ofsetFile;
            DrawChart();
        }

        public void DrawChart()
        {


            /*List<Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            List<Station> starboardStations = ofsetFile.StarboardStations.OrderBy(s => s.X).ToList();

            int portIndex = 0;
            double portHight = 0;
            double portHightMax = 0;
            int starboardIndex = 0;
            double starboardHight = 0;
            double starboardHightMax = 0;
            double maxBMax = 0.0;
            int maxBMaxIndexPort = -1;
            int maxBMaxIndexStarboard = -1;
            double currentBMax = 0.0;
            double maxPort = 0;
            double maxStarboard = 0;

            while (portIndex < portStations.Count && starboardIndex < starboardStations.Count)
            {

                double port = 0;
                foreach (OfsetFile.DataPoint dataPoint in portStations[portIndex].dataPoints)
                {
                    if (dataPoint.Y > port)
                    {
                        port = dataPoint.Y;
                        portHight = dataPoint.Z;
                    }
                }

                double starboard = 0;
                foreach (OfsetFile.DataPoint dataPoint in starboardStations[starboardIndex].dataPoints)
                {
                    if (dataPoint.Y > starboard)
                    {
                        starboard = dataPoint.Y;
                        starboardHight = dataPoint.Z;
                    }
                }

                currentBMax = port + starboard;
                if (currentBMax > maxBMax)
                {
                    maxBMax = currentBMax;
                    maxBMaxIndexPort = portIndex;
                    maxBMaxIndexStarboard = starboardIndex;
                    portHightMax = portHight;
                    starboardHightMax = starboardHight;
                    maxPort = port;
                    maxStarboard = starboard;
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


            }*/

            List<Station> stations = ofsetFile.Stations;
            Station bestBMaxStation = stations[0];
            List<OfsetFile.DataPoint> bestBMaxDataPoints = stations[0].dataPoints;
            double bestBMax = 0;
            double bestBMaxHight = 0;
            int maxBMaxIndex = 0;
            for(int i = 0; i < stations.Count; i++)
            {
                double bMax = 0;
                double bMaxHight = 0;
                foreach (OfsetFile.DataPoint dataPoint in stations[i].dataPoints)
                {
                    if (dataPoint.Y > bMax)
                    {
                        bMax = dataPoint.Y;
                        bMaxHight = dataPoint.Z;
                    }
                }
                if (bMax > bestBMax)
                {
                    bestBMax = bMax;
                    bestBMaxHight = bMaxHight;
                    bestBMaxStation = stations[i];
                    bestBMaxDataPoints = stations[i].dataPoints;
                    maxBMaxIndex = i;
                }
            }



            chart.Series.Clear();
            chart.Series.Add(new Series("Scann Port"));
            chart.Series.Add(new Series("Scann Starboard"));
            chart.Series.Add(new Series("BMax"));

            // map the datapoints in starboardStations and portStations to the chart form with maxBMaxIndex
            foreach (OfsetFile.DataPoint dataPoint in bestBMaxDataPoints.ToArray().Reverse())
            {
                if (dataPoint.Y > 0)
                    chart.Series[0].Points.AddXY(-dataPoint.Y, dataPoint.Z);
            }

            foreach (OfsetFile.DataPoint dataPoint in bestBMaxDataPoints.ToArray())
            {
                if (dataPoint.Y > 0)
                    chart.Series[1].Points.AddXY(dataPoint.Y, dataPoint.Z);
            }
            //port drawing
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[0].Color = System.Drawing.Color.Red;
            //starboard drawing
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[1].Color = System.Drawing.Color.Green;
            //bmax drawing
            chart.Series[2].Points.AddXY(-bestBMax, bestBMaxHight);
            chart.Series[2].Points.AddXY(bestBMax, bestBMaxHight);
            chart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart.Series[2].Color = System.Drawing.Color.Blue;

            this.bMax = bestBMax*2;

            BMaxLabel.Text = "BMax: " + this.bMax.ToString();
            PortStationLabel.Text = bestBMaxStation.SID.ToString() + " station: - x: " + bestBMaxStation.X + " - z: " + bestBMaxHight + " - y: " + bestBMax;
        }
    }
}
