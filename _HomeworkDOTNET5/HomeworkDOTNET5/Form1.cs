using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HomeworkDOTNET5
{
    public partial class Form1 : Form
    {
        private Crawler crawler = new Crawler();
        
        public Form1()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.AllFinished += Crawler_Finished;
        }
        private void Crawler_Finished()
        {
            MessageBox.Show("所有网页爬行结束");
        }
        private void Crawler_PageDownloaded(string url)
        {
            if (this.listBox1.InvokeRequired)
            {
                Action<string> action = this.AddUrl;
                this.Invoke(action, new object[] { url });
            }
            else AddUrl(url);
        }

        private void AddUrl(string url)
        {
            listBox1.Items.Add(url);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "https://www.cnblogs.com";
            StartCrawler();
        }
        private async void StartCrawler()
        {
            crawler.StartUrl = textBox1.Text;
            listBox1.Items.Clear();
            Task task = Task.Run(() => crawler.Crawl());
            await task;
        }
        
    }
}
