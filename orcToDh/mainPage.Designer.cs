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
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 723);
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
    }
}
