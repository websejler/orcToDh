using System;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using static orcToDh.OffsetFile;

namespace orcToDh.Calculators
{
    public partial class BMax : Form
    {
        OffsetFile ofsetFile;
        public double bMax = 0.0;

        public BMax(OffsetFile ofsetFile)
        {
            InitializeComponent();
            this.ofsetFile = ofsetFile;
            DrawChart();
        }

        private void DrawChart()
        {
            double bestBMax = ofsetFile.BMax;
            Station bestBMaxStation = ofsetFile.bestBMaxStation;
            List<OffsetFile.DataPoint> bestBMaxDataPoints = ofsetFile.bestBMaxDataPoints;
            double bestBMaxHight = bestBMaxStation.BMaxZ;



            chart.Series.Clear();
            chart.Series.Add(new Series("Scann Port"));
            chart.Series.Add(new Series("Scann Starboard"));
            chart.Series.Add(new Series("BMax"));
            chart.Series.Add(new Series("VandLinje"));

            // map the datapoints in starboardStations and portStations to the chart form with maxBMaxIndex
            foreach (OffsetFile.DataPoint dataPoint in bestBMaxDataPoints.ToArray().Reverse())
            {
                if (dataPoint.Y > 0)
                    chart.Series[0].Points.AddXY(-dataPoint.Y, dataPoint.Z);
            }

            foreach (OffsetFile.DataPoint dataPoint in bestBMaxDataPoints.ToArray())
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
            PortStationLabel.Text = bestBMaxStation.SID.ToString() + " station: - x: " + bestBMaxStation.X;
            wlZlabel.Text = "WLZ: " + bestBMaxStation.WLZ;
            fribordHoejdeLabel.Text = "Fribord: " + bestBMaxStation.FribordHoejde;
            wLBreddelabel.Text = "WLBredde: " + bestBMaxStation.WLBredde;
            udfaldLabel.Text = "Udfald: " + bestBMaxStation.Udfald;

            //display a horizontal line at the waterline, in the fulle width of the chart
            chart.Series["VandLinje"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["VandLinje"].Points.AddXY(bestBMaxStation.WLBredde/2 - 150, bestBMaxStation.WLZ);
            chart.Series["VandLinje"].Points.AddXY(bestBMaxStation.WLBredde/2 + 150, bestBMaxStation.WLZ);
        }
    }
}
