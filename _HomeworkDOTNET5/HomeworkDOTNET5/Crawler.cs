using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeworkDOTNET5
{
    public delegate void D1(string url);
    public delegate void D2();

    class Crawler
    {
        public string StartUrl { get; set; } = "";
        public Hashtable urls { get; } = new Hashtable();
        private int cnt = 0;
        public event D1 PageDownloaded;
        public event D2 AllFinished;
        public void Crawl()
        {
            /*string pattern = @"^http";
            string testUrl = "h";
            System.Diagnostics.Debug.WriteLine(Regex.IsMatch(testUrl, pattern));
            return;*/
            DateTime start = DateTime.Now;
            urls.Add(StartUrl, false);
            while (true)
            {
                string cur = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    cur = url;
                }
                if (cur == null || cnt > 10) break;
                string html = Download(cur);
                urls[cur] = true;
                cnt++;
                Parse(html,cur);
            }
            System.Diagnostics.Debug.WriteLine("Crawl Finished");
            System.Diagnostics.Debug.WriteLine((DateTime.Now - start)+" sec");
            AllFinished();
        }

        public string Download(string url)
        {
            System.Diagnostics.Debug.WriteLine("Downloading: " + url);
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = cnt.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                System.Diagnostics.Debug.WriteLine("Download Success");
                PageDownloaded(url);
                return html;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return "";
            }
        }

        public void Parse(string html,string cur)
        {
            System.Diagnostics.Debug.WriteLine("Parsing");
            string str = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(str).Matches(html);
            foreach(Match match in matches)
            {
                str=match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\'','#',' ','>');
                string UrlPattern = @"^http";
                if (!str.Contains(cur) && !Regex.IsMatch(str, UrlPattern))
                {
                    if (Regex.IsMatch(str, @"^./"))
                    {
                        str = cur + str.Substring(1);
                    }
                    else str = cur + str;

                }
                string PagePattern = @"(html|htm|jsp|aspx|php)$";
                if (str.Length == 0||!Regex.IsMatch(str,PagePattern)) continue;
                System.Diagnostics.Debug.WriteLine(str);
                if (urls[str] == null) urls[str] = false;
                
            }
            System.Diagnostics.Debug.WriteLine("Parsing Done");
        }
    }
}
