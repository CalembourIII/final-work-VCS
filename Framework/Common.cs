using Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    internal class Common
    {
        private static IWebElement GetElement(string locator)
        {
           return Driver.GetDriver().FindElement(By.XPath(locator));
        }
        public static void ClickElement(string locator)
        {
            Driver.GetDriver().FindElement(By.XPath(locator)).Click();
        }

        public static void FindElement(string locator, string keys)
        {
            Driver.GetDriver().FindElement(By.XPath(locator)).SendKeys(keys);
        }
    }
}