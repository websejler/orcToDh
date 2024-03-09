using System.Runtime.InteropServices;
using System.Text;
using orcToDh.Calculators;

namespace orcToDh
{
    public partial class mainPage : Form
    {
        OpenFileDialog openFileDialog;
        OfsetFile? ofset;
        BMax? bMaxCalculator;


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        public const string status = "Status: ";

        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            AllocConsole();
#endif  
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ofset files (*.off)|*.off";
            openFileDialog.Title = "Select an ofset file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string ofsetFile = openFileDialog.FileName;
            using (StreamReader file = new(ofsetFile, new ASCIIEncoding()))
            {
                ofset = new OfsetFile(file);
            }
            statusLable.Text = status + "Fil indlæst, klar til beregning";
            bMAXButton.Enabled = true;
            bMaxCalculator = new(ofset);
        }

        private void bMAXButton_Click(object sender, EventArgs e)
        {
            if (bMaxCalculator is null)
            {
                throw new Exception("bMaxCalculator is null");
            }
            bMaxCalculator.ShowDialog();
        }
    }
}
