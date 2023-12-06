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
using static System.Net.Mime.MediaTypeNames;
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
            loadImage();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
                loadImage();
            }
        }

        private void loadImage()
        {
            img = (Bitmap)pictureBox.Image;
            
            brightChart.ChartAreas[0].AxisY.Maximum = drawBrightBarChart() + 100;
        }

        private int drawBrightBarChart()
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

            return brightness.Max();
        }

        private void trackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap img_copy = new Bitmap(img);
            cbr = trackBarBrightness.Value;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = img.GetPixel(x, y);
                    img_copy.SetPixel(x, y, countPixel(pixel));
                }
            }

            pictureBox.Image = img_copy;

            drawBrightBarChart();

            //trackBarBrightness.Value = 0;
        }

        private Color countPixel(Color pixel)
        {
            return Color.FromArgb(pixel.A, countColor(pixel.R), countColor(pixel.G), countColor(pixel.B));
        }

        private int countColor(byte color)
        {
            int new_color = color * ccn + cbr;

            if (new_color < 0)
            {
                new_color = 0;
            }
            else if (new_color > 255)
            {
                new_color = 255;
            }

            return new_color;
        }

        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            labelBrightness.Text = Convert.ToString(trackBarBrightness.Value);

            if (trackBarBrightness.Value > 0)
            {
                labelBrightness.Text = "+" + labelBrightness.Text;
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
