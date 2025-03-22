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
            wLZlabel = new Label();
            fribordHoejdeLabel = new Label();
            wLBreddelabel = new Label();
            udfaldLabel = new Label();
            trackBar1 = new TrackBar();
            trackBarLabel = new Label();
            label2 = new Label();
            gLable = new Label();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart.Legends.Add(legend2);
            chart.Location = new Point(17, 20);
            chart.Margin = new Padding(4, 5, 4, 5);
            chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart.Series.Add(series2);
            chart.Size = new Size(1109, 1128);
            chart.TabIndex = 0;
            chart.Text = "chart1";
            // 
            // gMaxLengthLabel
            // 
            gMaxLengthLabel.AutoSize = true;
            gMaxLengthLabel.Location = new Point(17, 1153);
            gMaxLengthLabel.Margin = new Padding(4, 0, 4, 0);
            gMaxLengthLabel.Name = "gMaxLengthLabel";
            gMaxLengthLabel.Size = new Size(148, 25);
            gMaxLengthLabel.TabIndex = 1;
            gMaxLengthLabel.Text = "GMax Line length";
            // 
            // StationInfoLabel
            // 
            StationInfoLabel.AutoSize = true;
            StationInfoLabel.Location = new Point(17, 1178);
            StationInfoLabel.Margin = new Padding(4, 0, 4, 0);
            StationInfoLabel.Name = "StationInfoLabel";
            StationInfoLabel.Size = new Size(104, 25);
            StationInfoLabel.TabIndex = 5;
            StationInfoLabel.Text = "Station Info";
            // 
            // wLZlabel
            // 
            wLZlabel.AutoSize = true;
            wLZlabel.Location = new Point(17, 1203);
            wLZlabel.Margin = new Padding(4, 0, 4, 0);
            wLZlabel.Name = "wLZlabel";
            wLZlabel.Size = new Size(48, 25);
            wLZlabel.TabIndex = 6;
            wLZlabel.Text = "WLZ";
            // 
            // fribordHoejdeLabel
            // 
            fribordHoejdeLabel.AutoSize = true;
            fribordHoejdeLabel.Location = new Point(447, 1153);
            fribordHoejdeLabel.Margin = new Padding(4, 0, 4, 0);
            fribordHoejdeLabel.Name = "fribordHoejdeLabel";
            fribordHoejdeLabel.Size = new Size(123, 25);
            fribordHoejdeLabel.TabIndex = 7;
            fribordHoejdeLabel.Text = "Fribord Højde";
            // 
            // wLBreddelabel
            // 
            wLBreddelabel.AutoSize = true;
            wLBreddelabel.Location = new Point(447, 1178);
            wLBreddelabel.Margin = new Padding(4, 0, 4, 0);
            wLBreddelabel.Name = "wLBreddelabel";
            wLBreddelabel.Size = new Size(98, 25);
            wLBreddelabel.TabIndex = 8;
            wLBreddelabel.Text = "WL Bredde";
            // 
            // udfaldLabel
            // 
            udfaldLabel.AutoSize = true;
            udfaldLabel.Location = new Point(447, 1203);
            udfaldLabel.Margin = new Padding(4, 0, 4, 0);
            udfaldLabel.Name = "udfaldLabel";
            udfaldLabel.Size = new Size(65, 25);
            udfaldLabel.TabIndex = 9;
            udfaldLabel.Text = "Udfald";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(786, 1178);
            trackBar1.Margin = new Padding(4, 5, 4, 5);
            trackBar1.Maximum = 5;
            trackBar1.Minimum = -5;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(323, 69);
            trackBar1.TabIndex = 10;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // trackBarLabel
            // 
            trackBarLabel.AutoSize = true;
            trackBarLabel.Location = new Point(940, 1228);
            trackBarLabel.Margin = new Padding(4, 0, 4, 0);
            trackBarLabel.Name = "trackBarLabel";
            trackBarLabel.Size = new Size(22, 25);
            trackBarLabel.TabIndex = 11;
            trackBarLabel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(693, 1178);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 12;
            label2.Text = "station +-";
            // 
            // gLable
            // 
            gLable.AutoSize = true;
            gLable.Location = new Point(17, 1228);
            gLable.Margin = new Padding(4, 0, 4, 0);
            gLable.Name = "gLable";
            gLable.Size = new Size(24, 25);
            gLable.TabIndex = 13;
            gLable.Text = "G";
            // 
            // GMax
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 1340);
            Controls.Add(gLable);
            Controls.Add(label2);
            Controls.Add(trackBarLabel);
            Controls.Add(trackBar1);
            Controls.Add(udfaldLabel);
            Controls.Add(wLBreddelabel);
            Controls.Add(fribordHoejdeLabel);
            Controls.Add(wLZlabel);
            Controls.Add(StationInfoLabel);
            Controls.Add(gMaxLengthLabel);
            Controls.Add(chart);
            Margin = new Padding(4, 5, 4, 5);
            Name = "GMax";
            Text = "GMax";
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
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
        private TrackBar trackBar1;
        private Label trackBarLabel;
        private Label label2;
        private Label gLable;
    }
}