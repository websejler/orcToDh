using System.Runtime.InteropServices;
using System.Text;

namespace orcToDh
{
    public partial class mainPage : Form

    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        public mainPage()
        {
            InitializeComponent();
            #if DEBUG
            AllocConsole();
            #endif
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
            Label label = new Label();
            label.Text = ofsetFile;
            label.AutoSize = true;
            label.Location = new Point(10, 60);
            this.Controls.Add(label);

            using (StreamReader file = new(ofsetFile, new ASCIIEncoding()))
            {
                OfsetFile ofset = new OfsetFile(file);
            }



        }
    }
}
