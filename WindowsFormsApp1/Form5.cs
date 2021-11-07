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
    public partial class Form5 : Form
    {
        public static double Qi;
        public static double Ei;
        public static double p;
        public static double Qc;
        public static double Qp;
        public static double Qmax;
        public static double t;
        public static double Ci;
        public static double Cp;
        public static double h1;
        public static double h2;
        public static double del;
        public static double tc;

        public static string Dw = "";
        public Form5()
        {
            InitializeComponent();
            if (Form1.tip == 1) Ei = 500;
            if (Form1.tip == 2) Ei = 500;
            if (Form1.tip == 0) Ei = 140;

            if (Form1.tip == 1) p = 600;
            if (Form1.tip == 2) p = 1200;
            if (Form1.tip == 0) p = 1250;
            Qi = Ei * Form1.q / Form1.D1;
            Qc = p * Form1.v * Form1.v / 1000000;
            Qp = Form1.Q0 + Form1.F / (2 * Form1.b * Form1.q) + Qc;
            Qmax = Qi + Qp;
            if (Form1.R == 1) 
            {
                t = 2.46 * 100000000 / Math.Pow(Qmax, 6);
                label21.Text = "---";
                label22.Text = "---";
                label8.Text = "---";
            }
            if(Form1.R == 2)
            {
                Ci = 2 / (1 + Math.Pow(((Qp + Qi / Form1.u) / Qmax) , 6));
                switch (Qp)
                {
                    case (2.4) :
                        if (Form1.D1 / Form1.q == 25) tc = 950;
                        if (Form1.D1 / Form1.q == 30) tc = 1970;
                        if (Form1.D1 / Form1.q == 35) tc = 3560;
                        if (Form1.D1 / Form1.q == 40) tc = 5850;
                        if (Form1.D1 / Form1.q == 45) tc = 8710;
                        if (Form1.D1 / Form1.q == 50) tc = 12400;
                        break;
                    case (2.8):
                        if (Form1.D1 / Form1.q == 25) tc = 725;
                        if (Form1.D1 / Form1.q == 30) tc = 1430;
                        if (Form1.D1 / Form1.q == 35) tc = 2460;
                        if (Form1.D1 / Form1.q == 40) tc = 3950;
                        if (Form1.D1 / Form1.q == 45) tc = 5850;
                        if (Form1.D1 / Form1.q == 50) tc = 8050;
                        break;
                    case (3.2):
                        if (Form1.D1 / Form1.q == 25) tc = 535;
                        if (Form1.D1 / Form1.q == 30) tc = 1040;
                        if (Form1.D1 / Form1.q == 35) tc = 1750;
                        if (Form1.D1 / Form1.q == 40) tc = 2740;
                        if (Form1.D1 / Form1.q == 45) tc = 3950;
                        if (Form1.D1 / Form1.q == 50) tc = 5280;
                        break;
                    case (3.6):
                        if (Form1.D1 / Form1.q == 25) tc = 410;
                        if (Form1.D1 / Form1.q == 30) tc = 775;
                        if (Form1.D1 / Form1.q == 35) tc = 1280;
                        if (Form1.D1 / Form1.q == 40) tc = 1900;
                        if (Form1.D1 / Form1.q == 45) tc = 2740;
                        if (Form1.D1 / Form1.q == 50) tc = 3560;
                        break;
                    case (4.0):
                        if (Form1.D1 / Form1.q == 25) tc = 320;
                        if (Form1.D1 / Form1.q == 30) tc = 585;
                        if (Form1.D1 / Form1.q == 35) tc = 950;
                        if (Form1.D1 / Form1.q == 40) tc = 1390;
                        if (Form1.D1 / Form1.q == 45) tc = 1900;
                        if (Form1.D1 / Form1.q == 50) tc = 2460;
                        break;
                    case (4.4):
                        if (Form1.D1 / Form1.q == 25) tc = 250;
                        if (Form1.D1 / Form1.q == 30) tc = 425;
                        if (Form1.D1 / Form1.q == 35) tc = 725;
                        if (Form1.D1 / Form1.q == 40) tc = 1020;
                        if (Form1.D1 / Form1.q == 45) tc = 1390;
                        if (Form1.D1 / Form1.q == 50) tc = 1750;
                        break;
                    case (4.8):
                        if (Form1.D1 / Form1.q == 25) tc = 195;
                        if (Form1.D1 / Form1.q == 30) tc = 345;
                        if (Form1.D1 / Form1.q == 35) tc = 535;
                        if (Form1.D1 / Form1.q == 40) tc = 750;
                        if (Form1.D1 / Form1.q == 45) tc = 1010;
                        if (Form1.D1 / Form1.q == 50) tc = 1280;
                        break;
                }
                Cp = (Math.Pow((Form1.qx / Qmax), 6) * Form1.ix * Form1.ex);
                t = (tc / Form1.i2) * Ci * Cp;
                label21.Text = Convert.ToString(Ci);
                label22.Text = Convert.ToString(Cp);
                label8.Text = Convert.ToString(tc);
            }
            h1 = Math.Pow(Qmax,6) * 3600 * Form1.i2 * Form1.Z * tc;
            h2 = Math.Pow(Form1.qn, 6) * 10000000;
            del = h2 - h1;
           
            if (del == 0)
            {
                Dw = "Достоверно";
            }
            else
            {
                Dw = "Не Достоверно";
            }
            label15.Text = Convert.ToString(Qi);
            label16.Text = Convert.ToString(Ei);
            label17.Text = Convert.ToString(Qc);
            label18.Text = Convert.ToString(Qp);
            label19.Text = Convert.ToString(Qmax);
            label20.Text = Convert.ToString(t);
            label23.Text = Convert.ToString(h1);
            label24.Text = Convert.ToString(h2);
            label27.Text = Convert.ToString(p);
            label25.Text = Convert.ToString(del);
            label26.Text = Dw;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
