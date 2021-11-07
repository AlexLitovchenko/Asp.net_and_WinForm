
namespace NatLab4
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.B_StartSpatialF = new System.Windows.Forms.Button();
            this.L_matrix = new System.Windows.Forms.Label();
            this.L_Spatial_Matrix = new System.Windows.Forms.Label();
            this.TB_Matrix = new System.Windows.Forms.TextBox();
            this.NUD_sigma = new System.Windows.Forms.NumericUpDown();
            this.CB_GaussFilter = new System.Windows.Forms.CheckBox();
            this.NUD_R = new System.Windows.Forms.NumericUpDown();
            this.L_Spatial_GausR = new System.Windows.Forms.Label();
            this.L_Spatial_GausSigma = new System.Windows.Forms.Label();
            this.NUD_T = new System.Windows.Forms.NumericUpDown();
            this.NUD_W = new System.Windows.Forms.NumericUpDown();
            this.L_Spartial_Height = new System.Windows.Forms.Label();
            this.L_Spartial_Width = new System.Windows.Forms.Label();
            this.L_Spartial_SizeMatrix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_1 = new System.Windows.Forms.Button();
            this.B_2 = new System.Windows.Forms.Button();
            this.L_Time = new System.Windows.Forms.Label();
            this.L_SizeImage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_W)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 513);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(497, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(463, 513);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // B_StartSpatialF
            // 
            this.B_StartSpatialF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_StartSpatialF.BackColor = System.Drawing.Color.LightGreen;
            this.B_StartSpatialF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_StartSpatialF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_StartSpatialF.Location = new System.Drawing.Point(1111, 12);
            this.B_StartSpatialF.Name = "B_StartSpatialF";
            this.B_StartSpatialF.Size = new System.Drawing.Size(229, 42);
            this.B_StartSpatialF.TabIndex = 9;
            this.B_StartSpatialF.Text = "Начать";
            this.B_StartSpatialF.UseVisualStyleBackColor = false;
            this.B_StartSpatialF.Click += new System.EventHandler(this.B_StartSpatialF_Click);
            // 
            // L_matrix
            // 
            this.L_matrix.AutoSize = true;
            this.L_matrix.Location = new System.Drawing.Point(1076, 394);
            this.L_matrix.Name = "L_matrix";
            this.L_matrix.Size = new System.Drawing.Size(92, 13);
            this.L_matrix.TabIndex = 38;
            this.L_matrix.Text = "Сумма матрицы:";
            // 
            // L_Spatial_Matrix
            // 
            this.L_Spatial_Matrix.AutoSize = true;
            this.L_Spatial_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Spatial_Matrix.Location = new System.Drawing.Point(1149, 89);
            this.L_Spatial_Matrix.Name = "L_Spatial_Matrix";
            this.L_Spatial_Matrix.Size = new System.Drawing.Size(143, 20);
            this.L_Spatial_Matrix.TabIndex = 32;
            this.L_Spatial_Matrix.Text = "Задайте матрицу";
            // 
            // TB_Matrix
            // 
            this.TB_Matrix.AcceptsTab = true;
            this.TB_Matrix.Enabled = false;
            this.TB_Matrix.Location = new System.Drawing.Point(1067, 120);
            this.TB_Matrix.Multiline = true;
            this.TB_Matrix.Name = "TB_Matrix";
            this.TB_Matrix.Size = new System.Drawing.Size(312, 190);
            this.TB_Matrix.TabIndex = 31;
            // 
            // NUD_sigma
            // 
            this.NUD_sigma.DecimalPlaces = 3;
            this.NUD_sigma.Location = new System.Drawing.Point(1247, 356);
            this.NUD_sigma.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_sigma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_sigma.Name = "NUD_sigma";
            this.NUD_sigma.Size = new System.Drawing.Size(70, 20);
            this.NUD_sigma.TabIndex = 37;
            this.NUD_sigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_sigma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CB_GaussFilter
            // 
            this.CB_GaussFilter.AutoSize = true;
            this.CB_GaussFilter.Location = new System.Drawing.Point(1153, 316);
            this.CB_GaussFilter.Name = "CB_GaussFilter";
            this.CB_GaussFilter.Size = new System.Drawing.Size(131, 17);
            this.CB_GaussFilter.TabIndex = 33;
            this.CB_GaussFilter.Text = "Гауссовский фильтр";
            this.CB_GaussFilter.UseVisualStyleBackColor = true;
            // 
            // NUD_R
            // 
            this.NUD_R.Location = new System.Drawing.Point(1111, 356);
            this.NUD_R.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_R.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_R.Name = "NUD_R";
            this.NUD_R.Size = new System.Drawing.Size(70, 20);
            this.NUD_R.TabIndex = 36;
            this.NUD_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_R.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // L_Spatial_GausR
            // 
            this.L_Spatial_GausR.AutoSize = true;
            this.L_Spatial_GausR.Location = new System.Drawing.Point(1125, 340);
            this.L_Spatial_GausR.Name = "L_Spatial_GausR";
            this.L_Spatial_GausR.Size = new System.Drawing.Size(43, 13);
            this.L_Spatial_GausR.TabIndex = 34;
            this.L_Spatial_GausR.Text = "Радиус";
            // 
            // L_Spatial_GausSigma
            // 
            this.L_Spatial_GausSigma.AutoSize = true;
            this.L_Spatial_GausSigma.Location = new System.Drawing.Point(1261, 340);
            this.L_Spatial_GausSigma.Name = "L_Spatial_GausSigma";
            this.L_Spatial_GausSigma.Size = new System.Drawing.Size(39, 13);
            this.L_Spatial_GausSigma.TabIndex = 35;
            this.L_Spatial_GausSigma.Text = "Сигма";
            // 
            // NUD_T
            // 
            this.NUD_T.Location = new System.Drawing.Point(1273, 554);
            this.NUD_T.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_T.Name = "NUD_T";
            this.NUD_T.Size = new System.Drawing.Size(70, 20);
            this.NUD_T.TabIndex = 43;
            this.NUD_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NUD_W
            // 
            this.NUD_W.Location = new System.Drawing.Point(1109, 554);
            this.NUD_W.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_W.Name = "NUD_W";
            this.NUD_W.Size = new System.Drawing.Size(70, 20);
            this.NUD_W.TabIndex = 42;
            this.NUD_W.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Spartial_Height
            // 
            this.L_Spartial_Height.AutoSize = true;
            this.L_Spartial_Height.Location = new System.Drawing.Point(1264, 538);
            this.L_Spartial_Height.Name = "L_Spartial_Height";
            this.L_Spartial_Height.Size = new System.Drawing.Size(88, 13);
            this.L_Spartial_Height.TabIndex = 41;
            this.L_Spartial_Height.Text = "Шаг вверх/вниз";
            // 
            // L_Spartial_Width
            // 
            this.L_Spartial_Width.AutoSize = true;
            this.L_Spartial_Width.Location = new System.Drawing.Point(1094, 538);
            this.L_Spartial_Width.Name = "L_Spartial_Width";
            this.L_Spartial_Width.Size = new System.Drawing.Size(101, 13);
            this.L_Spartial_Width.TabIndex = 40;
            this.L_Spartial_Width.Text = "Шаг влево/вправо";
            // 
            // L_Spartial_SizeMatrix
            // 
            this.L_Spartial_SizeMatrix.AutoSize = true;
            this.L_Spartial_SizeMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Spartial_SizeMatrix.Location = new System.Drawing.Point(1124, 497);
            this.L_Spartial_SizeMatrix.Name = "L_Spartial_SizeMatrix";
            this.L_Spartial_SizeMatrix.Size = new System.Drawing.Size(206, 20);
            this.L_Spartial_SizeMatrix.TabIndex = 39;
            this.L_Spartial_SizeMatrix.Text = "Задайте размер матрицы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1124, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Линейная фильтрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1131, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Медианная фильтрация";
            // 
            // B_1
            // 
            this.B_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_1.BackColor = System.Drawing.Color.LightGreen;
            this.B_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_1.Location = new System.Drawing.Point(1067, 426);
            this.B_1.Name = "B_1";
            this.B_1.Size = new System.Drawing.Size(312, 38);
            this.B_1.TabIndex = 46;
            this.B_1.Text = "Выполнить";
            this.B_1.UseVisualStyleBackColor = false;
            this.B_1.Click += new System.EventHandler(this.B_MedianFiltering_Click);
            // 
            // B_2
            // 
            this.B_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_2.BackColor = System.Drawing.Color.LightGreen;
            this.B_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_2.Location = new System.Drawing.Point(1067, 595);
            this.B_2.Name = "B_2";
            this.B_2.Size = new System.Drawing.Size(312, 38);
            this.B_2.TabIndex = 47;
            this.B_2.Text = "Выполнить";
            this.B_2.UseVisualStyleBackColor = false;
            this.B_2.Click += new System.EventHandler(this.button1_Click);
            // 
            // L_Time
            // 
            this.L_Time.AutoSize = true;
            this.L_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Time.Location = new System.Drawing.Point(12, 609);
            this.L_Time.Name = "L_Time";
            this.L_Time.Size = new System.Drawing.Size(332, 25);
            this.L_Time.TabIndex = 49;
            this.L_Time.Text = "Время обработки изображения:";
            // 
            // L_SizeImage
            // 
            this.L_SizeImage.AutoSize = true;
            this.L_SizeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_SizeImage.Location = new System.Drawing.Point(12, 569);
            this.L_SizeImage.Name = "L_SizeImage";
            this.L_SizeImage.Size = new System.Drawing.Size(233, 25);
            this.L_SizeImage.TabIndex = 48;
            this.L_SizeImage.Text = "Размер изображения:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 657);
            this.Controls.Add(this.L_Time);
            this.Controls.Add(this.L_SizeImage);
            this.Controls.Add(this.B_2);
            this.Controls.Add(this.B_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NUD_T);
            this.Controls.Add(this.NUD_W);
            this.Controls.Add(this.L_Spartial_Height);
            this.Controls.Add(this.L_Spartial_Width);
            this.Controls.Add(this.L_Spartial_SizeMatrix);
            this.Controls.Add(this.L_matrix);
            this.Controls.Add(this.L_Spatial_Matrix);
            this.Controls.Add(this.TB_Matrix);
            this.Controls.Add(this.NUD_sigma);
            this.Controls.Add(this.CB_GaussFilter);
            this.Controls.Add(this.NUD_R);
            this.Controls.Add(this.L_Spatial_GausR);
            this.Controls.Add(this.L_Spatial_GausSigma);
            this.Controls.Add(this.B_StartSpatialF);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_W)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Button B_StartSpatialF;
        internal System.Windows.Forms.Label L_matrix;
        internal System.Windows.Forms.Label L_Spatial_Matrix;
        internal System.Windows.Forms.TextBox TB_Matrix;
        internal System.Windows.Forms.NumericUpDown NUD_sigma;
        internal System.Windows.Forms.CheckBox CB_GaussFilter;
        internal System.Windows.Forms.NumericUpDown NUD_R;
        internal System.Windows.Forms.Label L_Spatial_GausR;
        internal System.Windows.Forms.Label L_Spatial_GausSigma;
        internal System.Windows.Forms.NumericUpDown NUD_T;
        internal System.Windows.Forms.NumericUpDown NUD_W;
        internal System.Windows.Forms.Label L_Spartial_Height;
        internal System.Windows.Forms.Label L_Spartial_Width;
        internal System.Windows.Forms.Label L_Spartial_SizeMatrix;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button B_1;
        internal System.Windows.Forms.Button B_2;
        internal System.Windows.Forms.Label L_Time;
        internal System.Windows.Forms.Label L_SizeImage;
    }
}

