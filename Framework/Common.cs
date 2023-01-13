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

        public static void FindElement(string locator, string keys)
        {
            GetElement(locator).SendKeys(keys);
        }

        public static void ClickElement(string locator)
        {
            GetElement(locator).Click();
        }

        internal static void SendKeysToElement(string locator, string value)
        {
            GetElement(locator).SendKeys(value);
        }

        internal static string GetElementText(string locator)
        {
            return GetElement(locator).Text;
            //return GetElement(locator).GetAttribute("value"); // kitas budas gauti atgal teksta
        }
    }
}