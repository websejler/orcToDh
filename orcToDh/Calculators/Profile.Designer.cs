﻿namespace orcToDh.Calculators
{
    partial class Profile
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
            oFlabel = new Label();
            ((System.ComponentModel.ISupportInitialize)chart).BeginInit();
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
            chart.Size = new Size(1089, 495);
            chart.TabIndex = 1;
            chart.Text = "chart1";
            // 
            // oFlabel
            // 
            oFlabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            oFlabel.AutoSize = true;
            oFlabel.Location = new Point(12, 617);
            oFlabel.Name = "oFlabel";
            oFlabel.Size = new Size(22, 15);
            oFlabel.TabIndex = 2;
            oFlabel.Text = "OF";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 641);
            Controls.Add(oFlabel);
            Controls.Add(chart);
            Name = "Profile";
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)chart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private Label oFlabel;
    }
}