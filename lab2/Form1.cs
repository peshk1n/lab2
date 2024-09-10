using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Image image;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(dialog.FileName);
                task1.Enabled = true;
                task2.Enabled = true;
                task3.Enabled = true;
            }
        }
    }
}