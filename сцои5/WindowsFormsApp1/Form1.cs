using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly string SizeImg = "Размер изображения: ";
        //действие при нажатии кнопки начать
        private static bool start = false;
        private void Start_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                //ошибка, файл не выбран
                return;
            }
            try
            {
                //добавляем yначальную картинку картинку
                Image image = Image.FromFile(openFileDialog.FileName);
                if (PB_Orig.Image != null) PB_Orig.Image.Dispose();
                PB_Orig.Image = image;
                SizeImageOrig.Text = SizeImg + image.Width.ToString() + " x " + image.Height.ToString();

                //преобразуем картинку для фильтрации
                int w = image.Width;
                int h = image.Height;
                w = (int)clp2(w);
                h = (int)clp2(h);
                //преобразование к одноиу значению w и h
                w = h = (new List<int>() { w, h }).Max();

                if (PB_Freq.Image != null) PB_Freq.Image.Dispose();
                image = new Bitmap(image, new Size(w, h));
                PB_Freq.Image = image;
                SizeImageFreq.Text = SizeImg + image.Width.ToString() + " x " + image.Height.ToString();

                //выводим центр карнтинки
                FreqX.Text = "x: " + (w / 2).ToString();
                FreqY.Text = "y: " + (h / 2).ToString();

                //задаем значение фильтров
                FilterTrue.Text = "1";
                FilterFalse.Text = "0";

                if (!start)
                {
                    Start.Text = "Изменить";
                    start = true;
                }

            }
            catch
            {
                //ошибка при добавлении
            }
        }

        // <-- мое -->

        //поиск ближайшего числа к степени 2
        public static long clp2(long x)
        {
            long p2 = 1;
            while (true)
            {
                if (p2 >= x) return p2;
                p2 <<= 1;
            }
        }

        //вывод сообщения об ошибки
        public static DialogResult ErrorOK(string text, string error = "Ошибка")
        {
            DialogResult result = MessageBox.Show(
                                                    text,
                                                    error,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly
                                                  );
            return result;
        }

        //считывание данных с текстового поля
        private List<Filter> ReadText()
        {
            string text = FilterParam.Text;

            //удаляет повторяющиеся пробельные символы
            text = Regex.Replace(text, @" +", " ");
            //удаляет символы вначале и в конце строки
            text = text.Trim(new char[] { '\r', '\n', ' ' });

            //прокерка строки на содержание только определенных символов
            if (!Regex.IsMatch(text, "^[\n\r 0-9]*$"))
            {
                ErrorOK("В текстовом поле содержатся запрещенные символы!\n Доступны только символы: ' ', '0-9'");
                return null;
            }

            //делим строку на подстроки
            string[] TextRows = Regex.Split(text, "\r\n");
            List<Filter> param = new List<Filter>();

            try
            {
                for (int i = 0; i < TextRows.Length; ++i)
                {
                    TextRows[i] = TextRows[i].Trim(' ');
                    string[] digits = Regex.Split(TextRows[i], " ");
                    if (digits.Length > 5)
                    {
                        ErrorOK("Неверный формат строки!");
                        return null;
                    }

                    List<int> IntDigit = new List<int>();
                    for (int j = 0; j < digits.Length; ++j)
                    {
                        int number;
                        bool flag = Int32.TryParse(digits[j], out number);
                        if (!flag)
                        {
                            ErrorOK("Неверный формат строки!");
                            return null;
                        }
                        IntDigit.Add(number);
                    }

                    param.Add(new Filter(IntDigit[0], IntDigit[1], IntDigit[2], IntDigit[3]));
                }
            }
            catch
            {
                ErrorOK("Произошла ошибка при обработки текстового поля!");
                return null;
            }

            return param;
        }
        //применить фильтр
        private void Apply_Click(object sender, EventArgs e)
        {
            if (PB_Freq.Image == null) return;
            //считываем данные с поля
            var param = ReadText();
            if (param == null) return;

            //считываем условие фильтрации
            int filterTrue, filterFalse;
            bool flag;
            flag = int.TryParse(FilterTrue.Text, out filterTrue);
            if (!flag)
            {
                ErrorOK("Произошла ошибка при обработки текстового поля 'удовлетворяет условию'!");
                return;
            }
            flag = int.TryParse(FilterFalse.Text, out filterFalse);
            if (!flag)
            {
                ErrorOK("Произошла ошибка при обработки текстового поля 'неудовлетворяет условию'!");
                return;
            }

            //делаем копию изображения
            Image tmp = new Bitmap(PB_Freq.Image);
            //яркость
            double Brightness = 180;
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            (Image image, Image FourierImage) = FrequencyFilters.ApplyFilter(tmp, param, Brightness, filterTrue, filterFalse);

            //остановка таймера
            sWatch.Stop();

            //выводим результат - картинка
            if (PB_Result.Image != null) PB_Result.Image.Dispose();
            PB_Result.Image = new Bitmap(image, new Size(PB_Orig.Image.Width, PB_Orig.Image.Height));
            SizeImageResult.Text = SizeImg + PB_Orig.Image.Width.ToString() + " x " + PB_Orig.Image.Height.ToString();
            image.Dispose();

            //выводим результат - фурье-образ
            if (PB_Furier.Image != null) PB_Furier.Image.Dispose();
            PB_Furier.Image = FourierImage;
            SizeImageFurier.Text = SizeImg + FourierImage.Width.ToString() + " x " + FourierImage.Width.ToString();

            //выводим время обработки
            Time.Text = "Время: " + sWatch.ElapsedMilliseconds.ToString() + " мс.";

            tmp.Dispose();
        }
    }
}
