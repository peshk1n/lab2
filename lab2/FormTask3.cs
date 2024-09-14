using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace lab2
{
    public partial class FormTask3 : Form
    {
        private Bitmap originalImage;


        public FormTask3(System.Drawing.Image image)
        {
            InitializeComponent();

            originalImage = new Bitmap(image);

            pictureBoxRGB.Image = originalImage;
            pictureBoxHSV.Image = originalImage;

            trackBar1.Scroll += UpdateImage;
            trackBar2.Scroll += UpdateImage;
            trackBar3.Scroll += UpdateImage;

            this.Resize += new EventHandler(FormTask3_Resize);

            LayoutControls();
        }


        private void FormTask3_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }


        private void LayoutControls()
        {
            int pictureBoxX = button1.Right + 20; 
            int pictureBoxWidth = this.ClientSize.Width - pictureBoxX - 20; 
            int pictureBoxHeight = (this.ClientSize.Height - 40) / 2; 

            pictureBoxRGB.Location = new Point(pictureBoxX, 10);
            pictureBoxRGB.Size = new Size(pictureBoxWidth, pictureBoxHeight);

            pictureBoxHSV.Location = new Point(pictureBoxX, pictureBoxRGB.Bottom + 10);
            pictureBoxHSV.Size = new Size(pictureBoxWidth, pictureBoxHeight);
        }


        public void RGBtoHSV(Color color, out float hue, out float saturation, out float value)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            value = max;  

            float delta = max - min;

            saturation = max == 0 ? 0 : delta / max;

            if (delta == 0)
                hue = 0;
            else if (max == r)
                hue = (60 * ((g - b) / delta) + 360) % 360;
            else if (max == g)
                hue = 60 * ((b - r) / delta) + 120;
            else
                hue = 60 * ((r - g) / delta) + 240;
        }


        public static Color HSVtoRGB(float hue, float saturation, float value)
        {
            float r = 0, g = 0, b = 0;

            int hi = (int)Math.Floor(hue / 60f) % 6;
            float f = hue / 60f - hi;
            float p = value * (1f - saturation);
            float q = value * (1f - f * saturation);
            float t = value * (1f - (1f - f) * saturation);

            switch (hi)
            {
                case 0:
                    r = value; g = t; b = p;
                    break;
                case 1:
                    r = q; g = value; b = p;
                    break;
                case 2:
                    r = p; g = value; b = t;
                    break;
                case 3:
                    r = p; g = q; b = value;
                    break;
                case 4:
                    r = t; g = p; b = value;
                    break;
                case 5:
                    r = value; g = p; b = q;
                    break;
            }

            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }


        private void UpdateImage(object sender, EventArgs e)
        {
            float hueShift = trackBar1.Value; 
            float saturationShift = trackBar2.Value / 100f; 
            float valueShift = trackBar3.Value / 100f; 

            Bitmap updatedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color pixel = originalImage.GetPixel(i, j);
                    float hue, saturation, value;

                    RGBtoHSV(pixel, out hue, out saturation, out value);

                    hue = (hue + hueShift) % 360;
                    saturation *= saturationShift;
                    value *= valueShift;

                    Color newPixel = HSVtoRGB(hue, saturation, value);
                    updatedImage.SetPixel(i, j, newPixel);
                }
            }

            pictureBoxHSV.Image = updatedImage; 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap rgbImage = new Bitmap(pictureBoxHSV.Image);
                rgbImage.Save(saveFileDialog.FileName);
            }
        }
    }

}
