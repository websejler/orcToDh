using System.Runtime.InteropServices;
using System.Text;

namespace orcToDh
{
    public partial class mainPage : Form

    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        public const string status = "Status: ";

        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            AllocConsole();
#endif
            statusLable.Text = status + "Indlæs fil for at fortsætte";
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ofset files (*.off)|*.off";
            openFileDialog.Title = "Select an ofset file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string ofsetFile = openFileDialog.FileName;

            using (StreamReader file = new(ofsetFile, new ASCIIEncoding()))
            {
                OfsetFile ofset = new OfsetFile(file);
            }
            statusLable.Text = status + "Fil indlæst, klar til beregning";
            bMAXButton.Enabled = true;
        }

        private void bMAXButton_Click(object sender, EventArgs e)
        {
            //cal BMAX
        }
    }
}
