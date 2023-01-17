namespace Framework.POM
{
    public class Valiutu_skaiciuokle
    {
        private static string url = "https://tax.lt/skaiciuokles/valiutu_skaiciuokle";
        private static string acceptCookiesLocator = "//div[@class='fc-footer-buttons']//button[@aria-label='Sutikimas']";

        private static string datePickerLocator = ("//*[@id='rate_date']");

        private static string pridetiValiutaDropdownLocator = "//*[@id='add_currency']";
        private static string skaiciaiPoKablelioDropdownLocator = "//*[@id='rounding']";

        public static void Open()
        {
            Driver.OpenPage(url);
            Common.ClickElement(acceptCookiesLocator);
        }

        internal static string GenerateEnterCurrencyValueLocator(string currency)
        {
            return $"//*[@id='{currency}']";
        }

        public static void RemoveCurrencyLine(string currency)
        {
            string locator = $"//input[contains(@name,'{currency}')]/preceding-sibling::a[@class='icon-minus remove_line']";
            Common.ClickElement(locator);
        }

        public static void EnterCurrencyValue(string currency, string value)
        {
            string locator = GenerateEnterCurrencyValueLocator(currency);
            Common.SendKeysToElement(locator, value);
        }

        public static void ClearNumberEntered(string currency)
        {
            string locator = GenerateEnterCurrencyValueLocator(currency);
            Common.ClearInputElement(locator);
        }

        public static string GetCurrencyValue(string currency)
        {
            string locator = GenerateEnterCurrencyValueLocator(currency);
            return Common.GetElementAttributeValue(locator);
        }

        public static string GetDateValue()
        {
            return Common.GetElementAttributeValue(datePickerLocator);
        }

        public static bool CheckIfCurrencyVisible(string currency)
        {
            string locator = GenerateEnterCurrencyValueLocator(currency);
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

        public static void SelectCurrencyToAdd(string currency)
        {
            Common.SelectOptionByValue(pridetiValiutaDropdownLocator, currency);
        }

        public static int CheckIfCurrencyNotDoubleAdded(string currency)
        {
            string locator = GenerateEnterCurrencyValueLocator(currency);
            return Common.CountElementsOnPage(locator);
        }

        public static void SelectNumbersAfterComma(string number)
        {
            Common.SelectOptionByValue(skaiciaiPoKablelioDropdownLocator, number);
        }
    }
}
