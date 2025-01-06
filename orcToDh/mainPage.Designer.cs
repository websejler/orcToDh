namespace orcToDh
{
    partial class mainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            statusLable = new Label();
            bMAXButton = new Button();
            gMaxButton = new Button();
            fileLable = new Label();
            loadFileButton = new Button();
            profileButton = new Button();
            label1 = new Label();
            label2 = new Label();
            sTFMesTextBox = new TextBox();
            aFMesTextBox = new TextBox();
            bowpointLable = new Label();
            xStationAFLable = new Label();
            zStationAFlable = new Label();
            BoG3TextBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusLable
            // 
            statusLable.AutoSize = true;
            statusLable.Location = new Point(12, 53);
            statusLable.Name = "statusLable";
            statusLable.Size = new Size(66, 15);
            statusLable.TabIndex = 1;
            statusLable.Text = "statusLable";
            // 
            // bMAXButton
            // 
            bMAXButton.Enabled = false;
            bMAXButton.Location = new Point(12, 71);
            bMAXButton.Name = "bMAXButton";
            bMAXButton.Size = new Size(85, 23);
            bMAXButton.TabIndex = 2;
            bMAXButton.Text = "Cal BMAX";
            bMAXButton.UseVisualStyleBackColor = true;
            bMAXButton.Click += bMAXButton_Click;
            // 
            // gMaxButton
            // 
            gMaxButton.Enabled = false;
            gMaxButton.Location = new Point(12, 100);
            gMaxButton.Name = "gMaxButton";
            gMaxButton.Size = new Size(85, 23);
            gMaxButton.TabIndex = 3;
            gMaxButton.Text = "Cal GMax";
            gMaxButton.UseVisualStyleBackColor = true;
            gMaxButton.Click += gMaxButton_Click;
            // 
            // fileLable
            // 
            fileLable.AutoSize = true;
            fileLable.Location = new Point(12, 9);
            fileLable.Name = "fileLable";
            fileLable.Size = new Size(85, 15);
            fileLable.TabIndex = 4;
            fileLable.Text = "File not loaded";
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(12, 27);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(85, 23);
            loadFileButton.TabIndex = 5;
            loadFileButton.Text = "Load file";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // profileButton
            // 
            profileButton.BackgroundImageLayout = ImageLayout.Stretch;
            profileButton.Location = new Point(12, 129);
            profileButton.Name = "profileButton";
            profileButton.Size = new Size(85, 23);
            profileButton.TabIndex = 6;
            profileButton.Text = "Show profile";
            profileButton.UseVisualStyleBackColor = true;
            profileButton.Click += profileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(444, 35);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 7;
            label1.Text = "STF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 64);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 8;
            label2.Text = "AF";
            label2.Click += label2_Click;
            // 
            // sTFMesTextBox
            // 
            sTFMesTextBox.Location = new Point(475, 27);
            sTFMesTextBox.Name = "sTFMesTextBox";
            sTFMesTextBox.Size = new Size(100, 23);
            sTFMesTextBox.TabIndex = 9;
            sTFMesTextBox.Text = "0";
            sTFMesTextBox.TextChanged += textBox1_TextChanged;
            // 
            // aFMesTextBox
            // 
            aFMesTextBox.Location = new Point(475, 56);
            aFMesTextBox.Name = "aFMesTextBox";
            aFMesTextBox.Size = new Size(100, 23);
            aFMesTextBox.TabIndex = 10;
            aFMesTextBox.Text = "0";
            aFMesTextBox.TextChanged += textBox2_TextChanged;
            // 
            // bowpointLable
            // 
            bowpointLable.AutoSize = true;
            bowpointLable.Location = new Point(610, 37);
            bowpointLable.Name = "bowpointLable";
            bowpointLable.Size = new Size(71, 15);
            bowpointLable.TabIndex = 11;
            bowpointLable.Text = "Stævnpunkt";
            // 
            // xStationAFLable
            // 
            xStationAFLable.AutoSize = true;
            xStationAFLable.Location = new Point(610, 59);
            xStationAFLable.Name = "xStationAFLable";
            xStationAFLable.Size = new Size(67, 15);
            xStationAFLable.TabIndex = 12;
            xStationAFLable.Text = "xStation AF";
            // 
            // zStationAFlable
            // 
            zStationAFlable.AutoSize = true;
            zStationAFlable.Location = new Point(610, 79);
            zStationAFlable.Name = "zStationAFlable";
            zStationAFlable.Size = new Size(66, 15);
            zStationAFlable.TabIndex = 13;
            zStationAFlable.Text = "zStation AF";
            // 
            // BoG3TextBox
            // 
            BoG3TextBox.Location = new Point(475, 85);
            BoG3TextBox.Name = "BoG3TextBox";
            BoG3TextBox.Size = new Size(100, 23);
            BoG3TextBox.TabIndex = 16;
            BoG3TextBox.Text = "0";
            BoG3TextBox.TextChanged += BoG3TextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(434, 93);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 14;
            label4.Text = "BoG3";
            label4.Click += label4_Click;
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 723);
            Controls.Add(BoG3TextBox);
            Controls.Add(label4);
            Controls.Add(zStationAFlable);
            Controls.Add(xStationAFLable);
            Controls.Add(bowpointLable);
            Controls.Add(aFMesTextBox);
            Controls.Add(sTFMesTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(profileButton);
            Controls.Add(loadFileButton);
            Controls.Add(fileLable);
            Controls.Add(gMaxButton);
            Controls.Add(bMAXButton);
            Controls.Add(statusLable);
            Name = "mainPage";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Label statusLable;
        private Button bMAXButton;
        private Button gMaxButton;
        private Label fileLable;
        private Button loadFileButton;
        private Button profileButton;
        private Label label1;
        private Label label2;
        private TextBox sTFMesTextBox;
        private TextBox aFMesTextBox;
        private Label bowpointLable;
        private Label xStationAFLable;
        private Label zStationAFlable;
        private TextBox BoG3TextBox;
        private Label label4;
    }
}
