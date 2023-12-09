namespace Graphics_lab5
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.brightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelContrast = new System.Windows.Forms.Label();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.buttonNegative = new System.Windows.Forms.Button();
            this.checkBoxGrey = new System.Windows.Forms.CheckBox();
            this.checkBoxBin = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelBin = new System.Windows.Forms.Label();
            this.trackBarBin = new System.Windows.Forms.TrackBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBin)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1285, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.openFileToolStripMenuItem.Text = "Открыть файл";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.saveFileToolStripMenuItem.Text = "Сохранить";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "\"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...\"";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(6, 15);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(555, 382);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // brightChart
            // 
            this.brightChart.BackColor = System.Drawing.Color.Transparent;
            this.brightChart.BackSecondaryColor = System.Drawing.Color.White;
            this.brightChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 255D;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Interval = 1000D;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.brightChart.ChartAreas.Add(chartArea1);
            this.brightChart.Location = new System.Drawing.Point(6, 19);
            this.brightChart.Name = "brightChart";
            this.brightChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "Series1";
            this.brightChart.Series.Add(series1);
            this.brightChart.Size = new System.Drawing.Size(694, 296);
            this.brightChart.TabIndex = 2;
            this.brightChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brightChart);
            this.groupBox1.Location = new System.Drawing.Point(585, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 321);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Гистограмма яркости";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 403);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изображение";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.LargeChange = 51;
            this.trackBarBrightness.Location = new System.Drawing.Point(6, 19);
            this.trackBarBrightness.Maximum = 255;
            this.trackBarBrightness.Minimum = -255;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(632, 45);
            this.trackBarBrightness.TabIndex = 4;
            this.trackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBrightness.ValueChanged += new System.EventHandler(this.TrackBarBrightness_ValueChanged);
            this.trackBarBrightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarBrightness_MouseUp);
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(644, 22);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(13, 13);
            this.labelBrightness.TabIndex = 5;
            this.labelBrightness.Text = "0";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Image Files(*.bmp)|*.bmp|Image Files(*.jpg)|*.jpg|Image Files(*.gif)|*.gif|Image " +
    "Files(*.png)|*.png|All files (*.*)|*.*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelBrightness);
            this.groupBox3.Controls.Add(this.trackBarBrightness);
            this.groupBox3.Location = new System.Drawing.Point(585, 354);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(688, 76);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Яркость";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelContrast);
            this.groupBox4.Controls.Add(this.trackBarContrast);
            this.groupBox4.Location = new System.Drawing.Point(585, 430);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(688, 76);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Контрастность";
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(644, 22);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(13, 13);
            this.labelContrast.TabIndex = 5;
            this.labelContrast.Text = "1";
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.LargeChange = 25;
            this.trackBarContrast.Location = new System.Drawing.Point(6, 19);
            this.trackBarContrast.Maximum = 99;
            this.trackBarContrast.Minimum = -99;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(632, 45);
            this.trackBarContrast.TabIndex = 4;
            this.trackBarContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarContrast.ValueChanged += new System.EventHandler(this.TrackBarContrast_ValueChanged);
            this.trackBarContrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarContrast_MouseUp);
            // 
            // buttonNegative
            // 
            this.buttonNegative.Location = new System.Drawing.Point(12, 436);
            this.buttonNegative.Name = "buttonNegative";
            this.buttonNegative.Size = new System.Drawing.Size(106, 23);
            this.buttonNegative.TabIndex = 8;
            this.buttonNegative.Text = "Негатив";
            this.buttonNegative.UseVisualStyleBackColor = true;
            this.buttonNegative.Click += new System.EventHandler(this.ButtonNegative_Click);
            // 
            // checkBoxGrey
            // 
            this.checkBoxGrey.AutoSize = true;
            this.checkBoxGrey.Location = new System.Drawing.Point(12, 465);
            this.checkBoxGrey.Name = "checkBoxGrey";
            this.checkBoxGrey.Size = new System.Drawing.Size(106, 17);
            this.checkBoxGrey.TabIndex = 10;
            this.checkBoxGrey.Text = "Оттенки серого";
            this.checkBoxGrey.UseVisualStyleBackColor = true;
            this.checkBoxGrey.CheckedChanged += new System.EventHandler(this.CheckBoxGrey_CheckedChanged);
            // 
            // checkBoxBin
            // 
            this.checkBoxBin.AutoSize = true;
            this.checkBoxBin.Location = new System.Drawing.Point(6, 10);
            this.checkBoxBin.Name = "checkBoxBin";
            this.checkBoxBin.Size = new System.Drawing.Size(93, 17);
            this.checkBoxBin.TabIndex = 12;
            this.checkBoxBin.Text = "Бинаризация";
            this.checkBoxBin.UseVisualStyleBackColor = true;
            this.checkBoxBin.CheckedChanged += new System.EventHandler(this.CheckBoxBin_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelBin);
            this.groupBox5.Controls.Add(this.trackBarBin);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.checkBoxBin);
            this.groupBox5.Location = new System.Drawing.Point(124, 430);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(455, 76);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // labelBin
            // 
            this.labelBin.AutoSize = true;
            this.labelBin.Location = new System.Drawing.Point(408, 31);
            this.labelBin.Name = "labelBin";
            this.labelBin.Size = new System.Drawing.Size(13, 13);
            this.labelBin.TabIndex = 6;
            this.labelBin.Text = "1";
            // 
            // trackBarBin
            // 
            this.trackBarBin.LargeChange = 25;
            this.trackBarBin.Location = new System.Drawing.Point(178, 28);
            this.trackBarBin.Maximum = 255;
            this.trackBarBin.Name = "trackBarBin";
            this.trackBarBin.Size = new System.Drawing.Size(225, 45);
            this.trackBarBin.TabIndex = 6;
            this.trackBarBin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBin.ValueChanged += new System.EventHandler(this.TrackBarBin_ValueChanged);
            this.trackBarBin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarBin_MouseUp);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(105, 33);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.Text = "Вручную";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(105, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(118, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Среднее значение";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1285, 512);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.checkBoxGrey);
            this.Controls.Add(this.buttonNegative);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1301, 551);
            this.MinimumSize = new System.Drawing.Size(1301, 551);
            this.Name = "mainForm";
            this.Text = "Лабораторная работа 5";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart brightChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.Button buttonNegative;
        private System.Windows.Forms.CheckBox checkBoxGrey;
        private System.Windows.Forms.CheckBox checkBoxBin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelBin;
        private System.Windows.Forms.TrackBar trackBarBin;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

