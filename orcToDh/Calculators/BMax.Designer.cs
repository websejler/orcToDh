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
            // BMax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 702);
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
    }
}