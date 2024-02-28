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
            openFileButton = new Button();
            statusLable = new Label();
            bMAXButton = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(16, 17);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(75, 23);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "openFile";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // statusLable
            // 
            statusLable.AutoSize = true;
            statusLable.Location = new Point(111, 21);
            statusLable.Name = "statusLable";
            statusLable.Size = new Size(66, 15);
            statusLable.TabIndex = 1;
            statusLable.Text = "statusLable";
            // 
            // bMAXButton
            // 
            bMAXButton.Enabled = false;
            bMAXButton.Location = new Point(16, 66);
            bMAXButton.Name = "bMAXButton";
            bMAXButton.Size = new Size(75, 23);
            bMAXButton.TabIndex = 2;
            bMAXButton.Text = "Cal BMAX";
            bMAXButton.UseVisualStyleBackColor = true;
            bMAXButton.Click += bMAXButton_Click;
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bMAXButton);
            Controls.Add(statusLable);
            Controls.Add(openFileButton);
            Name = "mainPage";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button openFileButton;
        private Label statusLable;
        private Button bMAXButton;
    }
}
