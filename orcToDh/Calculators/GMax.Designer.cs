namespace orcToDh.Calculators
{
    partial class GMax
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            gMaxLengthLabel = new Label();
            StationInfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart.Legends.Add(legend2);
            chart.Location = new Point(12, 12);
            chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart.Series.Add(series2);
            chart.Size = new Size(776, 677);
            chart.TabIndex = 0;
            chart.Text = "chart1";
            // 
            // gMaxLengthLabel
            // 
            gMaxLengthLabel.AutoSize = true;
            gMaxLengthLabel.Location = new Point(12, 692);
            gMaxLengthLabel.Name = "gMaxLengthLabel";
            gMaxLengthLabel.Size = new Size(100, 15);
            gMaxLengthLabel.TabIndex = 1;
            gMaxLengthLabel.Text = "GMax Line length";
            // 
            // StationInfoLabel
            // 
            StationInfoLabel.AutoSize = true;
            StationInfoLabel.Location = new Point(12, 707);
            StationInfoLabel.Name = "StationInfoLabel";
            StationInfoLabel.Size = new Size(68, 15);
            StationInfoLabel.TabIndex = 5;
            StationInfoLabel.Text = "Station Info";
            // 
            // GMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 804);
            Controls.Add(StationInfoLabel);
            Controls.Add(gMaxLengthLabel);
            Controls.Add(chart);
            Name = "GMax";
            Text = "GMax";
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private Label gMaxLengthLabel;
        private Label StarboardStationLabel;
        private Label StationInfoLabel;
    }
}