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

                drawBrightBarChart();
            }
        }

        private void drawBrightBarChart()
        {
            Bitmap img = (Bitmap)pictureBox.Image;

            int[] brightness = new int[256];

            for (int i = 0; i < 256; i++) 
            {
                brightness[i] = 0;
            }

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixel = img.GetPixel(x, y);

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
    }
}
