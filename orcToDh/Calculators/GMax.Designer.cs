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
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            gLable = new Label();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
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
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(550, 707);
            trackBar1.Maximum = 5;
            trackBar1.Minimum = -5;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(226, 45);
            trackBar1.TabIndex = 10;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(658, 737);
            label1.Name = "label1";
            label1.Size = new Size(13, 15);
            label1.TabIndex = 11;
            label1.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(485, 707);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 12;
            label2.Text = "station +-";
            // 
            // gLable
            // 
            gLable.AutoSize = true;
            gLable.Location = new Point(12, 737);
            gLable.Name = "gLable";
            gLable.Size = new Size(15, 15);
            gLable.TabIndex = 13;
            gLable.Text = "G";
            // 
            // GMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 804);
            Controls.Add(gLable);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar1);
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
        private Label label1;
        private Label label2;
        private Label gLable;
    }
}