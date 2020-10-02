using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Form4 : Form
    {
        public int id { get; set; } = -1;
        public string goodsname { get; set; } = "";
        public string client { get; set; } = "";
        public double money { get; set; } = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") id = int.Parse(textBox1.Text);
            if (textBox3.Text != "") goodsname = textBox3.Text;
            if (textBox2.Text != "") client = textBox2.Text;
            if (textBox4.Text != "") money = double.Parse(textBox4.Text);
        }
    }
}
