using System;
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
        private bool bin = false;

        private int Yr;
        private int Yg;
        private int Yb;
        private int Ys;
        private double binThreshold = 0;

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
            img = new Bitmap(pictureBox.Image);
            imgStart = new Bitmap(pictureBox.Image);

            cbr = 0;
            ccn = 1;
            negative = false;
            grey = false;

            brightChart.ChartAreas[0].AxisY.Maximum = DrawBrightBarChart() + 100;


            trackBarBrightness.Value = 0;
            trackBarContrast.Value = 0;

            CountChanels();

            binThreshold = 0.299 * Yr + 0.587 * Yg + 0.114 * Yb;

            checkBoxGrey.Checked = false;
            checkBoxBin.Checked = false;    
        }

        private void CountChanels()
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
            Ys = Convert.ToInt32(Math.Round(0.299 * Yr + 0.587 * Yg + 0.114 * Yb));
        }

        private int DrawBrightBarChart()
        {
            Bitmap img_copy = (Bitmap)pictureBox.Image;

            int[] brightness = new int[256];

            for (int i = 0; i < 256; i++) 
            {
                brightness[i] = 0;
            }

            for (int y = 0; y < img_copy.Height; y++)
            {
                for (int x = 0; x < img_copy.Width; x++)
                {
                    Color pixel = img_copy.GetPixel(x, y);
                    brightness[Convert.ToInt32(Math.Round(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B))] += 1;
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

            DrawImage();

            trackBarBrightness.Value = 0;
        }

        private Color CountPixel(Color pixel)
        {
            int R = Convert.ToInt32(Math.Round(pixel.R * ccn + cbr + (1 - ccn) * Ys));
            int G = Convert.ToInt32(Math.Round(pixel.G * ccn + cbr + (1 - ccn) * Ys));
            int B = Convert.ToInt32(Math.Round(pixel.B * ccn + cbr + (1 - ccn) * Ys));

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
                if (ccn > 1 / 1000000)
                {
                    ccn /= -trackBarContrast.Value + 1;
                }
            }
            else
            {
                if (ccn < 1000000)
                {
                    ccn *= trackBarContrast.Value + 1;
                }
            }

            DrawImage();

            trackBarContrast.Value = 0;
        }

        private void ButtonNegative_Click(object sender, EventArgs e)
        {
            negative = !negative;
            DrawImage();
        }

        private void DrawImage()
        {
            Bitmap img_copy = new Bitmap(img);

            if (bin)
            {
                if (radioButton1.Checked)
                {
                    CountAveTreshold();
                }
            }

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = CountPixel(img.GetPixel(x, y));

                    if (grey || bin)
                    {
                        int brightness = Convert.ToInt32(Math.Round(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B));

                        int color;

                        if (bin)
                        {
                            if (brightness > binThreshold)
                            {
                                color = 255;
                            }
                            else
                            {
                                color = 0;
                            }
                        }
                        else
                        {
                            color = brightness;
                        }

                        color = NormalizeColor(color);

                        pixel = Color.FromArgb(pixel.A, color, color, color);
                    }

                    img_copy.SetPixel(x, y, pixel);
                }
            }

            pictureBox.Image = img_copy;
            DrawBrightBarChart();
        }

        private void CheckBoxGrey_CheckedChanged(object sender, EventArgs e)
        {
            grey = checkBoxGrey.Checked;
            DrawImage();
        }

        private void CheckBoxBin_CheckedChanged(object sender, EventArgs e)
        {
            bin = checkBoxBin.Checked;
            DrawImage();
        }

        private void TrackBarBin_ValueChanged(object sender, EventArgs e)
        {
            labelBin.Text = Convert.ToString(trackBarBin.Value);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (bin)
                    DrawImage();
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                binThreshold = trackBarBin.Value;

                if (bin)
                    DrawImage();
            }
        }

        private void TrackBarBin_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked)
            {
                binThreshold = trackBarBin.Value;

                if (bin)
                    DrawImage();
            }
        }

        private void CountAveTreshold()
        {
            double color = 0;

            Bitmap img_copy = new Bitmap(img);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = CountPixel(img.GetPixel(x, y));

                    if (grey)
                    {
                        int brightness = NormalizeColor(Convert.ToInt32(Math.Round(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B)));

                        pixel = Color.FromArgb(pixel.A, brightness, brightness, brightness);
                    }

                    img_copy.SetPixel(x, y, pixel);
                }
            }


            for (int y = 0; y < img_copy.Height; y++)
            {
                for (int x = 0; x < img_copy.Width; x++)
                {
                    Color pixel = img_copy.GetPixel(x, y);
                    color += pixel.R;
                }
            }

            color /= img.Height * img.Width;

            binThreshold = Convert.ToInt32(Math.Round(color));
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            pictureBox.Image = imgStart;
            LoadImage();
        }
    }
}
