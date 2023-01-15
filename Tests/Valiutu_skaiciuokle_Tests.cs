using Framework.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Valiutu_skaiciuokle_Tests : BaseTests
    {
        [SetUp]
        public void Open()
        {
            Valiutu_skaiciuokle.Open();
        }

        [Test, Order(1)]
        public void DefaultValues()
        {
            //Step 1. Check date on page if today
            string dateOnPage = Valiutu_skaiciuokle.GetDateValue();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            Assert.AreEqual(currentDate, dateOnPage);

            //Step 2. Check if default currencies are on the page
            List<string> defaultCurrencies = new List<string> 
            { "EUR", "USD", "GBP", "PLN", "NOK", "SEK", "CHF", "DKK", 
             "AUD", "CAD", "CNY", "CZK", "JPY", "RON", "TRY", "UAH" };

            foreach (string currency in defaultCurrencies)
            {
                Assert.IsTrue(Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency));
            }

            //Step 3. Check if "Pridėti valiutą" dropdown menu is set on default value
            string defaultValuePridetiValiuta = "pasirink...";
            Assert.AreEqual(defaultValuePridetiValiuta, Valiutu_skaiciuokle.CheckPridetiValiutaDropdownValue());


            //Step 4. Check if "skaičiai po kablelio" dropdown menu is set on default value "2"
            string defaultValueSkaiciaiPoKablelio = "2";
            Assert.AreEqual(defaultValueSkaiciaiPoKablelio, Valiutu_skaiciuokle.CheckSkaiciaiPoKablelioDropdownValue());
        }

        [Test, Order(2)]
        public void AddRemoveCurrencies()
        {
            List<string> currenciesToRemove = new List<string> { "EUR", "USD", "PLN" };

            foreach (string currency in currenciesToRemove)
            {
                Valiutu_skaiciuokle.RemoveCurrencyLine(currency);
                Assert.IsFalse(Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency));
            }

            foreach (string currency in currenciesToRemove)
            {
                Valiutu_skaiciuokle.SelectCurrencyToAdd(currency);
                Assert.IsTrue(Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency));
            }

            Valiutu_skaiciuokle.SelectCurrencyToAdd(currenciesToRemove[0]);
            Assert.AreEqual(1, Valiutu_skaiciuokle.CheckIfCurrencyNotDoubleAdded(currenciesToRemove[0]));
        }

        [Test, Order(3)]
        public void NumbersAfterCommaSelection()
        {
            ///Entering values 1-by-1 because with one line it sends numbers too fast for page to calculate
            string numberToTest = "100,15";
            string currencyToEnterNumber = "EUR";
            int numbersAfterCommaToTest = 3;
            string currencyToCheckNumberAfterComma = "USD";

            char[] numbers = numberToTest.ToCharArray();
            foreach(char number in numbers)
            {
                Valiutu_skaiciuokle.EnterCurrencyValue(currencyToEnterNumber, Convert.ToString(number));
            }

            Valiutu_skaiciuokle.SelectNumbersAfterComma(Convert.ToString(numbersAfterCommaToTest));
            Valiutu_skaiciuokle.ClearNumberEntered(currencyToEnterNumber);

            foreach (char number in numbers)
            {
                Valiutu_skaiciuokle.EnterCurrencyValue(currencyToEnterNumber, Convert.ToString(number));
            }

            string[] result = Valiutu_skaiciuokle.GetCurrencyValue(currencyToCheckNumberAfterComma).Split('.');
            int numbersAfterComma = result[1].Length;

            Assert.IsTrue(numbersAfterComma == numbersAfterCommaToTest);
        }
    }
}
