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
        
        public int i=0;
        public static double  D1;
        public static double q;
        public static double Q0;
        public static double F;
        public static double b;
        public static double p;
        public static double v;
        public static double i2;
        public static double Z;
        public static double u;
        public static double ix;
        public static double ex;
        public static double k;
        public static double qx;
        public static double qn;
        public static double tip;
        public static int R;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {


         D1=Convert.ToDouble(textBox1.Text);
            q=Convert.ToDouble(textBox2.Text);
         Q0 = Convert.ToDouble(textBox3.Text);
         F = Convert.ToDouble(textBox4.Text);
         b = Convert.ToDouble(textBox5.Text);
      
      v = Convert.ToDouble(textBox7.Text);
        i2 = Convert.ToDouble(textBox8.Text);
         Z = Convert.ToDouble(textBox9.Text);
        u = Convert.ToDouble(textBox10.Text);
        ix = Convert.ToDouble(textBox11.Text);
         ex = Convert.ToDouble(textBox12.Text);
        k = Convert.ToDouble(textBox13.Text);
        qx = Convert.ToDouble(textBox14.Text);
        qn = Convert.ToDouble(textBox15.Text);
            if (comboBox1.Text == "Тип 1") tip = 1;
            if (comboBox1.Text == "Тип 2") tip = 2;
            if (comboBox1.Text == "-") tip = 0;
            if (radioButton1.Checked) R = 1;
            if (radioButton2.Checked) R = 2;



            Form5 a = new Form5();
            i = 1;
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                listBox1.Items.Add(Form5.Dw);
                
            }
            else
            {
                Form4 a = new Form4();
                a.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                Form2 a = new Form2();
                a.Show();
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
