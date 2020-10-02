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
    public partial class Form1 : System.Windows.Forms.Form
    {
        static readonly ProductList pl = new ProductList();
        OrderService os = new OrderService(pl);
        int currentIndex = 0;
        public Form1()
        {
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            InitializeComponent();
            orderBindingSource.DataSource = os.Ol;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIndex = e.RowIndex;
            orderLineDetailBindingSource.DataSource = os.Ol[e.RowIndex].Od.L;
            
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(pl);
            form2.Text = "增加订单";
            if (form2.ShowDialog()==DialogResult.OK)
            {
                if (form2.Client != "")
                {
                    os.AddOrder(form2.Client, form2.ClientDemands);
                    orderBindingSource.ResetBindings(true);
                }
            }
        }

        private void RemoveOrderButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons mesbutton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认要删除吗？", "删除", mesbutton);
            if (dr == DialogResult.OK)
            {
                os.Ol.Remove(os.Ol[currentIndex]);
                orderBindingSource.ResetBindings(true);
            }
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(pl);
            form2.Text = "修改订单";
            if (form2.ShowDialog() == DialogResult.OK)
            {
                if (form2.Client != "")
                {
                    os.Ol.Remove(os.Ol[currentIndex]);
                    os.AddOrder(form2.Client, form2.ClientDemands);
                    orderBindingSource.ResetBindings(true);
                }
            }
        }

        private void QueryAllButton_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.Ol;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (form3.ShowDialog()==DialogResult.OK)
            {
                os.Import(form3.filename);
                orderBindingSource.ResetBindings(true);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (form3.ShowDialog() == DialogResult.OK)
            {
                os.Export(form3.filename);
            }
        }

        private void QuerySpecificOrderButton_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                orderBindingSource.DataSource = os.GetOrder(form4.id, form4.goodsname, form4.client, form4.money);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
