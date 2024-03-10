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
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusLable
            // 
            statusLable.AutoSize = true;
            statusLable.Location = new Point(12, 9);
            statusLable.Name = "statusLable";
            statusLable.Size = new Size(66, 15);
            statusLable.TabIndex = 1;
            statusLable.Text = "statusLable";
            // 
            // bMAXButton
            // 
            bMAXButton.Enabled = false;
            bMAXButton.Location = new Point(12, 27);
            bMAXButton.Name = "bMAXButton";
            bMAXButton.Size = new Size(75, 23);
            bMAXButton.TabIndex = 2;
            bMAXButton.Text = "Cal BMAX";
            bMAXButton.UseVisualStyleBackColor = true;
            bMAXButton.Click += bMAXButton_Click;
            // 
            // gMaxButton
            // 
            gMaxButton.Enabled = false;
            gMaxButton.Location = new Point(12, 56);
            gMaxButton.Name = "gMaxButton";
            gMaxButton.Size = new Size(75, 23);
            gMaxButton.TabIndex = 3;
            gMaxButton.Text = "Cal GMax";
            gMaxButton.UseVisualStyleBackColor = true;
            gMaxButton.Click += gMaxButton_Click;
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
