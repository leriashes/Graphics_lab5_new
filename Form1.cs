﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Graphics_lab5
{
    public partial class mainForm : Form
    {
        private Bitmap img;
        private Bitmap imgStart;
        private int cbr;
        private double ccn;
        private bool negative = false;
        private bool grey = false;

        private int Yr;
        private int Yg;
        private int Yb;

        public mainForm()
        {
            InitializeComponent();
            LoadImage();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
                LoadImage();
            }
        }

        private void LoadImage()
        {

            imgStart = new Bitmap(pictureBox.Image);
            img = new Bitmap(pictureBox.Image);

            cbr = 0;
            ccn = 1;
            negative = false;
            grey = false;

            brightChart.ChartAreas[0].AxisY.Maximum = DrawBrightBarChart() + 100;


            trackBarBrightness.Value = 0;
            trackBarContrast.Value = 0;

            countChanels();

            checkBox1.Checked = false;
        }

        private void countChanels()
        {
            double r = 0;
            double g = 0;
            double b = 0;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = img.GetPixel(x, y);
                    r += pixel.R;
                    g += pixel.G;
                    b += pixel.B;
                }
            }

            r /= img.Height * img.Width;
            g /= img.Height * img.Width;
            b /= img.Height * img.Width;

            Yr = Convert.ToInt32(Math.Round(r));
            Yg = Convert.ToInt32(Math.Round(g));
            Yb = Convert.ToInt32(Math.Round(b));
        }

        private int DrawBrightBarChart()
        {
            Bitmap img_copy = (Bitmap)pictureBox.Image;

            int[] brightness = new int[256];

            for (int i = 0; i < 256; i++) 
            {
                brightness[i] = 0;
            }

            int[] mas = new int[16];
            int j = 0;

            for (int y = 0; y < img_copy.Height; y++)
            {
                for (int x = 0; x < img_copy.Width; x++)
                {
                    Color pixel = img_copy.GetPixel(x, y);

                    double bright = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    int res = Convert.ToInt32(Math.Round(bright));
                    mas[j] = res;
                    j++;
                    if (j >= 16)
                        j = 0;

                    brightness[res] += 1;
                }
            }

            brightChart.Series[0].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                brightChart.Series[0].Points.AddXY(i, brightness[i]);
            }

            return brightness.Max();
        }

        private void TrackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            if (negative)
                cbr -= trackBarBrightness.Value;
            else
                cbr += trackBarBrightness.Value;

            drawImage();

            trackBarBrightness.Value = 0;
        }

        private Color CountPixel(Color pixel)
        {
            int R = Convert.ToInt32(Math.Round(pixel.R * ccn + cbr + (1 - ccn) * Yr));
            int G = Convert.ToInt32(Math.Round(pixel.G * ccn + cbr + (1 - ccn) * Yg));
            int B = Convert.ToInt32(Math.Round(pixel.B * ccn + cbr + (1 - ccn) * Yb));

            if (negative)
            {
                R = 255 - R;
                G = 255 - G;
                B = 255 - B;
            }

            return Color.FromArgb(pixel.A, NormalizeColor(R), NormalizeColor(G), NormalizeColor(B));
        }

        private int NormalizeColor(int color)
        {
            if (color < 0)
            {
                color = 0;
            }
            else if (color > 255)
            {
                color = 255;
            }

            return color;
        }

        private void TrackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            labelBrightness.Text = Convert.ToString(trackBarBrightness.Value);

            if (trackBarBrightness.Value > 0)
            {
                labelBrightness.Text = "+" + labelBrightness.Text;
            }
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TrackBarContrast_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarContrast.Value;

            if (value < 0)
            {
                value = -value + 1;
            }
            else
            {
                value += 1;
            }

            labelContrast.Text = Convert.ToString(value);
            
            if (trackBarContrast.Value < 0)
            {
                labelContrast.Text = "1/" + labelContrast.Text;
            }

        }

        private void TrackBarContrast_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackBarContrast.Value < 0)
            {
                if (ccn > 1 / 255)
                {
                    ccn /= -trackBarContrast.Value + 1;
                }
            }
            else
            {
                if (ccn < 255)
                {
                    ccn *= trackBarContrast.Value + 1;
                }
            }

            drawImage();

            trackBarContrast.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            negative = !negative;
            drawImage();
        }

        private void drawImage()
        {
            Bitmap img_copy = new Bitmap(img);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = CountPixel(img.GetPixel(x, y));

                    if (grey)
                    {
                        double bright = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                        int R, G, B;
                        R = G = B = Convert.ToInt32(Math.Round(bright));

                        pixel = Color.FromArgb(pixel.A, R, G, B);
                    }

                    img_copy.SetPixel(x, y, pixel);
                }
            }

            pictureBox.Image = img_copy;
            DrawBrightBarChart();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                grey = true;

                //Bitmap img_copy = new Bitmap(img);

                //for (int y = 0; y < img.Height; y++)
                //{
                //    for (int x = 0; x < img.Width; x++)
                //    {
                //        Color pixel = img.GetPixel(x, y);

                //        double bright = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                //        int R, G, B;
                //        R = G = B = Convert.ToInt32(Math.Round(bright));

                //        pixel = Color.FromArgb(pixel.A, R, G, B);

                //        img.SetPixel(x, y, pixel);
                //    }
                //}

                //countChanels();

                //for (int y = 0; y < img.Height; y++)
                //{
                //    for (int x = 0; x < img.Width; x++)
                //    {
                //        Color pixel = img.GetPixel(x, y);

                //        img_copy.SetPixel(x, y, CountPixel(pixel));
                //    }
                //}

                //pictureBox.Image = img_copy;
                //DrawBrightBarChart();

                drawImage();
            }
            else
            {
                //img = new Bitmap(imgStart);
                //Bitmap img_copy = new Bitmap(img);

                grey = false;

                drawImage();

                //countChanels();

                //for (int y = 0; y < img.Height; y++)
                //{
                //    for (int x = 0; x < img.Width; x++)
                //    {
                //        Color pixel = img.GetPixel(x, y);

                //        img_copy.SetPixel(x, y, CountPixel(pixel));
                //    }
                //}

                //pictureBox.Image = img_copy;
                //DrawBrightBarChart();
            }
        }
    }
}
