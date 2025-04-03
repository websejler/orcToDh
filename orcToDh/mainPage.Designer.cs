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
            fAMTextBox = new TextBox();
            fFMTextBox = new TextBox();
            label3 = new Label();
            label5 = new Label();
            dHRadioButton = new RadioButton();
            oRCRadioButton = new RadioButton();
            xFFMlabel = new Label();
            xFAMlabel = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusLable
            // 
            statusLable.AutoSize = true;
            statusLable.Location = new Point(17, 88);
            statusLable.Margin = new Padding(4, 0, 4, 0);
            statusLable.Name = "statusLable";
            statusLable.Size = new Size(100, 25);
            statusLable.TabIndex = 1;
            statusLable.Text = "statusLable";
            // 
            // bMAXButton
            // 
            bMAXButton.Enabled = false;
            bMAXButton.Location = new Point(17, 118);
            bMAXButton.Margin = new Padding(4, 5, 4, 5);
            bMAXButton.Name = "bMAXButton";
            bMAXButton.Size = new Size(121, 38);
            bMAXButton.TabIndex = 2;
            bMAXButton.Text = "Cal BMAX";
            bMAXButton.UseVisualStyleBackColor = true;
            bMAXButton.Click += bMAXButton_Click;
            // 
            // gMaxButton
            // 
            gMaxButton.Enabled = false;
            gMaxButton.Location = new Point(17, 167);
            gMaxButton.Margin = new Padding(4, 5, 4, 5);
            gMaxButton.Name = "gMaxButton";
            gMaxButton.Size = new Size(121, 38);
            gMaxButton.TabIndex = 3;
            gMaxButton.Text = "Cal GMax";
            gMaxButton.UseVisualStyleBackColor = true;
            gMaxButton.Click += gMaxButton_Click;
            // 
            // fileLable
            // 
            fileLable.AutoSize = true;
            fileLable.Location = new Point(17, 15);
            fileLable.Margin = new Padding(4, 0, 4, 0);
            fileLable.Name = "fileLable";
            fileLable.Size = new Size(130, 25);
            fileLable.TabIndex = 4;
            fileLable.Text = "File not loaded";
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(17, 45);
            loadFileButton.Margin = new Padding(4, 5, 4, 5);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(121, 38);
            loadFileButton.TabIndex = 5;
            loadFileButton.Text = "Load file";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // profileButton
            // 
            profileButton.BackgroundImageLayout = ImageLayout.Stretch;
            profileButton.Location = new Point(17, 215);
            profileButton.Margin = new Padding(4, 5, 4, 5);
            profileButton.Name = "profileButton";
            profileButton.Size = new Size(121, 38);
            profileButton.TabIndex = 6;
            profileButton.Text = "Show profile";
            profileButton.UseVisualStyleBackColor = true;
            profileButton.Click += profileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(636, 85);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 25);
            label1.TabIndex = 7;
            label1.Text = "STF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(642, 134);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 8;
            label2.Text = "AF";
            label2.Click += label2_Click;
            // 
            // sTFMesTextBox
            // 
            sTFMesTextBox.Location = new Point(684, 82);
            sTFMesTextBox.Margin = new Padding(4, 5, 4, 5);
            sTFMesTextBox.Name = "sTFMesTextBox";
            sTFMesTextBox.Size = new Size(141, 31);
            sTFMesTextBox.TabIndex = 9;
            sTFMesTextBox.Text = "0";
            sTFMesTextBox.TextChanged += textBox1_TextChanged;
            // 
            // aFMesTextBox
            // 
            aFMesTextBox.Location = new Point(684, 130);
            aFMesTextBox.Margin = new Padding(4, 5, 4, 5);
            aFMesTextBox.Name = "aFMesTextBox";
            aFMesTextBox.Size = new Size(141, 31);
            aFMesTextBox.TabIndex = 10;
            aFMesTextBox.Text = "0";
            aFMesTextBox.TextChanged += textBox2_TextChanged;
            // 
            // bowpointLable
            // 
            bowpointLable.AutoSize = true;
            bowpointLable.Location = new Point(876, 99);
            bowpointLable.Margin = new Padding(4, 0, 4, 0);
            bowpointLable.Name = "bowpointLable";
            bowpointLable.Size = new Size(107, 25);
            bowpointLable.TabIndex = 11;
            bowpointLable.Text = "Stævnpunkt";
            // 
            // xStationAFLable
            // 
            xStationAFLable.AutoSize = true;
            xStationAFLable.Location = new Point(876, 135);
            xStationAFLable.Margin = new Padding(4, 0, 4, 0);
            xStationAFLable.Name = "xStationAFLable";
            xStationAFLable.Size = new Size(101, 25);
            xStationAFLable.TabIndex = 12;
            xStationAFLable.Text = "xStation AF";
            xStationAFLable.Click += xStationAFLable_Click;
            // 
            // zStationAFlable
            // 
            zStationAFlable.AutoSize = true;
            zStationAFlable.Location = new Point(876, 169);
            zStationAFlable.Margin = new Padding(4, 0, 4, 0);
            zStationAFlable.Name = "zStationAFlable";
            zStationAFlable.Size = new Size(101, 25);
            zStationAFlable.TabIndex = 13;
            zStationAFlable.Text = "zStation AF";
            // 
            // BoG3TextBox
            // 
            BoG3TextBox.Enabled = false;
            BoG3TextBox.Location = new Point(684, 179);
            BoG3TextBox.Margin = new Padding(4, 5, 4, 5);
            BoG3TextBox.Name = "BoG3TextBox";
            BoG3TextBox.Size = new Size(141, 31);
            BoG3TextBox.TabIndex = 16;
            BoG3TextBox.Text = "0";
            BoG3TextBox.TextChanged += BoG3TextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(622, 182);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 14;
            label4.Text = "BoG3";
            label4.Click += label4_Click;
            // 
            // fAMTextBox
            // 
            fAMTextBox.Location = new Point(684, 311);
            fAMTextBox.Margin = new Padding(4, 5, 4, 5);
            fAMTextBox.Name = "fAMTextBox";
            fAMTextBox.Size = new Size(141, 31);
            fAMTextBox.TabIndex = 21;
            fAMTextBox.Text = "0";
            fAMTextBox.TextChanged += fAMTextBox_TextChanged;
            // 
            // fFMTextBox
            // 
            fFMTextBox.Location = new Point(684, 263);
            fFMTextBox.Margin = new Padding(4, 5, 4, 5);
            fFMTextBox.Name = "fFMTextBox";
            fFMTextBox.Size = new Size(141, 31);
            fFMTextBox.TabIndex = 20;
            fFMTextBox.Text = "0";
            fFMTextBox.TextChanged += fFMTextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(642, 315);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 19;
            label3.Text = "FAM";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(636, 266);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 18;
            label5.Text = "FFM";
            // 
            // dHRadioButton
            // 
            dHRadioButton.AutoSize = true;
            dHRadioButton.Checked = true;
            dHRadioButton.Location = new Point(684, 45);
            dHRadioButton.Name = "dHRadioButton";
            dHRadioButton.Size = new Size(63, 29);
            dHRadioButton.TabIndex = 22;
            dHRadioButton.TabStop = true;
            dHRadioButton.Text = "DH";
            dHRadioButton.UseVisualStyleBackColor = true;
            dHRadioButton.CheckedChanged += dHRadioButton_CheckedChanged;
            // 
            // oRCRadioButton
            // 
            oRCRadioButton.AutoSize = true;
            oRCRadioButton.Location = new Point(684, 226);
            oRCRadioButton.Name = "oRCRadioButton";
            oRCRadioButton.Size = new Size(73, 29);
            oRCRadioButton.TabIndex = 23;
            oRCRadioButton.Text = "ORC";
            oRCRadioButton.UseVisualStyleBackColor = true;
            oRCRadioButton.CheckedChanged += oRCRadioButton_CheckedChanged;
            // 
            // xFFMlabel
            // 
            xFFMlabel.AutoSize = true;
            xFFMlabel.Location = new Point(876, 269);
            xFFMlabel.Margin = new Padding(4, 0, 4, 0);
            xFFMlabel.Name = "xFFMlabel";
            xFFMlabel.Size = new Size(114, 25);
            xFFMlabel.TabIndex = 24;
            xFFMlabel.Text = "xStation FFM";
            // 
            // xFAMlabel
            // 
            xFAMlabel.AutoSize = true;
            xFAMlabel.Location = new Point(876, 317);
            xFAMlabel.Margin = new Padding(4, 0, 4, 0);
            xFAMlabel.Name = "xFAMlabel";
            xFAMlabel.Size = new Size(116, 25);
            xFAMlabel.TabIndex = 25;
            xFAMlabel.Text = "xStation FAM";
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 1205);
            Controls.Add(xFAMlabel);
            Controls.Add(xFFMlabel);
            Controls.Add(oRCRadioButton);
            Controls.Add(dHRadioButton);
            Controls.Add(fAMTextBox);
            Controls.Add(fFMTextBox);
            Controls.Add(label3);
            Controls.Add(label5);
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
            Margin = new Padding(4, 5, 4, 5);
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
        private TextBox fAMTextBox;
        private TextBox fFMTextBox;
        private Label label3;
        private Label label5;
        private RadioButton dHRadioButton;
        private RadioButton oRCRadioButton;
        private Label xFFMlabel;
        private Label xFAMlabel;
    }
}
