using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Framework
{
    internal class Common
    {
        private static IWebElement GetElement(string locator)
        {
           return Driver.GetDriver().FindElement(By.XPath(locator));
        }

        public static void FindElement(string locator)
        {
            GetElement(locator);
        }

        public static void ClickElement(string locator)
        {
            GetElement(locator).Click();
        }

        internal static void SendKeysToElement(string locator, string keys)
        {
            GetElement(locator).SendKeys(keys);
        }

        internal static string GetElementText(string locator)
        {
            return GetElement(locator).Text;
            //return GetElement(locator).GetAttribute("value"); // kitas budas gauti atgal teksta
        }

        internal static void ClearInputElement(string locator)
        {
            GetElement(locator).Clear();
        }

        internal static SelectElement GetSelectElement(string locator)
        {
            IWebElement element = GetElement(locator);
            return new SelectElement(element);
        }

        internal static void SelectOptionByValue(string selectElementLocator, string value)
        {
            SelectElement selectElement = GetSelectElement(selectElementLocator);

            selectElement.SelectByValue(value);
        }

        //internal static void WaitForFullValue(string locator, string keys)
        //{
        //    WebDriverWait wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(3));
        //    wait.Until(d => d.FindElement(By.XPath(locator)).SendKeys(keys));
        //}
    }
}