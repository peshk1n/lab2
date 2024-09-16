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

        private void task2_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap bitmap = new Bitmap(image);

                Bitmap red_image = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap green_image = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap blue_image = new Bitmap(bitmap.Width, bitmap.Height);

                int[] red_hist = new int[256];
                int[] green_hist = new int[256];
                int[] blue_hist = new int[256];

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);
                        red_image.SetPixel(x, y, Color.FromArgb(originalColor.A, originalColor.R, 0, 0));
                        green_image.SetPixel(x, y, Color.FromArgb(originalColor.A, 0, originalColor.G, 0));
                        blue_image.SetPixel(x, y, Color.FromArgb(originalColor.A, 0, 0, originalColor.B));

                        red_hist[originalColor.R]++;
                        green_hist[originalColor.G]++;
                        blue_hist[originalColor.B]++;
                    }
                }
                Bitmap hist = CreateHistogramImage(red_hist, green_hist, blue_hist);
                ShowRGBImagesAndHistogram(red_image, green_image, blue_image, hist);
            }
        }

        private Bitmap CreateHistogramImage(int[] red_hist, int[] green_hist, int[] blue_hist)
        {
            int width = 256 * 3; 
            int height = 100;

            Bitmap histogram = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(histogram))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 256; i++)
                {
                    int hr = height - (int)(height * red_hist[i] / (float)red_hist.Max());
                    int hg = height - (int)(height * green_hist[i] / (float)green_hist.Max());
                    int hb = height - (int)(height * blue_hist[i] / (float)blue_hist.Max());
                    g.DrawLine(Pens.Red, i * 3, height, i * 3, hr);
                    g.DrawLine(Pens.Green, i * 3 + 1, height, i * 3 + 1, hg);
                    g.DrawLine(Pens.Blue, i * 3 + 2, height, i * 3 + 2, hb);
                }
            }
            return histogram;
        }

        private void ShowRGBImagesAndHistogram(Bitmap redImage, Bitmap greenImage, Bitmap blueImage, Bitmap histogramImage)
        {
            Form channelsForm = new Form();
            channelsForm.Text = "RGB Channels and Histogram";
            channelsForm.Size = new Size(1600, 800);

            Panel imagesPanel = new Panel();
            Panel histogramPanel = new Panel();

            imagesPanel.Dock = DockStyle.Top;
            histogramPanel.Dock = DockStyle.Bottom;

            imagesPanel.Height = channelsForm.ClientSize.Height * 2 / 3; 
            histogramPanel.Height = channelsForm.ClientSize.Height / 3;  

            PictureBox redPictureBox = new PictureBox();
            redPictureBox.Image = redImage;
            redPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox greenPictureBox = new PictureBox();
            greenPictureBox.Image = greenImage;
            greenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox bluePictureBox = new PictureBox();
            bluePictureBox.Image = blueImage;
            bluePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            imagesPanel.Controls.Add(redPictureBox);
            imagesPanel.Controls.Add(greenPictureBox);
            imagesPanel.Controls.Add(bluePictureBox);

            PictureBox histogramPictureBox = new PictureBox();
            histogramPictureBox.Image = histogramImage;
            histogramPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            histogramPanel.Controls.Add(histogramPictureBox);

            channelsForm.Controls.Add(imagesPanel);
            channelsForm.Controls.Add(histogramPanel);

            channelsForm.Resize += (s, e) =>
            {
                ResizeComponents(channelsForm, imagesPanel, histogramPanel, redPictureBox, greenPictureBox, bluePictureBox, histogramPictureBox);
            };

            ResizeComponents(channelsForm, imagesPanel, histogramPanel, redPictureBox, greenPictureBox, bluePictureBox, histogramPictureBox);

            channelsForm.ShowDialog();
        }

        private void ResizeComponents(Form form, Panel imagesPanel, Panel histogramPanel, PictureBox redPictureBox, PictureBox greenPictureBox, PictureBox bluePictureBox, PictureBox histogramPictureBox)
        {
            int formWidth = form.ClientSize.Width;
            int imagesPanelHeight = form.ClientSize.Height * 2 / 3;
            int histogramPanelHeight = form.ClientSize.Height / 3;

            imagesPanel.Height = imagesPanelHeight;
            histogramPanel.Height = histogramPanelHeight;

            int pictureBoxWidth = formWidth / 3;
            redPictureBox.Size = new Size(pictureBoxWidth, imagesPanelHeight);
            greenPictureBox.Size = new Size(pictureBoxWidth, imagesPanelHeight);
            bluePictureBox.Size = new Size(pictureBoxWidth, imagesPanelHeight);

            redPictureBox.Location = new Point(0, 0);
            greenPictureBox.Location = new Point(pictureBoxWidth, 0);
            bluePictureBox.Location = new Point(pictureBoxWidth * 2, 0);

            histogramPictureBox.Size = new Size(formWidth, histogramPanelHeight);
        }


        private void task3_Click(object sender, EventArgs e)
        {
            FormTask3 form = new FormTask3(image);
            form.ShowDialog();
        }
    }
}