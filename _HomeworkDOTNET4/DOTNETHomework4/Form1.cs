using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace DOTNETHomework4
{
    public partial class Form1 : Form
    {
        public double Th1 { get; set; } = 30 * Math.PI / 180;
        public double Th2 { get; set; } = 20 * Math.PI / 180;
        public double Per1 { get; set; } = 0.6;
        public double Per2 { get; set; } = 0.7;
        public double Leng { get; set; } = 100;
        public int N { get; set; } = 10;
        public static Color Color1 { get; set; } = Color.Blue;
        Pen Pen1 = new Pen(Color1);
        public Form1()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", this, "N");
            textBox2.DataBindings.Add("Text", this, "Leng");
            textBox3.DataBindings.Add("Text", this, "Per1");
            textBox4.DataBindings.Add("Text", this, "Per2");
            textBox5.DataBindings.Add("Text", this, "Th1");
            textBox6.DataBindings.Add("Text", this, "Th2");
            button2.ForeColor = Color1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel1.CreateGraphics();
            DrawCarleyTree(N, 180, 310, Leng, -Math.PI / 2);
        }

        private Graphics graphics;
        

        void DrawCarleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCarleyTree(n - 1, x1, y1, Per1 * leng, th + Th1);
            DrawCarleyTree(n - 1, x1, y1, Per2 * leng, th - Th2);
        }

        void DrawLine(double x0, double y0,double x1, double y1)
        {
            Pen1.Color = Color1;
            
            graphics.DrawLine(Pen1, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color1 = colorDialog1.Color;
                button2.ForeColor = Color1;
            }
        }
    }
}
