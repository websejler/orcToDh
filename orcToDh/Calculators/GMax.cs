
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
            DrawChart();
        }

        private void DrawChart()
        {
            List<OfsetFile.Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();

            chart.Series.Clear();
            chart.Series.Add("PortLine");
            chart.Series.Add("GMaxLine");

            chart.Series["PortLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            int i = 0;
            foreach (OfsetFile.DataPoint datePoint in portStations[9].dataPoints)
            {
                var chartPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(datePoint.Y, datePoint.Z);
                chartPoint1.MarkerStyle = MarkerStyle.Circle;
                chartPoint1.MarkerSize = 5;
                chartPoint1.MarkerColor = Color.Red;
                chartPoint1.Label = i.ToString();
                i++;
                chart.Series["PortLine"].Points.Add(chartPoint1);
            }

            double gradient = double.MaxValue;
            int indexOfLowestGradient = -1;


            chart.Series["GMaxLine"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            var chartPoint = chart.Series["PortLine"].Points[0];
            //chartPoint.Label = "x: " + chartPoint.XValue + " y: " + chartPoint.YValues[0];
            chartPoint.MarkerColor = Color.Blue;
            chart.Series["GMaxLine"].Points.Add(chartPoint);

            for (i = 0; i < portStations[9].dataPoints.Count; i++)
            {
                double currentGradient = double.MaxValue;
                int currentGradientIndex = -1;
                int j = i + 1;
                for (; j < chart.Series["PortLine"].Points.Count; j++)
                {
                    double tempGradient = (chart.Series["PortLine"].Points[j].YValues[0] - chart.Series["PortLine"].Points[i].YValues[0]) / (chart.Series["PortLine"].Points[j].XValue - chart.Series["PortLine"].Points[i].XValue);
                    
                    if(chart.Series["PortLine"].Points[i].XValue > chart.Series["PortLine"].Points[j].XValue)
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
                    chartPoint = chart.Series["PortLine"].Points[currentGradientIndex];
                    //chartPoint.Label = "x: " + chartPoint.XValue + " y: " + chartPoint.YValues[0];
                    chartPoint.MarkerColor = Color.Blue;
                    chart.Series["GMaxLine"].Points.Add(chartPoint);
                }

            }

        }
    }
}
