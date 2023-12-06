using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphics_lab5
{
    public partial class mainForm : Form
    {
        private Bitmap img;
        private int cbr = 0;
        private int ccn = 1;

        public mainForm()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                //using (StreamReader reader = new StreamReader(fileStream))
                //{
                //	fileContent = reader.ReadToEnd();
                //}

                pictureBox.Image = new Bitmap(openFileDialog.FileName);
                img = (Bitmap)pictureBox.Image;

                drawBrightBarChart();
            }
        }

        private void drawBrightBarChart()
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

                    double bright = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
                    int res = Convert.ToInt32(Math.Round(bright));

                    brightness[res] += 1;
                }
            }

            brightChart.Series[0].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                brightChart.Series[0].Points.AddXY(i, brightness[i]);
            }
        }

        private void trackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap img_copy = new Bitmap(img);
            cbr += trackBarBrightness.Value;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = img.GetPixel(x, y);

                    int R, G, B;

                    R = pixel.R * ccn + cbr;

                    if (R < 0)
                    {
                        R = 0;
                    }
                    else if (R > 255)
                    {
                        R = 255;
                    }

                    G = pixel.G * ccn + cbr;

                    if (G < 0)
                    {
                        G = 0;
                    }
                    else if (G > 255)
                    {
                        G = 255;
                    }

                    B = pixel.B * ccn + cbr;

                    if (B < 0)
                    {
                        B = 0;
                    }
                    else if (B > 255)
                    {
                        B = 255;
                    }

                    img_copy.SetPixel(x, y, Color.FromArgb(pixel.A, R, G, B));
                }
            }

            pictureBox.Image = img_copy;

            drawBrightBarChart();

            trackBarBrightness.Value = 0;
        }

        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            labelBrightness.Text = Convert.ToString(trackBarBrightness.Value);

            if (trackBarBrightness.Value > 0)
            {
                labelBrightness.Text = "+" + labelBrightness.Text;
            }
        }
    }
}
