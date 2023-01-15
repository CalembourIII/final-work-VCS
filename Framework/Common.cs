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
        private static IWebElement FindElement(string locator)
        {
            return Driver.GetDriver().FindElement(By.XPath(locator));
        }

        internal static List<IWebElement> FindElements(string locator)
        {
            return Driver.GetDriver().FindElements(By.XPath(locator)).ToList();
        }

        public static void ClickElement(string locator)
        {
            FindElement(locator).Click();
        }

        internal static void SendKeysToElement(string locator, string keys)
        {
            FindElement(locator).SendKeys(keys);
        }

        internal static string GetElementText(string locator)
        {
            return FindElement(locator).Text;
        }

        internal static void ClearInputElement(string locator)
        {
            FindElement(locator).Clear();
        }

        internal static SelectElement GetSelectElement(string locator)
        {
            IWebElement element = FindElement(locator);
            return new SelectElement(element);
        }

        internal static void SelectOptionByValue(string selectElementLocator, string value)
        {
            SelectElement selectElement = GetSelectElement(selectElementLocator);

            selectElement.SelectByValue(value);
        }

        internal static bool WaitForFullValue(string locator, string value)
        {
            WebDriverWait wait = new WebDriverWait(Driver.GetDriver(), TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(FindElement(locator), value));
        }
        internal static string GetElementAttributeValue(string locator)
        {
            return FindElement(locator).GetAttribute("value");
        }

        internal static bool CheckIfElementVisible(string locator)
        {
            int result = FindElements(locator).Count;
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static int CountElementsOnPage(string locator)
        {
            return FindElements(locator).Count;
        }

        internal static string GetSelectedDropdownValue(string selectElementLocator)
        {
            SelectElement selectElement = GetSelectElement(selectElementLocator);

            return selectElement.SelectedOption.Text;
        }
    }
}