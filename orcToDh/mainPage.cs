using System.Runtime.InteropServices;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.VisualBasic;
using orcToDh.Calculators;
using Image = iText.Layout.Element.Image;

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
            bowpointLable.Text = "Stævnpunkt: " + ofset.BowPointZ.ToString();
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

            aFMesTextBox.Text = "" + 0;
            sTFMesTextBox.Text = "" + 0;
            fFMTextBox.Text = "" + 0;
            fAMTextBox.Text = "" + 0;
            dHRadioButton.Checked = true;

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
            // Create a new instance if it's null or has been disposed
            if (bMaxCalculator == null || bMaxCalculator.IsDisposed)
            {
                bMaxCalculator = new BMax(ofset);
            }

            // Show the form and bring it to front
            bMaxCalculator.Show();
            bMaxCalculator.BringToFront();
        }

        private void gMaxButton_Click(object sender, EventArgs e)
        {
            if (gMaxCalculator == null || gMaxCalculator.IsDisposed)
            {
                gMaxCalculator = new GMax(ofset);  // create new if null or closed
            }

            gMaxCalculator.Show();
            gMaxCalculator.BringToFront();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            loadFile();
            calculate();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            // Create a new instance if it's null or has been disposed
            if (profileCalculator == null || profileCalculator.IsDisposed)
            {
                profileCalculator = new Profile(ofset);
            }

            // Show the form and bring it to front
            profileCalculator.Show();
            profileCalculator.BringToFront();
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

        private void genReport_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Indtast bådtypen:", "Indtast bådtypen", "BÅD");
            if (name == null || name.Length==0 || gMaxCalculator == null || bMaxCalculator == null || profileCalculator == null)
                return;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".pdf");

            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, pdf.GetDefaultPageSize(), false); // false = ignore margins
                    var pageSize = pdf.GetDefaultPageSize();
                    float pageWidth = pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();
                    float pageHeight = pageSize.GetHeight() - document.GetTopMargin() - document.GetBottomMargin();
                    

                    document.Add(new Paragraph("Båd type: " + name).SetFontSize(24));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("Bottom Filer: " + bottomFiletTextBox.Text));
                    document.Add(new Paragraph("Mode: " + (useDH() ? "DH" : "ORC")));
                    document.Add(new Paragraph("STF: " + sTFMesTextBox.Text));
                    document.Add(new Paragraph("AF: " + aFMesTextBox.Text));
                    document.Add(new Paragraph("BogG: " + BoG3TextBox.Text));
                    document.Add(new Paragraph("Stævnpunkt: " + ofset.BowPointZ.ToString()));
                    document.Add(new Paragraph("LOA: " + ofset.SternPointX.ToString()));
                    document.Add(new Paragraph("Z station AF: " + ofset.SternPointZ.ToString()));
                    document.Add(new Paragraph("FFM: " + fFMTextBox.Text));
                    document.Add(new Paragraph("FAM: " + fAMTextBox.Text));
                    document.Add(new Paragraph("X station FFM: " + ofset.XFFM.ToString()));
                    document.Add(new Paragraph("FFM shear: " + ofset.WLZ_FFM.ToString()));
                    document.Add(new Paragraph("X station FAM: " + ofset.XFAM.ToString()));
                    document.Add(new Paragraph("FFM shear: " + ofset.WLZ_FAM.ToString()));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("GMax").SetFontSize(18));
                    document.Add(new Paragraph(""));
                    Image chartImageGMax = new Image(gMaxCalculator.getChart()).ScaleToFit(pageWidth, pageHeight).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    document.Add(chartImageGMax);
                    document.Add(new Paragraph("Gmax: " + ofset.GMax));
                    document.Add(new Paragraph("SGmax: " + ofset.bestGmaxStation.X));
                    document.Add(new Paragraph("WLS: " + ofset.bestGmaxStation.WLZ));
                    document.Add(new Paragraph("G: " + ofset.bestGmaxStation.G));
                    document.Add(new Paragraph("Fribord: " + ofset.bestGmaxStation.FribordHoejde));
                    document.Add(new Paragraph("Udfald: " + ofset.bestGmaxStation.Udfald));
                    document.Add(new Paragraph("WLBredde (B): " + ofset.bestGmaxStation.WLBredde));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("Bmax").SetFontSize(18));
                    document.Add(new Paragraph(""));
                    Image chartImageBMax = new Image(bMaxCalculator.getChart()).ScaleToFit(pageWidth, pageHeight).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    document.Add(chartImageBMax);
                    document.Add(new Paragraph("BMax: " + (ofset.bestBMaxStation.BMax*2)));
                    document.Add(new Paragraph("SBmax: " + ofset.bestBMaxStation.X));
                    document.Add(new Paragraph("WLZ: " + ofset.bestBMaxStation.WLZ));
                    document.Add(new Paragraph("Fribord: " + ofset.bestBMaxStation.FribordHoejde));
                    document.Add(new Paragraph("Udfald: " + ofset.bestBMaxStation.Udfald));
                    document.Add(new Paragraph("WLBredde (B): " + ofset.bestBMaxStation.WLBredde));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("Profil").SetFontSize(18));
                    document.Add(new Paragraph(""));
                    Image chartImageProfil = new Image(profileCalculator.getChart()).SetRotationAngle(Math.PI / 2);
                    chartImageProfil.ScaleToFit(pageHeight, pageWidth).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    document.Add(chartImageProfil);
                    document.Add(new Paragraph("LOA: " + ofset.LOA));
                    document.Add(new Paragraph("OF: " + ofset.OF));
                    document.Add(new Paragraph("OA: " + ofset.OA));
                    document.Add(new Paragraph("L: " + ofset.L));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("Oversigt").SetFontSize(18));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("Gmax: " + ofset.GMax));
                    document.Add(new Paragraph("SGmax: " + ofset.bestGmaxStation.X));
                    document.Add(new Paragraph("FB: " + ofset.bestGmaxStation.FribordHoejde));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("BMax: " + (ofset.bestBMaxStation.BMax * 2)));
                    document.Add(new Paragraph("SBmax: " + ofset.bestBMaxStation.X));
                    document.Add(new Paragraph("UDF: " + ofset.bestBMaxStation.Udfald));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("LOA: " + ofset.LOA));
                    document.Add(new Paragraph("OF: " + ofset.OF));
                    document.Add(new Paragraph("OA: " + ofset.OA));
                    document.Add(new Paragraph(""));
                    document.Add(new Paragraph("STF: " + sTFMesTextBox.Text));
                    document.Add(new Paragraph("AF: " + aFMesTextBox.Text));
                    document.Close();
                }
            }

            MessageBox.Show("PDF generated successfully @" + filePath);
        }
    }
}
