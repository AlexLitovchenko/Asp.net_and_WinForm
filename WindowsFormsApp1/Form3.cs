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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            #region табл1
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 4;
            //столбец 1
            dataGridView1.Rows[0].Cells[0].Value = "Вид ремня";
            dataGridView1.Rows[1].Cells[0].Value = "Тканевые прорезиненные конечной длины";
            dataGridView1.Rows[2].Cells[0].Value = "Синтетические капроновые с пленочным покрытием";
            dataGridView1.Rows[3].Cells[0].Value = "Синтетические капроновые с пленочным покрытием ";
           
            //2
            dataGridView1.Rows[0].Cells[1].Value = "Тип ремня";
            dataGridView1.Rows[1].Cells[1].Value = "-";
            dataGridView1.Rows[2].Cells[1].Value = "Тип 1";
            dataGridView1.Rows[3].Cells[1].Value = "Тип 2";
           
            //3
            dataGridView1.Rows[0].Cells[2].Value = "Модуль упругости при изгибе Eи";
            dataGridView1.Rows[1].Cells[2].Value = "140";
            dataGridView1.Rows[2].Cells[2].Value = "500";
            dataGridView1.Rows[3].Cells[2].Value = "500";
            #endregion

            #region табл2
            dataGridView2.ColumnCount = 4;
            dataGridView2.RowCount = 4;
            //столбец 1
            dataGridView2.Rows[0].Cells[0].Value = "Вид ремня";
            dataGridView2.Rows[1].Cells[0].Value = "Тканевые прорезиненные конечной длины";
            dataGridView2.Rows[2].Cells[0].Value = "Синтетические капроновые с пленочным покрытием";
            dataGridView2.Rows[3].Cells[0].Value = "Синтетические капроновые с пленочным покрытием ";
            
            //2
            dataGridView2.Rows[0].Cells[1].Value = "Тип ремня";
            dataGridView2.Rows[1].Cells[1].Value = "-";
            dataGridView2.Rows[2].Cells[1].Value = "Тип 1";
            dataGridView2.Rows[3].Cells[1].Value = "Тип 2";

            //3
            dataGridView2.Rows[0].Cells[2].Value = "Плотность ремня р Нижняя граница";
            dataGridView2.Rows[1].Cells[2].Value = "1250";
            dataGridView2.Rows[2].Cells[2].Value = "600";
            dataGridView2.Rows[3].Cells[2].Value = "1200";

            //4
            dataGridView2.Rows[0].Cells[3].Value = "Плотность ремня р Верхняя граница";
            dataGridView2.Rows[1].Cells[3].Value = "1500";
            dataGridView2.Rows[2].Cells[3].Value = "-";
            dataGridView2.Rows[3].Cells[3].Value = "-";
            #endregion

            #region таблица3
            dataGridView3.ColumnCount = 3;
            dataGridView3.RowCount = 43;
            //1
            dataGridView3.Rows[0].Cells[0].Value = "Напряжение растяжения в ремне Qp";
            dataGridView3.Rows[1].Cells[0].Value = "2,4";
            dataGridView3.Rows[2].Cells[0].Value = "2,4";
            dataGridView3.Rows[3].Cells[0].Value = "2,4";
            dataGridView3.Rows[4].Cells[0].Value = "2,4";
            dataGridView3.Rows[5].Cells[0].Value = "2,4";
            dataGridView3.Rows[6].Cells[0].Value = "2,4";

            dataGridView3.Rows[7].Cells[0].Value = "2,8";
            dataGridView3.Rows[8].Cells[0].Value = "2,8";
            dataGridView3.Rows[9].Cells[0].Value = "2,8";
            dataGridView3.Rows[10].Cells[0].Value = "2,8";
            dataGridView3.Rows[11].Cells[0].Value = "2,8";
            dataGridView3.Rows[12].Cells[0].Value = "2,8";

            dataGridView3.Rows[13].Cells[0].Value = "3,2";
            dataGridView3.Rows[14].Cells[0].Value = "3,2";
            dataGridView3.Rows[15].Cells[0].Value = "3,2";
            dataGridView3.Rows[16].Cells[0].Value = "3,2";
            dataGridView3.Rows[17].Cells[0].Value = "3,2";
            dataGridView3.Rows[18].Cells[0].Value = "3,2";

            dataGridView3.Rows[19].Cells[0].Value = "3,6";
            dataGridView3.Rows[20].Cells[0].Value = "3,6";
            dataGridView3.Rows[21].Cells[0].Value = "3,6";
            dataGridView3.Rows[22].Cells[0].Value = "3,6";
            dataGridView3.Rows[23].Cells[0].Value = "3,6";
            dataGridView3.Rows[24].Cells[0].Value = "3,6";

            dataGridView3.Rows[25].Cells[0].Value = "4,0";
            dataGridView3.Rows[26].Cells[0].Value = "4,0";
            dataGridView3.Rows[27].Cells[0].Value = "4,0";
            dataGridView3.Rows[28].Cells[0].Value = "4,0";
            dataGridView3.Rows[29].Cells[0].Value = "4,0";
            dataGridView3.Rows[30].Cells[0].Value = "4,0";

            dataGridView3.Rows[31].Cells[0].Value = "4,4";
            dataGridView3.Rows[32].Cells[0].Value = "4,4";
            dataGridView3.Rows[33].Cells[0].Value = "4,4";
            dataGridView3.Rows[34].Cells[0].Value = "4,4";
            dataGridView3.Rows[35].Cells[0].Value = "4,4";
            dataGridView3.Rows[36].Cells[0].Value = "4,4";

            dataGridView3.Rows[37].Cells[0].Value = "4,8";
            dataGridView3.Rows[38].Cells[0].Value = "4,8";
            dataGridView3.Rows[39].Cells[0].Value = "4,8";
            dataGridView3.Rows[40].Cells[0].Value = "4,8";
            dataGridView3.Rows[41].Cells[0].Value = "4,8";
            dataGridView3.Rows[42].Cells[0].Value = "4,8";

            //2
            dataGridView3.Rows[0].Cells[1].Value = " ";
            dataGridView3.Rows[1].Cells[1].Value = "25";
            dataGridView3.Rows[2].Cells[1].Value = "30";
            dataGridView3.Rows[3].Cells[1].Value = "35";
            dataGridView3.Rows[4].Cells[1].Value = "40";
            dataGridView3.Rows[5].Cells[1].Value = "45";
            dataGridView3.Rows[6].Cells[1].Value = "50";

            dataGridView3.Rows[7].Cells[1].Value = "25";
            dataGridView3.Rows[8].Cells[1].Value = "30";
            dataGridView3.Rows[9].Cells[1].Value = "35";
            dataGridView3.Rows[10].Cells[1].Value = "40";
            dataGridView3.Rows[11].Cells[1].Value = "45";
            dataGridView3.Rows[12].Cells[1].Value = "50";

            dataGridView3.Rows[13].Cells[1].Value = "25";
            dataGridView3.Rows[14].Cells[1].Value = "30";
            dataGridView3.Rows[15].Cells[1].Value = "35";
            dataGridView3.Rows[16].Cells[1].Value = "40";
            dataGridView3.Rows[17].Cells[1].Value = "45";
            dataGridView3.Rows[18].Cells[1].Value = "50";

            dataGridView3.Rows[19].Cells[1].Value = "25";
            dataGridView3.Rows[20].Cells[1].Value = "30";
            dataGridView3.Rows[21].Cells[1].Value = "35";
            dataGridView3.Rows[22].Cells[1].Value = "40";
            dataGridView3.Rows[23].Cells[1].Value = "45";
            dataGridView3.Rows[24].Cells[1].Value = "50";

            dataGridView3.Rows[25].Cells[1].Value = "25";
            dataGridView3.Rows[26].Cells[1].Value = "30";
            dataGridView3.Rows[27].Cells[1].Value = "35";
            dataGridView3.Rows[28].Cells[1].Value = "40";
            dataGridView3.Rows[29].Cells[1].Value = "45";
            dataGridView3.Rows[30].Cells[1].Value = "50";

            dataGridView3.Rows[31].Cells[1].Value = "25";
            dataGridView3.Rows[32].Cells[1].Value = "30";
            dataGridView3.Rows[33].Cells[1].Value = "35";
            dataGridView3.Rows[34].Cells[1].Value = "40";
            dataGridView3.Rows[35].Cells[1].Value = "45";
            dataGridView3.Rows[36].Cells[1].Value = "50";

            dataGridView3.Rows[37].Cells[1].Value = "25";
            dataGridView3.Rows[38].Cells[1].Value = "30";
            dataGridView3.Rows[39].Cells[1].Value = "35";
            dataGridView3.Rows[40].Cells[1].Value = "40";
            dataGridView3.Rows[41].Cells[1].Value = "45";
            dataGridView3.Rows[42].Cells[1].Value = "50";
            //3
            dataGridView3.Rows[0].Cells[2].Value = " ";
            dataGridView3.Rows[1].Cells[2].Value = "950";
            dataGridView3.Rows[2].Cells[2].Value = "1970";
            dataGridView3.Rows[3].Cells[2].Value = "3560";
            dataGridView3.Rows[4].Cells[2].Value = "5880";
            dataGridView3.Rows[5].Cells[2].Value = "8710";
            dataGridView3.Rows[6].Cells[2].Value = "12400";

            dataGridView3.Rows[7].Cells[2].Value = "725";
            dataGridView3.Rows[8].Cells[2].Value = "1430";
            dataGridView3.Rows[9].Cells[2].Value = "2460";
            dataGridView3.Rows[10].Cells[2].Value = "3950";
            dataGridView3.Rows[11].Cells[2].Value = "5850";
            dataGridView3.Rows[12].Cells[2].Value = "8050";

            dataGridView3.Rows[13].Cells[2].Value = "535";
            dataGridView3.Rows[14].Cells[2].Value = "1040";
            dataGridView3.Rows[15].Cells[2].Value = "1750";
            dataGridView3.Rows[16].Cells[2].Value = "2740";
            dataGridView3.Rows[17].Cells[2].Value = "3950";
            dataGridView3.Rows[18].Cells[2].Value = "5280";

            dataGridView3.Rows[19].Cells[2].Value = "410";
            dataGridView3.Rows[20].Cells[2].Value = "775";
            dataGridView3.Rows[21].Cells[2].Value = "1280";
            dataGridView3.Rows[22].Cells[2].Value = "1900";
            dataGridView3.Rows[23].Cells[2].Value = "2740";
            dataGridView3.Rows[24].Cells[2].Value = "3560";

            dataGridView3.Rows[25].Cells[2].Value = "320";
            dataGridView3.Rows[26].Cells[2].Value = "585";
            dataGridView3.Rows[27].Cells[2].Value = "950";
            dataGridView3.Rows[28].Cells[2].Value = "1390";
            dataGridView3.Rows[29].Cells[2].Value = "1900";
            dataGridView3.Rows[30].Cells[2].Value = "2460";

            dataGridView3.Rows[31].Cells[2].Value = "250";
            dataGridView3.Rows[32].Cells[2].Value = "425";
            dataGridView3.Rows[33].Cells[2].Value = "725";
            dataGridView3.Rows[34].Cells[2].Value = "1020";
            dataGridView3.Rows[35].Cells[2].Value = "1390";
            dataGridView3.Rows[36].Cells[2].Value = "1750";

            dataGridView3.Rows[37].Cells[2].Value = "195";
            dataGridView3.Rows[38].Cells[2].Value = "345";
            dataGridView3.Rows[39].Cells[2].Value = "535";
            dataGridView3.Rows[40].Cells[2].Value = "750";
            dataGridView3.Rows[41].Cells[2].Value = "1010";
            dataGridView3.Rows[42].Cells[2].Value = "1280";
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
