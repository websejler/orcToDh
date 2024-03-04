using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using static orcToDh.OfsetFile;

namespace orcToDh.Calculators
{
    public partial class BMax : Form
    {
        OfsetFile ofsetFile;
        public BMax(OfsetFile ofsetFile)
        {
            InitializeComponent();
            this.ofsetFile = ofsetFile;
            DrawChart();
        }

        public void DrawChart()
        {
            

            List<Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            List<Station> starboardStations = ofsetFile.StarboardStations.OrderBy(s => s.X).ToList();

            int portIndex = 0;
            int starboardIndex = 0;
            double maxBMax = 0.0;
            int maxBMaxIndexPort = -1;
            int maxBMaxIndexStarboard = -1;
            double currentBMax = 0.0;

            while (portIndex < portStations.Count && starboardIndex < starboardStations.Count)
            {
                if (portStations[portIndex].X < starboardStations[starboardIndex].X)
                {
                    currentBMax = 0;
                    portIndex++;
                }
                else if (portStations[portIndex].X > starboardStations[starboardIndex].X)
                {
                    currentBMax = 0;
                    starboardIndex++;
                }
                else
                {
                    double maxPort = 0;
                    foreach (OfsetFile.DataPoint dataPoint in portStations[portIndex].dataPoints)
                    {
                        if (dataPoint.Y > maxPort)
                        {
                            maxPort = dataPoint.Y;
                        }
                    }

                    double maxStarboard = 0;
                    foreach (OfsetFile.DataPoint dataPoint in starboardStations[starboardIndex].dataPoints)
                    {
                        if (dataPoint.Y > maxStarboard)
                        {
                            maxStarboard = dataPoint.Y;
                        }
                    }

                    currentBMax = maxPort + maxStarboard;
                    if (currentBMax > maxBMax)
                    {
                        maxBMax = currentBMax;
                        maxBMaxIndexPort = portIndex;
                        maxBMaxIndexStarboard = starboardIndex;
                    }
                    portIndex++;
                    starboardIndex++;
                }
            }
            // map the datapoints in starboardStations and portStations to the chart form with maxBMaxIndex
            OfsetFile.DataPoint[] portDatapoints = portStations[maxBMaxIndexPort].dataPoints.ToArray();
            OfsetFile.DataPoint[] starboardDatapoints = starboardStations[maxBMaxIndexStarboard].dataPoints.ToArray();
            foreach(OfsetFile.DataPoint dataPoint in portDatapoints.Reverse())
            {
                if(dataPoint.Y > 0)
                    chart.Series[0].Points.AddXY(-dataPoint.Y, dataPoint.Z);
                //chart.Series[0].Points.AddXY(dataPoint.Y, dataPoint.Z);
            }

            foreach (OfsetFile.DataPoint dataPoint in starboardDatapoints)
            {
                if (dataPoint.Y > 0)
                    chart.Series[0].Points.AddXY(dataPoint.Y, dataPoint.Z);
                //chart.Series[0].Points.AddXY(dataPoint.Y, dataPoint.Z);
            }
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[0].Name = "Scann";

            // Assuming chart is your Chart object
            ChartArea chartArea = chart.ChartAreas[0];

            // Get your data range
            double minX = chart.Series[0].Points.Min(point => point.XValue);
            double maxX = chart.Series[0].Points.Max(point => point.XValue);
            double minY = chart.Series[0].Points.Min(point => point.YValues[0]);
            double maxY = chart.Series[0].Points.Max(point => point.YValues[0]);

            // Calculate padding (10% of the data range)
            double paddingX = (maxX - minX) * 0.1;
            double paddingY = (maxY - minY) * 0.1;

            // Adjust the range of the X axis
            chartArea.AxisX.Minimum = minX - paddingX;
            chartArea.AxisX.Maximum = maxX + paddingX;

            // Adjust the range of the Y axis
            chartArea.AxisY.Minimum = minY - paddingY;
            chartArea.AxisY.Maximum = maxY + paddingY;
        }
    }
}
