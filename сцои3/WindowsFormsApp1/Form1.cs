using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //начальная картинка
        private Image img = null;
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[]
            {
                "Критерий Гаврилова",
                "Критерий Отсу",
                "Критерий Ниблека",
                "Критерий Сауволы",
                "Критерий Кристиана Вульфа",
                "Критерий Брэдли-Рота"
            });
            comboBox1.SelectedIndex = 0;
        }
        //загрузить картинку
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                //ошибка, файл не выбран
                return;
            }
            try
            {
                if (img != null) img.Dispose();
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                //добавляем картинку
                Image image = Image.FromFile(openFileDialog.FileName);
                img = image;
                pictureBox1.Image = (Image)image.Clone();

                LSizeImg.Text = textSizeImg + img.Width.ToString() + " x " + img.Height.ToString();
                LSizeImg.Visible = true;
                LTime.Visible = false;
            }
            catch
            {
                //ошибка при добавлении
            }
        }
        //выполнить 
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImg();
        }
        //перевод изображения в ч/б
        private void CB_GaussFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (img == null) return;

            if (CB_Check.Checked)
            {
                Image NewImg = WorkImage.ConvertToGrayscale(img);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = NewImg;
            }
            else
            {
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = (Image)img.Clone();
            }
                

            LSizeImg.Text = textSizeImg + img.Width.ToString() + " x " + img.Height.ToString();
            LSizeImg.Visible = true;
            LTime.Visible = false;
        }
        //изменяем размер окна
        private void NUD_SizeWindow_ValueChanged(object sender, EventArgs e)
        {
            ChangeImg();
        }
        //изменяем чувствительность или усиление
        private void NUD_Koef_ValueChanged(object sender, EventArgs e)
        {
            ChangeImg();
        }
        //выбираем способ бинамиризации
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (img == null) return;
            switch (comboBox1.SelectedIndex)
            {
                //Критерий Гаврилова
                case 0:
                //Критерий Отсу
                case 1:
                    NUD_SizeWindow.Enabled = false;
                    NUD_Koef.Enabled = false;
                    LTime.Visible = false;
                    break;
                //Критерий Ниблека
                case 2:
                    NUD_SizeWindow.Enabled = true;
                    NUD_Koef.Enabled = true;
                    NUD_Koef.Value = P_Nibleck.k;
                    NUD_Koef.Minimum = P_Nibleck.min;
                    NUD_Koef.Maximum = P_Nibleck.max;
                    NUD_SizeWindow.Value = P_Nibleck.size;
                    break;
                //Критерий Сауволы
                case 3:
                    NUD_SizeWindow.Enabled = true;
                    NUD_Koef.Enabled = true;
                    NUD_Koef.Value = P_Sauwolas.k;
                    NUD_Koef.Minimum = P_Sauwolas.min;
                    NUD_Koef.Maximum = P_Sauwolas.max;
                    NUD_SizeWindow.Value = P_Sauwolas.size;
                    break;
                //Критерий Кристиана Вульфа
                case 4:
                    NUD_SizeWindow.Enabled = true;
                    NUD_Koef.Enabled = true;
                    NUD_Koef.Value = P_ChristianWolfe.k;
                    NUD_Koef.Minimum = P_ChristianWolfe.min;
                    NUD_Koef.Maximum = P_ChristianWolfe.max;
                    NUD_SizeWindow.Value = P_ChristianWolfe.size;
                    break;
                //Критерий Брэдли-Рота
                case 5:
                    NUD_SizeWindow.Enabled = true;
                    NUD_Koef.Enabled = true;
                    NUD_Koef.Value = P_BradleyRote.k;
                    NUD_Koef.Minimum = P_BradleyRote.min;
                    NUD_Koef.Maximum = P_BradleyRote.max;
                    NUD_SizeWindow.Value = P_BradleyRote.size;
                    break;
            }
        }

        //<!-- мой код -->
        private class Param
        {
            public int size { get; } = 3;
            public decimal k { get; }
            public decimal min { get; }
            public decimal max { get; }
            public Param(decimal k, decimal min, decimal max)
            {
                this.k = k;
                this.min = min;
                this.max = max;
            }
        }
        //старторые параметры, а также их границы
        private static Param P_Nibleck = new Param(-0.2m, -10, 10);
        private static Param P_Sauwolas = new Param(0.2m, 0.2m, 0.5m);
        private static Param P_ChristianWolfe = new Param(0.5m, 0, 1);
        private static Param P_BradleyRote = new Param(0.15m, 0, 1);
        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImg = "Размер изображения: ";
        //изменение изображения
        private void ChangeImg()
        {
            if (img == null) return;
            button2.Enabled = false;
            //новое изображение
            Image NewImg = null;
            //время обработки изображения
            double time = 0;
            switch (comboBox1.SelectedIndex)
            {
                //Критерий Гаврилова
                case 0:
                    (NewImg, time) = Gavrilov.Binarization(img);
                    break;
                //Критерий Отсу
                case 1:
                    (NewImg, time) = Otsu.Binarization(img);
                    break;
                //Критерий Ниблека
                case 2:
                    (NewImg, time) = Nibleck.Binarization(img, (int)NUD_SizeWindow.Value, (double)NUD_Koef.Value);
                    break;
                //Критерий Сауволы
                case 3:
                    (NewImg, time) = Sauwolas.Binarization(img, (int)NUD_SizeWindow.Value, (double)NUD_Koef.Value);
                    break;
                //Критерий Кристиана Вульфа
                case 4:
                    (NewImg, time) = ChristianWolfe.Binarization(img, (int)NUD_SizeWindow.Value, (double)NUD_Koef.Value);
                    break;
                //Критерий Брэдли-Рота
                case 5:
                    (NewImg, time) = BradleyRota.Binarization(img, (int)NUD_SizeWindow.Value, (double)NUD_Koef.Value);
                    break;
            }

            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = NewImg;

            LTime.Text = textTime + time.ToString() + " мс.";
            LSizeImg.Text = textSizeImg + img.Width.ToString() + " x " + img.Height.ToString();
            LSizeImg.Visible = true;
            LTime.Visible = true;

            button2.Enabled = true;
        }
    }
}
