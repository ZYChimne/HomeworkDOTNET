using Store;
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
    public partial class Form2 : System.Windows.Forms.Form
    {
        public string Client { get; set; } = "";
        public List<string> Products { get; set; } = new List<string>();
        public List<ClientDemand> ClientDemands = new List<ClientDemand>();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ProductList productList) : this()
        {
            foreach(Product p in productList.L)
            {
                Products.Add(p.Name);
            }
            comboBox1.DataSource = Products;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Client = textBox1.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            if (n > 0)
            {
                foreach(ClientDemand c in ClientDemands)
                {
                    if (c.Name == comboBox1.Text) c.Num += n;
                }
                ClientDemand tempCd = new ClientDemand(comboBox1.Text, n);
                ClientDemands.Add(tempCd);
                richTextBox1.Text += "物品: "+comboBox1.Text +"  数量："+ n.ToString() + "\n";
            }
            else MessageBox.Show("输入的数量无效");
        }
    }
}
