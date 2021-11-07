
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
            this.PB_Orig = new System.Windows.Forms.PictureBox();
            this.PB_Freq = new System.Windows.Forms.PictureBox();
            this.SizeImageOrig = new System.Windows.Forms.Label();
            this.SizeImageFreq = new System.Windows.Forms.Label();
            this.SizeImageFurier = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PB_Furier = new System.Windows.Forms.PictureBox();
            this.PB_Result = new System.Windows.Forms.PictureBox();
            this.SizeImageResult = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.FilterParam = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.FreqY = new System.Windows.Forms.Label();
            this.FreqX = new System.Windows.Forms.Label();
            this.L_Frequency_FilterArea = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.L_Frequency_Factor = new System.Windows.Forms.Label();
            this.FilterTrue = new System.Windows.Forms.TextBox();
            this.FilterFalse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Orig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Freq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Furier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Orig
            // 
            this.PB_Orig.Location = new System.Drawing.Point(24, 32);
            this.PB_Orig.Name = "PB_Orig";
            this.PB_Orig.Size = new System.Drawing.Size(298, 256);
            this.PB_Orig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Orig.TabIndex = 0;
            this.PB_Orig.TabStop = false;
            // 
            // PB_Freq
            // 
            this.PB_Freq.Location = new System.Drawing.Point(357, 32);
            this.PB_Freq.Name = "PB_Freq";
            this.PB_Freq.Size = new System.Drawing.Size(298, 256);
            this.PB_Freq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Freq.TabIndex = 1;
            this.PB_Freq.TabStop = false;
            // 
            // SizeImageOrig
            // 
            this.SizeImageOrig.AutoSize = true;
            this.SizeImageOrig.Location = new System.Drawing.Point(21, 291);
            this.SizeImageOrig.Name = "SizeImageOrig";
            this.SizeImageOrig.Size = new System.Drawing.Size(120, 13);
            this.SizeImageOrig.TabIndex = 3;
            this.SizeImageOrig.Text = "Размер изображения:";
            // 
            // SizeImageFreq
            // 
            this.SizeImageFreq.AutoSize = true;
            this.SizeImageFreq.Location = new System.Drawing.Point(354, 292);
            this.SizeImageFreq.Name = "SizeImageFreq";
            this.SizeImageFreq.Size = new System.Drawing.Size(120, 13);
            this.SizeImageFreq.TabIndex = 4;
            this.SizeImageFreq.Text = "Размер изображения:";
            // 
            // SizeImageFurier
            // 
            this.SizeImageFurier.AutoSize = true;
            this.SizeImageFurier.Location = new System.Drawing.Point(21, 607);
            this.SizeImageFurier.Name = "SizeImageFurier";
            this.SizeImageFurier.Size = new System.Drawing.Size(120, 13);
            this.SizeImageFurier.TabIndex = 5;
            this.SizeImageFurier.Text = "Размер изображения:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(731, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Время обработки";
            // 
            // PB_Furier
            // 
            this.PB_Furier.Location = new System.Drawing.Point(24, 348);
            this.PB_Furier.Name = "PB_Furier";
            this.PB_Furier.Size = new System.Drawing.Size(298, 256);
            this.PB_Furier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Furier.TabIndex = 7;
            this.PB_Furier.TabStop = false;
            // 
            // PB_Result
            // 
            this.PB_Result.Location = new System.Drawing.Point(357, 348);
            this.PB_Result.Name = "PB_Result";
            this.PB_Result.Size = new System.Drawing.Size(298, 256);
            this.PB_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Result.TabIndex = 8;
            this.PB_Result.TabStop = false;
            // 
            // SizeImageResult
            // 
            this.SizeImageResult.AutoSize = true;
            this.SizeImageResult.Location = new System.Drawing.Point(354, 607);
            this.SizeImageResult.Name = "SizeImageResult";
            this.SizeImageResult.Size = new System.Drawing.Size(120, 13);
            this.SizeImageResult.TabIndex = 9;
            this.SizeImageResult.Text = "Размер изображения:";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(670, 32);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(274, 49);
            this.Start.TabIndex = 10;
            this.Start.Text = "Начать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // FilterParam
            // 
            this.FilterParam.Location = new System.Drawing.Point(771, 127);
            this.FilterParam.Multiline = true;
            this.FilterParam.Name = "FilterParam";
            this.FilterParam.Size = new System.Drawing.Size(173, 119);
            this.FilterParam.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(667, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Центр картинки";
            // 
            // FreqY
            // 
            this.FreqY.AutoSize = true;
            this.FreqY.Location = new System.Drawing.Point(674, 159);
            this.FreqY.Name = "FreqY";
            this.FreqY.Size = new System.Drawing.Size(15, 13);
            this.FreqY.TabIndex = 45;
            this.FreqY.Text = "y:";
            // 
            // FreqX
            // 
            this.FreqX.AutoSize = true;
            this.FreqX.Location = new System.Drawing.Point(674, 144);
            this.FreqX.Name = "FreqX";
            this.FreqX.Size = new System.Drawing.Size(18, 13);
            this.FreqX.TabIndex = 44;
            this.FreqX.Text = "x: ";
            // 
            // L_Frequency_FilterArea
            // 
            this.L_Frequency_FilterArea.AutoSize = true;
            this.L_Frequency_FilterArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Frequency_FilterArea.Location = new System.Drawing.Point(722, 104);
            this.L_Frequency_FilterArea.Name = "L_Frequency_FilterArea";
            this.L_Frequency_FilterArea.Size = new System.Drawing.Size(149, 20);
            this.L_Frequency_FilterArea.TabIndex = 47;
            this.L_Frequency_FilterArea.Text = "Области фильтра";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(786, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Пример записи: x y r1 r2";
            // 
            // L_Frequency_Factor
            // 
            this.L_Frequency_Factor.AutoSize = true;
            this.L_Frequency_Factor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Frequency_Factor.Location = new System.Drawing.Point(755, 272);
            this.L_Frequency_Factor.Name = "L_Frequency_Factor";
            this.L_Frequency_Factor.Size = new System.Drawing.Size(97, 20);
            this.L_Frequency_Factor.TabIndex = 49;
            this.L_Frequency_Factor.Text = "Множители";
            // 
            // FilterTrue
            // 
            this.FilterTrue.Location = new System.Drawing.Point(684, 308);
            this.FilterTrue.Name = "FilterTrue";
            this.FilterTrue.Size = new System.Drawing.Size(253, 20);
            this.FilterTrue.TabIndex = 50;
            this.FilterTrue.Text = "1";
            // 
            // FilterFalse
            // 
            this.FilterFalse.Location = new System.Drawing.Point(684, 348);
            this.FilterFalse.Name = "FilterFalse";
            this.FilterFalse.Size = new System.Drawing.Size(253, 20);
            this.FilterFalse.TabIndex = 51;
            this.FilterFalse.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Удовлетворяет условию фильтра (r1 >= pix >= r2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(681, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Не удовлетворяет условию фильтра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(83, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Исходное изображение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(309, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(385, 20);
            this.label4.TabIndex = 55;
            this.label4.Text = "Преобразованное изображение для фильтрации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(119, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Фурье-образ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(419, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "Результат обработки";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time.Location = new System.Drawing.Point(671, 462);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(66, 20);
            this.Time.TabIndex = 58;
            this.Time.Text = "Время: ";
            // 
            // Apply
            // 
            this.Apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Apply.Location = new System.Drawing.Point(670, 377);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(274, 49);
            this.Apply.TabIndex = 59;
            this.Apply.Text = "Применить";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 637);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterFalse);
            this.Controls.Add(this.FilterTrue);
            this.Controls.Add(this.L_Frequency_Factor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.L_Frequency_FilterArea);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.FreqY);
            this.Controls.Add(this.FreqX);
            this.Controls.Add(this.FilterParam);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.SizeImageResult);
            this.Controls.Add(this.PB_Result);
            this.Controls.Add(this.PB_Furier);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SizeImageFurier);
            this.Controls.Add(this.SizeImageFreq);
            this.Controls.Add(this.SizeImageOrig);
            this.Controls.Add(this.PB_Freq);
            this.Controls.Add(this.PB_Orig);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Orig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Freq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Furier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Orig;
        private System.Windows.Forms.PictureBox PB_Freq;
        private System.Windows.Forms.Label SizeImageOrig;
        private System.Windows.Forms.Label SizeImageFreq;
        private System.Windows.Forms.Label SizeImageFurier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox PB_Furier;
        private System.Windows.Forms.PictureBox PB_Result;
        private System.Windows.Forms.Label SizeImageResult;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox FilterParam;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label FreqY;
        internal System.Windows.Forms.Label FreqX;
        internal System.Windows.Forms.Label L_Frequency_FilterArea;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label L_Frequency_Factor;
        private System.Windows.Forms.TextBox FilterTrue;
        private System.Windows.Forms.TextBox FilterFalse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Button Apply;
    }
}

