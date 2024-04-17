using System.Runtime.InteropServices;
using System.Text;
using orcToDh.Calculators;

namespace orcToDh
{
    public partial class mainPage : Form
    {
        OpenFileDialog openFileDialog;
        OffsetFile? ofset;
        BMax? bMaxCalculator;
        GMax? gMaxCalculator;


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        public const string status = "Status: ";

        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            AllocConsole();
#endif  
            Task.Run(() =>
            {
                if (UpdateDetection.CheckForUpdate())
                {
                    MessageBox.Show("Der er en opdatering tilgængelig");
                }
            });

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ofset files (*.off)|*.off";
            openFileDialog.Title = "Select an ofset file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string ofsetFile = openFileDialog.FileName;
            bool useXML = false;
            using (StreamReader file = new(ofsetFile, new ASCIIEncoding()))
            {
                useXML = file.ReadLine().Contains("xml");
            }
            if (useXML)
            {
                ofset = OffsetFile.ParseOffsetFile(ofsetFile);
            }
            else
            {
                using (StreamReader file = new(ofsetFile, new ASCIIEncoding()))
                {
                    ofset = new OffsetFile(file);
                }
            }
            statusLable.Text = status + "Fil indlæst, klar til beregning";
                bMAXButton.Enabled = true;
                gMaxButton.Enabled = true;
                bMaxCalculator = new(ofset);
                gMaxCalculator = new(ofset);



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
        }
    }
