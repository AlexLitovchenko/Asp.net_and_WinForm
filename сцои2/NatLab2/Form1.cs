using NatLab2.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatLab2
{
    public partial class Form1 : Form
    {
        MyCanvas canvas = new MyCanvas();
        public Form1()
        {
            InitializeComponent();

            //настройка рисования (поистроения графика по точкам)
            canvas.Name = "canvas1";
            canvas.pictureBox = this.pictureBox1;
            canvas.comboBox = this.comboBox1;
            canvas.chart = this.chart1;
            canvas.panel = this.panel1;
            this.panel1.Controls.Add(canvas);
            canvas.Dock = DockStyle.Fill;


            //настройка comboBox с функциями
            comboBox1.Items.AddRange(new string[]
            {
                "Линейная зависимость",
                "Квадратичный сплайн",
                "Кубический сплайн",
                "Полином Лагранжа",
                "Полином Ньютона",
                "Кривая Безье"
            });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            //настройка гистограммы
            chart1.Series[0].XValueMember = "X";
            chart1.Series[0].YValueMembers = "Y";
        }
        //сброисть 
        private void button4_Click(object sender, EventArgs e)
        {
            canvas.Clear();
        }
        //применить
        private void button6_Click(object sender, EventArgs e)
        {
            if (canvas.image == null || pictureBox1.Image == null) return;

            canvas.image.Dispose();
            canvas.image = (Image)pictureBox1.Image.Clone();

            canvas.Clear();
        }
        //изменить график
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            canvas.UpdateCanvas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //добавить картинку
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
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                if (canvas.image != null) canvas.image.Dispose();

                //добавляем картинку
                Image image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = image;

                //копируем ее в MyCanvas
                canvas.image = (Image)image.Clone();
            }
            catch
            {

                //ошибка при добавлении
            }
        }
    }
}
