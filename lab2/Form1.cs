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

                Bitmap red = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap green = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap blue = new Bitmap(bitmap.Width, bitmap.Height);

                int[] red_hist = new int[256];
                int[] green_hist = new int[256];
                int[] blue_hist = new int[256];

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color originalColor = bitmap.GetPixel(x, y);
                        red.SetPixel(x, y, Color.FromArgb(originalColor.A, originalColor.R, 0, 0));
                        green.SetPixel(x, y, Color.FromArgb(originalColor.A, 0, originalColor.G, 0));
                        blue.SetPixel(x, y, Color.FromArgb(originalColor.A, 0, 0, originalColor.B));

                        red_hist[originalColor.R]++;
                        green_hist[originalColor.G]++;
                        blue_hist[originalColor.B]++;
                    }
                }
                Bitmap hist = CreateHistogramImage(red_hist, green_hist, blue_hist);
                ShowRGBImagesAndHistogram(red, green, blue, hist);
            }
        }

        private Bitmap CreateHistogramImage(int[] red_hist, int[] green_hist, int[] blue_hist)
        {
            int width = 256;  
            int height = 100; 

            Bitmap histogram = new Bitmap(width, height);
            int maxRed = red_hist.Max();
            int maxGreen = green_hist.Max();
            int maxBlue = blue_hist.Max();

            using (Graphics g = Graphics.FromImage(histogram))
            {
                g.Clear(Color.White);

                List<PointF> red_points = new List<PointF>();
                List<PointF> green_points = new List<PointF>();
                List<PointF> blue_points = new List<PointF>();


                for (int i = 0; i < 256; i++)
                {
                    int redHeight = height - (int)(height * red_hist[i] / (float)maxRed);
                    int greenHeight = height - (int)(height * green_hist[i] / (float)maxGreen);
                    int blueHeight = height - (int)(height * blue_hist[i] / (float)maxBlue);
                    red_points.Add(new PointF(i, redHeight));
                    green_points.Add(new PointF(i, greenHeight));
                    blue_points.Add(new PointF(i, blueHeight));
                    
                }
                g.DrawLines(Pens.Red, red_points.ToArray());
                g.DrawLines(Pens.Green, green_points.ToArray());
                g.DrawLines(Pens.Blue, blue_points.ToArray());
            }

            return histogram;
        }

        private void ShowRGBImagesAndHistogram(Bitmap redImage, Bitmap greenImage, Bitmap blueImage, Bitmap histogramImage)
        {
            Form channelsForm = new Form();
            channelsForm.Text = "RGB Channels and Histogram";
            channelsForm.Size = new Size(1600, 500); 

            PictureBox redPictureBox = new PictureBox();
            redPictureBox.Image = redImage;
            redPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox greenPictureBox = new PictureBox();
            greenPictureBox.Image = greenImage;
            greenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox bluePictureBox = new PictureBox();
            bluePictureBox.Image = blueImage;
            bluePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            PictureBox histogramPictureBox = new PictureBox();
            histogramPictureBox.Image = histogramImage;
            histogramPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            channelsForm.Controls.Add(redPictureBox);
            channelsForm.Controls.Add(greenPictureBox);
            channelsForm.Controls.Add(bluePictureBox);
            channelsForm.Controls.Add(histogramPictureBox);

            channelsForm.Resize += (s, e) =>
            {
                ResizePictureBoxes(channelsForm, redPictureBox, greenPictureBox, bluePictureBox, histogramPictureBox);
            };

            ResizePictureBoxes(channelsForm, redPictureBox, greenPictureBox, bluePictureBox, histogramPictureBox);

            channelsForm.ShowDialog();
        }

        private void ResizePictureBoxes(Form form, PictureBox redPictureBox, PictureBox greenPictureBox, PictureBox bluePictureBox, PictureBox histogramPictureBox)
        {
            int formWidth = form.ClientSize.Width;
            int formHeight = form.ClientSize.Height;

            int pictureBoxWidth = formWidth / 4;
            int pictureBoxHeight = formHeight;

            redPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            redPictureBox.Location = new Point(0, 0);

            greenPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            greenPictureBox.Location = new Point(pictureBoxWidth, 0);

            bluePictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            bluePictureBox.Location = new Point(pictureBoxWidth * 2, 0);

            histogramPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            histogramPictureBox.Location = new Point(pictureBoxWidth * 3, 0);
        }
    }
}