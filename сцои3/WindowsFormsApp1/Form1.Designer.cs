
namespace WindowsFormsApp1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NUD_Koef = new System.Windows.Forms.NumericUpDown();
            this.NUD_SizeWindow = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CB_Check = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.LSizeImg = new System.Windows.Forms.Label();
            this.LTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Koef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SizeWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(13, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 610);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(621, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(592, 610);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Загрузить картинку";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(575, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Чувствительность / усиление";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Размер окна";
            // 
            // NUD_Koef
            // 
            this.NUD_Koef.DecimalPlaces = 5;
            this.NUD_Koef.Enabled = false;
            this.NUD_Koef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_Koef.Location = new System.Drawing.Point(621, 25);
            this.NUD_Koef.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Koef.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NUD_Koef.Name = "NUD_Koef";
            this.NUD_Koef.Size = new System.Drawing.Size(70, 20);
            this.NUD_Koef.TabIndex = 30;
            this.NUD_Koef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_Koef.ValueChanged += new System.EventHandler(this.NUD_Koef_ValueChanged);
            // 
            // NUD_SizeWindow
            // 
            this.NUD_SizeWindow.Enabled = false;
            this.NUD_SizeWindow.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUD_SizeWindow.Location = new System.Drawing.Point(498, 25);
            this.NUD_SizeWindow.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_SizeWindow.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUD_SizeWindow.Name = "NUD_SizeWindow";
            this.NUD_SizeWindow.Size = new System.Drawing.Size(70, 20);
            this.NUD_SizeWindow.TabIndex = 29;
            this.NUD_SizeWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_SizeWindow.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUD_SizeWindow.ValueChanged += new System.EventHandler(this.NUD_SizeWindow_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(183, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(295, 28);
            this.comboBox1.TabIndex = 33;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CB_Check
            // 
            this.CB_Check.AutoSize = true;
            this.CB_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Check.Location = new System.Drawing.Point(750, 15);
            this.CB_Check.Name = "CB_Check";
            this.CB_Check.Size = new System.Drawing.Size(154, 24);
            this.CB_Check.TabIndex = 34;
            this.CB_Check.Text = "ч/б изображение";
            this.CB_Check.UseVisualStyleBackColor = true;
            this.CB_Check.CheckedChanged += new System.EventHandler(this.CB_GaussFilter_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(923, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 31);
            this.button2.TabIndex = 35;
            this.button2.Text = "Выполнить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LSizeImg
            // 
            this.LSizeImg.AutoSize = true;
            this.LSizeImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LSizeImg.Location = new System.Drawing.Point(12, 688);
            this.LSizeImg.Name = "LSizeImg";
            this.LSizeImg.Size = new System.Drawing.Size(239, 25);
            this.LSizeImg.TabIndex = 36;
            this.LSizeImg.Text = "Размер изображения: ";
            // 
            // LTime
            // 
            this.LTime.AutoSize = true;
            this.LTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LTime.Location = new System.Drawing.Point(616, 688);
            this.LTime.Name = "LTime";
            this.LTime.Size = new System.Drawing.Size(199, 25);
            this.LTime.TabIndex = 37;
            this.LTime.Text = "Время обработки: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 741);
            this.Controls.Add(this.LTime);
            this.Controls.Add(this.LSizeImg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CB_Check);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NUD_Koef);
            this.Controls.Add(this.NUD_SizeWindow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Koef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SizeWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown NUD_Koef;
        public System.Windows.Forms.NumericUpDown NUD_SizeWindow;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.CheckBox CB_Check;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LSizeImg;
        private System.Windows.Forms.Label LTime;
    }
}

