using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace orcToDh.Calculators
{
    public partial class Profile : Form
    {
        public Profile(OffsetFile offsetFile)
        {
            InitializeComponent();

            chart.Series.Clear();
            chart.Series.Add("Top");
            chart.Series.Add("Bottom");
            chart.Series.Add("Keel");

            chart.Series["Top"].ChartType = SeriesChartType.Line;
            chart.Series["Bottom"].ChartType = SeriesChartType.Line;
            chart.Series["Keel"].ChartType = SeriesChartType.Point;
            chart.Series["Keel"].Color = Color.Blue; // Optional: visually distinguish keel

            double lowX = offsetFile.stations.Min(s => s.X);
            double highX = offsetFile.stations.Max(s => s.X);
            double minZ = offsetFile.stations.Min(s => s.dataPoints.Min(p => p.Z));
            double maxZ = offsetFile.stations.Max(s => s.dataPoints.Max(p => p.Z));
            double xRange = highX - lowX;
            double zRange = maxZ - minZ;

            this.Size = new Size((int)(xRange / 8), (int)((zRange / 8) + 150));

            foreach (OffsetFile.Station station in offsetFile.stations)
            {
                double lowZ = station.dataPoints.Min(p => p.Z);
                double highZ = station.dataPoints.Max(p => p.Z);
                double x = station.X;

                // Plot bottom line
                DataPoint bottomPoint = new DataPoint(x, lowZ);
                modifyChartPoint(bottomPoint);
                chart.Series["Bottom"].Points.Add(bottomPoint);

                // Plot top line
                DataPoint topPoint = new DataPoint(x, highZ);
                modifyChartPoint(topPoint);
                chart.Series["Top"].Points.Add(topPoint);

                // Handle keel-specific logic: follow the bottom line and display points above and below negative Y values
                for (int i = 0; i < station.dataPoints.Count; i++)
                {
                    var point = station.dataPoints[i];
                    if (point.Y < 0)
                    {
                        // Add the point above (next point if exists)
                        if (i > 0)
                        {
                            var previousPoint = station.dataPoints[i - 1];
                            DataPoint keelPointAbove = new DataPoint(x, previousPoint.Z);
                            modifyChartPoint(keelPointAbove, 6);
                            chart.Series["Keel"].Points.Add(keelPointAbove);
                        }

                        // Add the point below (previous point if exists)
                        if (i < station.dataPoints.Count - 1)
                        {
                            var nextPoint = station.dataPoints[i + 1];
                            DataPoint keelPointBelow = new DataPoint(x, nextPoint.Z);
                            modifyChartPoint(keelPointBelow, 6);
                            chart.Series["Keel"].Points.Add(keelPointBelow);
                        }
                    }
                }
            }
        }

        public void modifyChartPoint(DataPoint chartPoint, int size = 8)
        {
            chartPoint.MarkerStyle = MarkerStyle.Circle;
            chartPoint.MarkerSize = size;
        }
    }
}
