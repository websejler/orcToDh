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
            chart.Series["Top"].ChartType = SeriesChartType.Line;
            chart.Series["Bottom"].ChartType = SeriesChartType.Line;
            double lowX = offsetFile.stations.Min(s => s.X);
            double highX = offsetFile.stations.Max(s => s.X);
            double minZ = offsetFile.stations.Min(s => s.dataPoints.Min(p => p.Z));
            double maxZ = offsetFile.stations.Max(s => s.dataPoints.Max(p => p.Z));
            double xRange = highX - lowX;
            double zRange = maxZ - minZ;
            this.Size = new Size((int)(xRange / 8), (int)((zRange / 8)+150));
            foreach (OffsetFile.Station station in offsetFile.stations)
            {
                double lowZ = station.dataPoints.Min(p => p.Z);
                double highZ = station.dataPoints.Max(p => p.Z);
                double x = station.X;
                DataPoint chartPoint = new DataPoint(x, lowZ);
                modifyCharPoint(chartPoint);
                chart.Series["Bottom"].Points.Add(chartPoint);
                chartPoint = new DataPoint(x, highZ);
                modifyCharPoint(chartPoint);
                chart.Series["Top"].Points.Add(chartPoint);
            }
        }

        public void modifyCharPoint(DataPoint chartPoint)
        {
            chartPoint.MarkerStyle = MarkerStyle.Circle;
            chartPoint.MarkerSize = 8;
        }
    }
}
