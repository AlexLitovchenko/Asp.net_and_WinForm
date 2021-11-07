using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatLab4
{
    public partial class Form1 : Form
    {
        //матрица с распределением по Гауссу
        private static double[,] GaussMatrix = null;
        private const string textSum = "Сумма матрицы: ";
        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImage = "Размер изображения: ";
        public Form1()
        {
            InitializeComponent();
            //линейная фильтрация
            NUD_R.ValueChanged += new EventHandler(NUD_ValueChanged);
            NUD_sigma.ValueChanged += new EventHandler(NUD_ValueChanged);
            CB_GaussFilter.CheckedChanged += new EventHandler(CheckBox_ChacngeActive);
            //медианная фильтрация
        }

        //действие при нажатии кнопки начать
        private static bool start = false;
        private void B_StartSpatialF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                //ошибка, файл не выбран
                return;
            }
            try
            { 
                //добавляем картинку
                Image image = Image.FromFile(openFileDialog.FileName);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = image;

                L_SizeImage.Text = textSizeImage + image.Width.ToString() + " x " + image.Height.ToString();
                L_SizeImage.Visible = true;
                L_Time.Visible = false;

                if (!start)
                {
                    B_StartSpatialF.Text = "Изменить";
                    start = true;
                }

            }
            catch
            {
                //ошибка при добавлении
            }
        }
        //выполнить линейная фильтрация
        private void B_MedianFiltering_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            double[,] matrix;
            int row, col;

            //проверка, активирован ли Гаусс
            if (CB_GaussFilter.Checked)
            {
                int r = (int)NUD_R.Value;
                matrix = GaussMatrix;
                row = col = r * 2 + 1;

                if (row % 2 == 0)
                {
                    ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                    return;
                }
            }
            else
            {
                var result = ReadTextForMatrix();
                if (!result.status)
                {
                    ErrorOK(result.text);
                    return;
                }

                //проверка числе на нечетность
                if (result.row % 2 == 0 || result.col % 2 == 0)
                {
                    ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                    return;
                }

                matrix = result.matrix;
                col = result.col;
                row = result.row;
            }

            //блокируем кнопку
            B_1.Enabled = false;
            B_2.Enabled = false;

            Image tmp = new Bitmap(pictureBox1.Image);
            (Image bmp, double time) = LinearFiltering.ApplyFilter(tmp, matrix, row, col);

            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = bmp;

            L_SizeImage.Text = textSizeImage + tmp.Width.ToString() + " x " + tmp.Height.ToString();
            L_Time.Text = textTime + time + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;

            B_1.Enabled = true;
            B_2.Enabled = true;
            tmp.Dispose();

        }
        //выполнить медианная фильтрация
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            int wigth = (int)NUD_W.Value * 2 + 1;
            int heigth = (int)NUD_T.Value * 2 + 1;

            //проверка числе на нечетность
            if (wigth % 2 == 0 || heigth % 2 == 0)
            {
                ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                return;
            }

            //блокируем кнопку
            //блокируем кнопку
            B_1.Enabled = false;
            B_2.Enabled = false;

            Image tmp = new Bitmap(pictureBox1.Image);
            (Image bmp, double time) = MedianFiltering.ApplyFilter(tmp, heigth, wigth);

            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = bmp;

            L_SizeImage.Text = textSizeImage + tmp.Width.ToString() + " x " + tmp.Height.ToString();
            L_Time.Text = textTime + time + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;

            B_1.Enabled = true;
            B_2.Enabled = true;
            tmp.Dispose();
            tmp.Dispose();

        }
        //выполняется при изменении чекбокса для активации Гауссова фильтра
        public void CheckBox_ChacngeActive(object sender, EventArgs e)
        {
            if (CB_GaussFilter.Checked)
            {
                NUD_R.Value = 1;
                NUD_sigma.Value = 1;

                int R = (int)NUD_R.Value;
                double sigma = (double)NUD_sigma.Value;

                //заполнить матрицу распределением по Гауссу
                var result = GaussianFilter.MatrixGaussianFilter(R, sigma);
                GaussMatrix = result.matrix;
                L_matrix.Text = textSum + Math.Round(result.sum, GaussianFilter.RoundNumber).ToString();
                //заполняем textBox с матрицей
                WriteTextToMatrix(result.matrix, R * 2 + 1, R * 2 + 1);
                NUD_R.Enabled = true;
                NUD_sigma.Enabled = true;
                TB_Matrix.Enabled = false;
                return;
            }

            TB_Matrix.Enabled = true;
            NUD_R.Enabled = false;
            NUD_sigma.Enabled = false;
            L_matrix.Text = textSum;

            //убираем ссылку на матрицу
            GaussMatrix = null;
        }

        //выполняется при изменении радиуса или sigma
        public void NUD_ValueChanged(object sender, EventArgs e)
        {
            int R = (int)NUD_R.Value;
            double sigma = (double)NUD_sigma.Value;

            //заполнить матрицу распределением по Гауссу
            var result = GaussianFilter.MatrixGaussianFilter(R, sigma);
            GaussMatrix = result.matrix;
            L_matrix.Text = textSum + Math.Round(result.sum, GaussianFilter.RoundNumber).ToString();
            //заполняем textBox с матрицей
            WriteTextToMatrix(result.matrix, R * 2 + 1, R * 2 + 1);
        }

        //заполняем textBox с матрицей
        private void WriteTextToMatrix(double[,] matrix, int row, int col)
        {
            TB_Matrix.Clear();
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    TB_Matrix.AppendText(matrix[i, j].ToString("F" + GaussianFilter.RoundNumber.ToString()) + " ");
                }
                TB_Matrix.AppendText(Environment.NewLine);
            }
        }
        //считывание данных и заполнение матрицы
        private ResultReadMatrix ReadTextForMatrix()
        {
            try
            {
                string text = TB_Matrix.Text;
                //меняем все точки на запятые
                text = text.Replace(".", ",");
                //удаляет повторяющиеся пробельные символы
                text = Regex.Replace(text, @" +", " ");
                //удаляет символы вначале и в конце строки
                text = text.Trim(new char[] { '\r', '\n', ' ' });

                //прокерка строки на содержание только определенных символов
                if (!Regex.IsMatch(text, "^[-/.,\n\r 0-9]*$"))
                {
                    return new ResultReadMatrix("В матрице содержаться запрещенные символы!\n Доступны только символы: ' ', ',', '.', '/', '0-9'");
                }

                //делим строку на подстроки
                string[] TextRows = Regex.Split(text, "\r\n");
                List<List<double>> MatrixDigits = new List<List<double>>();

                for (int i = 0; i < TextRows.Count(); ++i)
                {
                    TextRows[i] = TextRows[i].Trim(' ');
                    string[] digits = Regex.Split(TextRows[i], " ");
                    List<double> RowDigits = new List<double>();

                    for (int j = 0; j < digits.Count(); ++j)
                    {
                        //проверка на запись числа через дробь
                        if (digits[j].Contains('/'))
                        {
                            string[] TwoDigits = Regex.Split(digits[j], "/");
                            double one, two;
                            bool flag1 = Double.TryParse(TwoDigits[0], out one);
                            bool flag2 = Double.TryParse(TwoDigits[1], out two);
                            //проверка на ошибку
                            if (!flag1 || !flag2 || two == 0)
                            {
                                return new ResultReadMatrix("Произошла ошибка при обработки числа записанного через дробь в матрице!");
                            }
                            RowDigits.Add(one / two);
                        }
                        else
                        {
                            double digit;
                            bool flag = Double.TryParse(digits[j], out digit);
                            //проверка на ошибку
                            if (!flag) return new ResultReadMatrix("Произошла ошибка при обработки чисел в матрице!");
                            RowDigits.Add(digit);
                        }
                    }

                    MatrixDigits.Add(RowDigits);
                }

                //переносим данные в массив
                List<int> col = new List<int>();
                for (int i = 0; i < MatrixDigits.Count(); ++i)
                {
                    col.Add(MatrixDigits[i].Count());
                }
                int max = col.Max();
                int min = col.Min();
                if (max != min) return new ResultReadMatrix("Криво записана матрица!");

                double[,] matrix = new double[MatrixDigits.Count(), max];
                for (int i = 0; i < MatrixDigits.Count(); ++i)
                {
                    for (int j = 0; j < max; ++j)
                    {
                        matrix[i, j] = MatrixDigits[i][j];
                    }
                }

                return new ResultReadMatrix(matrix, MatrixDigits.Count(), max);
            }
            catch
            {
                return new ResultReadMatrix("В результате оработки матрицы произошла непредвиденная ошибка!");
            }
        }
        public DialogResult ErrorOK(string text, string error = "Ошибка")
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
    }

    //классик для упрощения работы с данными полученными при чтении матрицы
    public class ResultReadMatrix
    {
        public double[,] matrix { get; private set; }
        public int row { get; private set; }
        public int col { get; private set; }
        public string text { get; private set; }
        public bool status { get; private set; }

        public ResultReadMatrix(double[,] matrix, int row, int col)
        {
            this.matrix = matrix;
            this.row = row;
            this.col = col;
            this.status = true;
            text = "Все хорошо!";
        }
        public ResultReadMatrix(string error)
        {
            this.matrix = null;
            this.row = 0;
            this.col = 0;
            this.status = false;
            this.text = error;
        }
    }
}
