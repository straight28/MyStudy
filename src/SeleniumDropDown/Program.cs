using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumDropDown
{
    public class Program
    {

        public static ChromeDriverService _driverService = null;
        public static ChromeOptions _options = null;
        public static ChromeDriver _driver = null;

        public static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Log.txt"));
            Trace.AutoFlush = true;

            Debug.WriteLine("Test 시작");
            // Selenium으로 드롭다운이 있는 사이트 크롤링

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");

                _driver = new ChromeDriver(_driverService, _options);
                _driver.Navigate().GoToUrl("https://prices.lbma.org.uk/precious-metal-prices/#/table");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // IWebElement webDriver = _driver.FindElement(By.XPath("//*[@id='app']/div[2]/div[1]"));
                // IWebElement webDriver = _driver.FindElementByXPath("//*[@id='app']/div[2]/div[1]");
                // IWebElement webDriver = _driver.FindElementByCssSelector("div.table > div.pepper-dropdown.metals-dropdown");

                IWebElement webDriver = _driver.FindElementByClassName("metals-dropdown");
                Debug.WriteLine("DEBUG TEXT 1 예상 골드, 실제 : "+ webDriver.Text);
                webDriver.Click();
                webDriver = _driver.FindElementByCssSelector("#app > div.table > div.pepper-dropdown.metals-dropdown > ul > li:nth-child(1)");
                webDriver.Click();

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                var table = _driver.FindElementByCssSelector("#app > div.table > div.pepper-responsive-table > table");
                var tbody = table.FindElement(By.TagName("tbody"));
                var trs = tbody.FindElements(By.TagName("tr"));

                var count = 0;
                foreach (var tr in trs)
                {
                    var ths = tr.FindElements(By.TagName("th"));

                    foreach (var th in ths)
                    {
                        Console.WriteLine("th: " + th.Text);
                    }

                    var tds = tr.FindElements(By.TagName("td"));

                    foreach (var td in tds)
                    {
                        Console.WriteLine("td: " + td.Text);
                    }
                    count++;

                    if(count == 2)
                    {
                        break;
                    }
                }

                webDriver = _driver.FindElementByClassName("metals-dropdown");
                webDriver.Click();
                Thread.Sleep(2000);
                webDriver = _driver.FindElementByCssSelector("#app > div.table > div.pepper-dropdown.metals-dropdown > ul > li:nth-child(2)");
                webDriver.Click();
                Thread.Sleep(2000);
                webDriver = _driver.FindElementByClassName("metals-dropdown");
                Debug.WriteLine("DEBUG TEXT 1 예상 실버, 실제 : " + webDriver.Text);

                // webDriver = _driver.FindElementByCssSelector("#app > div.table > div.pepper-dropdown.metals-dropdown > ul > li:nth-child(2)");
                // Debug.WriteLine("DEBUG TEXT 2 예상 실버, 실제: " + webDriver.Text);
                // 
                // webDriver = _driver.FindElementByClassName("metals-dropdown");
                // Debug.WriteLine("DEBUG TEXT 2 예상 실버, 실제: " + webDriver.Text);
                // webDriver = _driver.FindElementByCssSelector("#app > div.table > div.pepper-dropdown.metals-dropdown > ul > li:nth-child(3)");
                // webDriver.Click();
                // Debug.WriteLine("DEBUG TEXT 3 예상 리보, 실제: " + webDriver.Text);

                Debug.WriteLine("Test 확인");
            }
            catch (Exception ex)
            {
                
                var text = ex.Message;
                Trace.Write(new StackTrace().GetFrame(0).GetMethod().Name.ToString() + "\n =============== Error ============== \n");
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" 에러 발생.. 내용 : " + text);
                Trace.WriteLine("");

            }
        }
    }
}
