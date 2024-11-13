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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            BMaxLabel = new Label();
            PortStationLabel = new Label();
            wlZlabel = new Label();
            udfaldLabel = new Label();
            wLBreddelabel = new Label();
            fribordHoejdeLabel = new Label();
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
            chart.Size = new Size(776, 576);
            chart.TabIndex = 0;
            chart.Text = "chart1";
            // 
            // BMaxLabel
            // 
            BMaxLabel.AutoSize = true;
            BMaxLabel.Location = new Point(12, 591);
            BMaxLabel.Name = "BMaxLabel";
            BMaxLabel.Size = new Size(59, 15);
            BMaxLabel.TabIndex = 1;
            BMaxLabel.Text = "BMax size";
            // 
            // PortStationLabel
            // 
            PortStationLabel.AutoSize = true;
            PortStationLabel.Location = new Point(12, 606);
            PortStationLabel.Name = "PortStationLabel";
            PortStationLabel.Size = new Size(69, 15);
            PortStationLabel.TabIndex = 3;
            PortStationLabel.Text = "Port Station";
            // 
            // wlZlabel
            // 
            wlZlabel.AutoSize = true;
            wlZlabel.Location = new Point(12, 621);
            wlZlabel.Name = "wlZlabel";
            wlZlabel.Size = new Size(31, 15);
            wlZlabel.TabIndex = 4;
            wlZlabel.Text = "WLZ";
            // 
            // udfaldLabel
            // 
            udfaldLabel.AutoSize = true;
            udfaldLabel.Location = new Point(356, 621);
            udfaldLabel.Name = "udfaldLabel";
            udfaldLabel.Size = new Size(42, 15);
            udfaldLabel.TabIndex = 12;
            udfaldLabel.Text = "Udfald";
            // 
            // wLBreddelabel
            // 
            wLBreddelabel.AutoSize = true;
            wLBreddelabel.Location = new Point(356, 606);
            wLBreddelabel.Name = "wLBreddelabel";
            wLBreddelabel.Size = new Size(64, 15);
            wLBreddelabel.TabIndex = 11;
            wLBreddelabel.Text = "WL Bredde";
            // 
            // fribordHoejdeLabel
            // 
            fribordHoejdeLabel.AutoSize = true;
            fribordHoejdeLabel.Location = new Point(356, 591);
            fribordHoejdeLabel.Name = "fribordHoejdeLabel";
            fribordHoejdeLabel.Size = new Size(80, 15);
            fribordHoejdeLabel.TabIndex = 10;
            fribordHoejdeLabel.Text = "Fribord Højde";
            // 
            // BMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 702);
            Controls.Add(udfaldLabel);
            Controls.Add(wLBreddelabel);
            Controls.Add(fribordHoejdeLabel);
            Controls.Add(wlZlabel);
            Controls.Add(PortStationLabel);
            Controls.Add(BMaxLabel);
            Controls.Add(chart);
            Name = "BMax";
            Text = "BMax";
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
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
    }
}