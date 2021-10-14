using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;



namespace ChromeBrowserOpen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" 노래 제목 입력 : ");
            string result = Console.ReadLine();


            IWebDriver driver = new ChromeDriver();

            driver.Url = "Https://www.google.com";
            // 브라우저 최대화
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000);

            driver.FindElement(By.Name("q")).SendKeys(result + " 가사 ");

            Thread.Sleep(3000);

            driver.FindElement(By.Name("btnK")).Click();

            Thread.Sleep(3000);

            var text1 = driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div/div[1]/div[2]"));

            string text2 = text1.Text;

            File.WriteAllText(@"D:\mongo\text.txt", text2);

            Thread.Sleep(1000);


        }
    }
}
