using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jsonUrl = "https://prices.lbma.org.uk/json/platinum_am.json";
            //            webBrowser2.Navigate(jsonUrl);
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //            var test = webBrowser2.DocumentText;

            //             var data = JsonConvert.DeserializeObject(test);
            //             Console.WriteLine(data);
            //             string msg = e.Url + " 로딩 완료!";
            //             MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var test = Request_Json();
            ParseJson(test);
            Console.WriteLine(test);
        }

        private string Request_Json()
        {
            string result = null;
            string url = "https://prices.lbma.org.uk/json/platinum_am.json";
            Console.WriteLine("url : " + url);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private void ParseJson(String json)
        {
            DataTable dt = new DataTable();

            var objs = JArray.Parse(json).ToObject<List<object>>();
            // string bitcoin_price_str = objs[0]["2021"].ToString().Trim().Replace(",", "");

            // JObject obj = JObject.Parse(json[0].ToString());
            JArray array = JArray.Parse(json);

            dt.Columns.Add("d");
            dt.Columns.Add("v1");
            dt.Columns.Add("v2");
            dt.Columns.Add("v3");

            

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i]["d"].ToString().Substring(0, 4) == DateTime.Now.ToString("yyyy"))
                {
                    var d = array[i]["d"].ToString();
                    var v = array[i]["v"].ToString();
                    var re = "";

                    // Console.WriteLine(d);
                    // Console.WriteLine(v);
                    re = v.Replace("\r\n", "");
                    re = re.Replace("[", "");
                    re = re.Replace("]", "");
                    re = re.Replace(" ", "");
                    
                    var arr = re.Split(',');

                    DataRow row = dt.NewRow();

                    row["d"] = d;
                    row["v1"] = arr[0].ToString();
                    row["v2"] = arr[1].ToString();
                    row["v3"] = arr[2].ToString();

                    Console.WriteLine(arr[0]);
                    Console.WriteLine(arr[1]);
                    Console.WriteLine(arr[2]);

                    dt.Rows.Add(row);
                }
            }

            dt.DefaultView.Sort = "d desc";
            dataGridView1.DataSource = dt;
        }

    }
}
