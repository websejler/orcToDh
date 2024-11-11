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

            loadFile();
            calculate();
        }

        public void calculate()
        {
            bMaxCalculator = new(ofset);
            gMaxCalculator = new(ofset);
            profileCalculator = new(ofset);
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
            bMaxCalculator.ShowDialog();
        }

        private void gMaxButton_Click(object sender, EventArgs e)
        {
            if (gMaxCalculator is null)
            {
                throw new Exception("gMaxCalculator is null");
            }
            gMaxCalculator.ShowDialog();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            loadFile();
            calculate();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            if(profileCalculator is null)
            {
                throw new Exception("profileCalculator is null");
            }
            profileCalculator.ShowDialog();
        }
    }
}
