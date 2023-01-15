using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Framework.POM
{
    public class Valiutu_skaiciuokle
    {
        private static string url = "https://tax.lt/skaiciuokles/valiutu_skaiciuokle";
        private static string acceptCookiesLocator = "//div[@class='fc-footer-buttons']//button[@aria-label='Sutikimas']";

        private static string datePickerLocator = ("//*[@id='rate_date']");

        private static string removeCurrencyEurLocator = "//input[contains(@name,'EUR')]/preceding-sibling::a[@class='icon-minus remove_line']";
        private static string removeCurrencyUsdLocator = "//input[contains(@name,'USD')]/preceding-sibling::a[@class='icon-minus remove_line']";
        private static string removeCurrencyPlnLocator = "//input[contains(@name,'PLN')]/preceding-sibling::a[@class='icon-minus remove_line']";

        private static string pridetiValiutaDropdownLocator = "//*[@id='add_currency']";
        private static string skaiciaiPoKablelioDropdownLocator = "//*[@id='rounding']";


        private static string enterValue = "//*[@id='EUR']";
        private static string getValue = "//*[@id='USD']";

        public static void Open()
        {
            Driver.OpenPage(url);
            Common.ClickElement(acceptCookiesLocator);
        }

        internal static string GenerateCurrencyLineLocator(string currency)
        {
            return $"//input[contains(@name,'{currency}')]/preceding-sibling::a[@class='icon-minus remove_line']";
        }

        public static void RemoveCurrencyLine(string currency)
        {
            string locator = GenerateCurrencyLineLocator(currency);
            Common.ClickElement(locator);
        }

        public static void EnterValue(string value)
        {
            Common.SendKeysToElement(enterValue, value);
        }

        public static string GetDateValue()
        {
            return Common.GetElementAttributeValue(datePickerLocator);
        }

        public static string GetAttributeValue()
        {
            return Common.GetElementAttributeValue(getValue);
        }

        public static bool CheckIfCurrencyVisible(string currency)
        {
            string locator = GenerateCurrencyLineLocator(currency);
            return Common.CheckIfElementVisible(locator);
        }

        public static string CheckPridetiValiutaDropdownValue()
        {
            return Common.GetSelectedDropdownValue(pridetiValiutaDropdownLocator);
        }

        public static string CheckSkaiciaiPoKablelioDropdownValue()
        {
            return Common.GetSelectedDropdownValue(skaiciaiPoKablelioDropdownLocator);
        }
    }
}
