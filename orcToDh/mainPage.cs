using System.Runtime.InteropServices;
using System.Text;
using orcToDh.Calculators;

namespace orcToDh
{
    public partial class mainPage : Form
    {
        OpenFileDialog openFileDialog;
        OffsetFile ofset;
        BMax? bMaxCalculator;
        GMax? gMaxCalculator;
        Profile? profileCalculator;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        public const string status = "Status: ";
        string ofsetFilePath;

        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            AllocConsole();
#endif
#if !DEBUG
    Task.Run(() =>
    {
        if (UpdateDetection.CheckForUpdate())
        {
            MessageBox.Show("Der er en opdatering tilgængelig");
        }
    });
#endif

            this.Shown += MainPage_Shown; // Add this line

            loadFile();
            calculate();
        }

        private void MainPage_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Activate();
        }

        public void calculate()
        {
            ofset.UseDH = useDH();
            grayOutDHvsORC(ofset.UseDH);

            int aFMes;
            int sTFMes;
            int fFM;
            int fAM;
            double bottomFilter;
            try
            {
                aFMes = aFMesTextBox.Text == "" ? 0 : int.Parse(aFMesTextBox.Text);
                sTFMes = sTFMesTextBox.Text == "" ? 0 : int.Parse(sTFMesTextBox.Text);
                fFM = fFMTextBox.Text == "" ? 0 : int.Parse(fFMTextBox.Text);
                fAM = fAMTextBox.Text == "" ? 0 : int.Parse(fAMTextBox.Text);
                bottomFilter = bottomFiletTextBox.Text == "" ? 0 : Double.Parse(bottomFiletTextBox.Text);
            }
            catch (FormatException)
            {
                return;
            }
            ofset.setbottomLineFilter(bottomFilter);
            ofset.AF = aFMes;
            ofset.STF = sTFMes;
            ofset.FFM = fFM;
            ofset.FAM = fAM;
            bMaxCalculator = new(ofset);
            gMaxCalculator = new(ofset);
            profileCalculator = new(ofset);
            bowpointLable.Text = "Stævnspunkt: " + ofset.BowPointZ.ToString();
            xStationAFLable.Text = "LOA: " + ofset.SternPointX.ToString();
            zStationAFlable.Text = "Z station AF: " + ofset.SternPointZ.ToString();
            xFFMlabel.Text = "X station FFM: " + ofset.XFFM.ToString();
            xFAMlabel.Text = "X station FAM: " + ofset.XFAM.ToString();
            if (!ofset.UseDH)
            {
                xFFMlabel.Text = xFFMlabel.Text + "  -  FFM shear: " + ofset.WLZ_FFM.ToString();
                xFAMlabel.Text = xFAMlabel.Text + "  -  FAM shear: " + ofset.WLZ_FAM.ToString();
                sTFMesTextBox.Text = ofset.STF.ToString();
                aFMesTextBox.Text = ofset.AF.ToString();
            }
            BoG3TextBox.Text = ofset.BoG3.ToString();
        }

        public void loadFile()
        {
            bMAXButton.Enabled = false;
            gMaxButton.Enabled = false;
            profileButton.Enabled = false;
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ofset files (*.off)|*.off";
            openFileDialog.Title = "Select an ofset file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            ofsetFilePath = openFileDialog.FileName;
            bool useXML = false;
            using (StreamReader file = new(ofsetFilePath, new ASCIIEncoding()))
            {
                useXML = file.ReadLine().Contains("xml");
            }
            if (useXML)
            {
                ofset = OffsetFile.ParseOffsetFile(ofsetFilePath);
            }
            else
            {
                using (StreamReader file = new(ofsetFilePath, new ASCIIEncoding()))
                {
                    ofset = new OffsetFile(file);
                }
            }
            if (ofset is null)
            {
                throw new Exception("ofset is null");
            }
            statusLable.Text = status + "Fil indlæst, klar til beregning";
            bMAXButton.Enabled = true;
            gMaxButton.Enabled = true;
            profileButton.Enabled = true;
            fileLable.Text = "File: " + ofsetFilePath;
        }

        private void bMAXButton_Click(object sender, EventArgs e)
        {
            if (bMaxCalculator is null)
            {
                throw new Exception("bMaxCalculator is null");
            }
            bMaxCalculator.Show();
            bMaxCalculator = new(ofset);
        }

        private void gMaxButton_Click(object sender, EventArgs e)
        {
            if (gMaxCalculator is null)
            {
                throw new Exception("gMaxCalculator is null");
            }
            gMaxCalculator.Show();
            gMaxCalculator = new(ofset);
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            loadFile();
            calculate();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            if (profileCalculator is null)
            {
                throw new Exception("profileCalculator is null");
            }
            profileCalculator.Show();
            profileCalculator = new(ofset);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BoG3TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void xStationAFLable_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dHRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            oRCRadioButton.CheckedChanged -= oRCRadioButton_CheckedChanged;
            dHRadioButton.CheckedChanged -= dHRadioButton_CheckedChanged;
            dHRadioButton.Checked = true;
            oRCRadioButton.Checked = false;
            oRCRadioButton.CheckedChanged += oRCRadioButton_CheckedChanged;
            dHRadioButton.CheckedChanged += dHRadioButton_CheckedChanged;
            sTFMesTextBox.TextChanged += textBox1_TextChanged;
            aFMesTextBox.TextChanged += textBox2_TextChanged;
            fFMTextBox.TextChanged -= fFMTextBox_TextChanged;
            fAMTextBox.TextChanged -= fAMTextBox_TextChanged;
            calculate();
        }

        private void oRCRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            oRCRadioButton.CheckedChanged -= oRCRadioButton_CheckedChanged;
            dHRadioButton.CheckedChanged -= dHRadioButton_CheckedChanged;
            oRCRadioButton.Checked = true;
            dHRadioButton.Checked = false;
            dHRadioButton.CheckedChanged += dHRadioButton_CheckedChanged;
            oRCRadioButton.CheckedChanged += oRCRadioButton_CheckedChanged;
            sTFMesTextBox.TextChanged -= textBox1_TextChanged;
            aFMesTextBox.TextChanged -= textBox2_TextChanged;
            fFMTextBox.TextChanged += fFMTextBox_TextChanged;
            fAMTextBox.TextChanged += fAMTextBox_TextChanged;
            calculate();
        }


        public bool useDH()
        {
            if (dHRadioButton.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void grayOutDHvsORC(bool useDH)
        {

            sTFMesTextBox.Enabled = useDH;
            aFMesTextBox.Enabled = useDH;
            fFMTextBox.Enabled = !useDH;
            fAMTextBox.Enabled = !useDH;

        }

        private void fFMTextBox_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void fAMTextBox_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            calculate();
        }
    }
}
