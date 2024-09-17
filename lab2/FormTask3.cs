using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace lab2
{
    public partial class FormTask3 : Form
    {
        private float[,,] originalImage;
        private float[,,] hsvImage;

        public FormTask3(System.Drawing.Image image)
        {
            InitializeComponent();

            Bitmap img = new Bitmap(image);

            originalImage = ConvertRGBtoHSV(img);
            hsvImage = ConvertRGBtoHSV(img);

            pictureBoxRGB.Image = image;
            pictureBoxHSV.Image = image;

            trackBar1.MouseUp += UpdateHue;
            trackBar2.MouseUp += UpdateSaturation;
            trackBar3.MouseUp += UpdateValue;

            this.Resize += new EventHandler(FormTask3_Resize);

            LayoutControls();
        }


        private void FormTask3_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }


        float[,,] ConvertRGBtoHSV(Bitmap img)
        {
            float[,,] hsvImg = new float[img.Width, img.Height, 3];
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    float hue, saturation, value;
                    RGBtoHSV(pixel, out hue, out saturation, out value);
                    hsvImg[i, j, 0] = hue;
                    hsvImg[i, j, 1] = saturation;
                    hsvImg[i, j, 2] = value;
                }
            }
            return hsvImg;
        }

        Bitmap ConvertHSVtoRGB(float[,,] hsvImg)
        {
            Bitmap rgbImg = new Bitmap(hsvImg.GetLength(0), hsvImg.GetLength(1));
            for (int i = 0; i < hsvImg.GetLength(0); i++)
            {
                for (int j = 0; j < hsvImg.GetLength(1); j++)
                {
                    rgbImg.SetPixel(i, j, HSVtoRGB(hsvImg[i, j, 0],
                        hsvImg[i, j, 1], hsvImg[i, j, 2]));
                }
            }
            return rgbImg;
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


        private void UpdateHue(object sender, EventArgs e)
        {
            float hueShift = trackBar1.Value;

            for (int i = 0; i < originalImage.GetLength(0); i++)
            {
                for (int j = 0; j < originalImage.GetLength(1); j++)
                {
                    float hue = originalImage[i, j, 0];
                    hue = (hue + hueShift) % 360;

                    hsvImage[i, j, 0] = hue;
                }
            }

            pictureBoxHSV.Image = ConvertHSVtoRGB(hsvImage);
        }


        private void UpdateSaturation(object sender, EventArgs e)
        {
            float saturationShift = trackBar2.Value / 100f;

            for (int i = 0; i < originalImage.GetLength(0); i++)
            {
                for (int j = 0; j < originalImage.GetLength(1); j++)
                {
                    float saturation = originalImage[i, j, 1];
                    saturation = Math.Max(0, Math.Min(saturation + saturationShift, 1));

                    hsvImage[i, j, 1] = saturation;
                }
            }

            pictureBoxHSV.Image = ConvertHSVtoRGB(hsvImage);
        }


        private void UpdateValue(object sender, EventArgs e)
        {
            float valueShift = trackBar3.Value / 100f;

            for (int i = 0; i < originalImage.GetLength(0); i++)
            {
                for (int j = 0; j < originalImage.GetLength(1); j++)
                {
                    float value = originalImage[i, j, 2];
                    value = Math.Max(0, Math.Min(value + valueShift, 1)); 
                    hsvImage[i, j, 2] = value;
                }
            }

            pictureBoxHSV.Image = ConvertHSVtoRGB(hsvImage);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap rgbImage = ConvertHSVtoRGB(hsvImage);
                rgbImage.Save(saveFileDialog.FileName);
            }
        }
    }

}