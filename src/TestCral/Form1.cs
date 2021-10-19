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

namespace TestCral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetHtmlString();
            //WebRequestTest();
        }


        private void GetHtmlString()
        {

            var test = Request_Json();
            ParseJson(test);
            Console.WriteLine(test);

        }

        private string Request_Json()
        {
            string result = null;
            string url = "https://www.lme.com/api/trading-data/day-delayed?datasourceId=1a0ef0b6-3ee6-4e44-a415-7a313d5bd771";
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

            var array = JObject.Parse(json);

            Console.WriteLine("test1 " + array["Rows"][0]);

            var array1 = array["Rows"][0];

            Console.WriteLine("test2 " + array1["RowTitle"]);

            var array2 = array1["Values"];

            Console.WriteLine("test3 " + array2[0]);
            Console.WriteLine("test3 " + array2[1]);



        }


        private string WebRequestTest()
        {
            WebRequest request = WebRequest.Create("https://www.lme.com/en/Metals/Non-ferrous/LME-Aluminium#Trading+day+summary"); // 호출할 url
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            Console.WriteLine(responseFromServer); // response 출력


            var start = responseFromServer.IndexOf("data-set-table__table");
            var end = responseFromServer.IndexOf("data-set-table__supporting");

            var content = responseFromServer.Substring(start, end);

            Console.WriteLine("Test html");

            reader.Close();
            dataStream.Close();
            response.Close();

            return "test";
        }
    }
}
