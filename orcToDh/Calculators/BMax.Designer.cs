namespace orcToDh.Calculators
{
    partial class BMax
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
            BMaxLabel = new Label();
            PortStationLabel = new Label();
            wlZlabel = new Label();
            udfaldLabel = new Label();
            wLBreddelabel = new Label();
            fribordHoejdeLabel = new Label();
            label2 = new Label();
            trackBarLabel = new Label();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // chart
            // 
            chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            chart.Size = new Size(776, 291);
            chart.TabIndex = 0;
            chart.Text = "chart1";
            // 
            // BMaxLabel
            // 
            BMaxLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BMaxLabel.AutoSize = true;
            BMaxLabel.Location = new Point(9, 305);
            BMaxLabel.Name = "BMaxLabel";
            BMaxLabel.Size = new Size(59, 15);
            BMaxLabel.TabIndex = 1;
            BMaxLabel.Text = "BMax size";
            // 
            // PortStationLabel
            // 
            PortStationLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PortStationLabel.AutoSize = true;
            PortStationLabel.Location = new Point(9, 320);
            PortStationLabel.Name = "PortStationLabel";
            PortStationLabel.Size = new Size(69, 15);
            PortStationLabel.TabIndex = 3;
            PortStationLabel.Text = "Port Station";
            // 
            // wlZlabel
            // 
            wlZlabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            wlZlabel.AutoSize = true;
            wlZlabel.Location = new Point(9, 335);
            wlZlabel.Name = "wlZlabel";
            wlZlabel.Size = new Size(31, 15);
            wlZlabel.TabIndex = 4;
            wlZlabel.Text = "WLZ";
            // 
            // udfaldLabel
            // 
            udfaldLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            udfaldLabel.AutoSize = true;
            udfaldLabel.Location = new Point(353, 335);
            udfaldLabel.Name = "udfaldLabel";
            udfaldLabel.Size = new Size(42, 15);
            udfaldLabel.TabIndex = 12;
            udfaldLabel.Text = "Udfald";
            // 
            // wLBreddelabel
            // 
            wLBreddelabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            wLBreddelabel.AutoSize = true;
            wLBreddelabel.Location = new Point(353, 320);
            wLBreddelabel.Name = "wLBreddelabel";
            wLBreddelabel.Size = new Size(64, 15);
            wLBreddelabel.TabIndex = 11;
            wLBreddelabel.Text = "WL Bredde";
            // 
            // fribordHoejdeLabel
            // 
            fribordHoejdeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fribordHoejdeLabel.AutoSize = true;
            fribordHoejdeLabel.Location = new Point(353, 305);
            fribordHoejdeLabel.Name = "fribordHoejdeLabel";
            fribordHoejdeLabel.Size = new Size(80, 15);
            fribordHoejdeLabel.TabIndex = 10;
            fribordHoejdeLabel.Text = "Fribord Højde";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(497, 309);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 15;
            label2.Text = "station +-";
            // 
            // trackBarLabel
            // 
            trackBarLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trackBarLabel.AutoSize = true;
            trackBarLabel.Location = new Point(670, 339);
            trackBarLabel.Name = "trackBarLabel";
            trackBarLabel.Size = new Size(13, 15);
            trackBarLabel.TabIndex = 14;
            trackBarLabel.Text = "0";
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(562, 309);
            trackBar1.Maximum = 5;
            trackBar1.Minimum = -5;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(226, 45);
            trackBar1.TabIndex = 13;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // BMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 361);
            Controls.Add(label2);
            Controls.Add(trackBarLabel);
            Controls.Add(trackBar1);
            Controls.Add(udfaldLabel);
            Controls.Add(wLBreddelabel);
            Controls.Add(fribordHoejdeLabel);
            Controls.Add(wlZlabel);
            Controls.Add(PortStationLabel);
            Controls.Add(BMaxLabel);
            Controls.Add(chart);
            MinimumSize = new Size(816, 400);
            Name = "BMax";
            Text = "BMax";
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private Label BMaxLabel;
        private Label PortStationLabel;
        private Label wlZlabel;
        private Label udfaldLabel;
        private Label wLBreddelabel;
        private Label fribordHoejdeLabel;
        private Label label2;
        private Label trackBarLabel;
        private TrackBar trackBar1;
    }
}