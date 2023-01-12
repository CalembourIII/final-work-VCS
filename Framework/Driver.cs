using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Driver
    {
       private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void CreateDriver()
        {
            driver = new ChromeDriver();
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }

        public static void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
