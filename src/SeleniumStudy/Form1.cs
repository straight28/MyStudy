using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumStudy
{
    public partial class Form1 : Form
    {

        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
        public Form1()
        {
            InitializeComponent();

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disalbe-gpu");

            }
            catch (Exception ex)
            {
                var text = ex.Message;
                Trace.WriteLine(text);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _driver = new ChromeDriver(_driverService, _options);
                
                _driver.Navigate().GoToUrl("https://www.kofiabond.or.kr/");

                // iframe이란 다른 웹 페이지 또는 다른 HTML 문서에 HTML문서를 말한다.
                // 쉽게 하나의 페이지에 Javascript로 다른 페이지를 끼워 넣은 것을 말한다.

                // 그러나 앞서 소개한 XPath 문법으로 대부분의 element를 selenium을 통해서 조작할 수 있지만, 
                // iframe내부의 element는 selenium 에서 바로 조작 할 수 없다.


                // 사이트의 프레임을 빠져나와 초기값으로 돌아간다.
                _driver.SwitchTo().DefaultContent();
                // 그 중 진입할 프레임을 선택해 준다.
                _driver.SwitchTo().Frame("fraAMAKMain");
                // 대기 설정. (find로 객체를 찾을 때까지 검색이 되지 않으면 대기하는 시간, 초단위)
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //XPath 카피 (주의점, 큰 따옴표를 작은따옴표로 변경해야함)
                var element = _driver.FindElementByXPath("//*[@id='group25']");
                element.Click();


                Application.Exit();
            }
            catch (Exception ex)
            {
                var text = ex.Message;
                Trace.WriteLine(text);
            }
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_driver.Quit();
        }
    }
}
