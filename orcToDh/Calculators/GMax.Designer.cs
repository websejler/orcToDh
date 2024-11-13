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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            gMaxLengthLabel = new Label();
            StationInfoLabel = new Label();
            wLZlabel = new Label();
            fribordHoejdeLabel = new Label();
            wLBreddelabel = new Label();
            udfaldLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart.Legends.Add(legend1);
            chart.Location = new Point(12, 12);
            chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart.Series.Add(series1);
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
            // wLZlabel
            // 
            wLZlabel.AutoSize = true;
            wLZlabel.Location = new Point(12, 722);
            wLZlabel.Name = "wLZlabel";
            wLZlabel.Size = new Size(31, 15);
            wLZlabel.TabIndex = 6;
            wLZlabel.Text = "WLZ";
            // 
            // fribordHoejdeLabel
            // 
            fribordHoejdeLabel.AutoSize = true;
            fribordHoejdeLabel.Location = new Point(313, 692);
            fribordHoejdeLabel.Name = "fribordHoejdeLabel";
            fribordHoejdeLabel.Size = new Size(80, 15);
            fribordHoejdeLabel.TabIndex = 7;
            fribordHoejdeLabel.Text = "Fribord Højde";
            // 
            // wLBreddelabel
            // 
            wLBreddelabel.AutoSize = true;
            wLBreddelabel.Location = new Point(313, 707);
            wLBreddelabel.Name = "wLBreddelabel";
            wLBreddelabel.Size = new Size(64, 15);
            wLBreddelabel.TabIndex = 8;
            wLBreddelabel.Text = "WL Bredde";
            // 
            // udfaldLabel
            // 
            udfaldLabel.AutoSize = true;
            udfaldLabel.Location = new Point(313, 722);
            udfaldLabel.Name = "udfaldLabel";
            udfaldLabel.Size = new Size(42, 15);
            udfaldLabel.TabIndex = 9;
            udfaldLabel.Text = "Udfald";
            // 
            // GMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 804);
            Controls.Add(udfaldLabel);
            Controls.Add(wLBreddelabel);
            Controls.Add(fribordHoejdeLabel);
            Controls.Add(wLZlabel);
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
        private Label wLZlabel;
        private Label fribordHoejdeLabel;
        private Label wLBreddelabel;
        private Label udfaldLabel;
    }
}