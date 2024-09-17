using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class FormTask1 : Form
    {
        private Bitmap bitmap;
        private Size initialFormSize;
        private Size initialPictureBoxSize;
        private Size initialHistSize;
        private PictureBox[] pictureBoxes = new PictureBox[5];
        private Point[] positions = new Point[5]; 
        public FormTask1(System.Drawing.Image image)
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(dif_Resize);
            if (image != null)
            {
                pictureBoxes[0] = photo;
                pictureBoxes[1] = p_gray1;
                pictureBoxes[2] = p_gray2;
                pictureBoxes[3] = difference;
                pictureBoxes[4] = histogram1;

                positions[0] = photo.Location;
                positions[1] = p_gray1.Location;
                positions[2] = p_gray2.Location;
                positions[3] = difference.Location;
                positions[4] = histogram1.Location;

                initialFormSize = this.ClientSize;
                initialPictureBoxSize = difference.Size;
                initialHistSize = histogram1.Size;

                bitmap = new Bitmap(image);
                photo.Image = bitmap;
                Bitmap gray1 = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap gray2 = new Bitmap(bitmap.Width, bitmap.Height);
                Bitmap dif = new Bitmap(bitmap.Width, bitmap.Height);

                int[] hist1 = new int[256];
                int[] hist2 = new int[256];

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color color = bitmap.GetPixel(x, y);
                        double g1 = Math.Round(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                        double g2 = Math.Round(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
                        int g3 = Math.Min(Math.Abs((int)(g1 - g2)) * 5, 255);

                        gray1.SetPixel(x, y, Color.FromArgb((int)g1, (int)g1, (int)g1));
                        gray2.SetPixel(x, y, Color.FromArgb((int)g2, (int)g2, (int)g2));
                        dif.SetPixel(x, y, Color.FromArgb(g3, g3, g3));

                        hist1[(int)g1]++;
                        hist2[(int)g2]++;
                    
                    }
                }
                p_gray1.Image = gray1;
                p_gray2.Image = gray2;
                difference.Image = dif;
                histogram1.Image = CreateHistogramImage(hist1,hist2);


            }
        }

        private void dif_Resize(object sender, EventArgs e)
        {          
            float k_width = (float)this.ClientSize.Width / initialFormSize.Width;
            float k_height = (float)this.ClientSize.Height / initialFormSize.Height;
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                int newWidth, newHeight;
                if (i < 4)
                {
                    
                     newWidth = (int)(initialPictureBoxSize.Width * k_width);
                     newHeight = (int)(initialPictureBoxSize.Height * k_height);
                }
                else
                {
                    newWidth = (int)(initialHistSize.Width * k_width);
                    newHeight = (int)(initialHistSize.Height * k_height);
                }
                int newX = (int)(positions[i].X * k_width);
                int newY = (int)(positions[i].Y * k_height);
                pictureBoxes[i].Size = new Size(newWidth, newHeight);
                pictureBoxes[i].Location = new Point(newX, newY);

                
            }

        }

        private Bitmap CreateHistogramImage(int[] hist1, int[]hist2)
        {            
            int width = 256 * 2;
            int height = 500;

            Bitmap histogram = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(histogram))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 256; i++)
                {
                    int a = height - (int)(height * hist1[i] / (float)hist1.Max());
                    int b = height - (int)(height * hist2[i] / (float)hist2.Max());
                    g.DrawLine(Pens.Red, i * 2, height, i * 2, a);
                    g.DrawLine(Pens.Green, i * 2 + 1, height, i * 2 + 1, b);
                    
                }
            }
            return histogram;
        }

    }
}
