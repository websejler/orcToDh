namespace orcToDh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Label label = new Label();
            label.Text = "Hello, World!";
            label.Location = new Point(100, 100);
            this.Controls.Add(label);
        }
    }
}
