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
            string dateOnPage = Valiutu_skaiciuokle.GetDateValue();                                                         //Step 1
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            Assert.AreEqual(currentDate, dateOnPage);

            List<string> defaultCurrencies = new List<string>                                                               //Step 2
            { "EUR", "USD", "GBP", "PLN", "NOK", "SEK", "CHF", "DKK", 
             "AUD", "CAD", "CNY", "CZK", "JPY", "RON", "TRY", "UAH" };

            foreach (string currency in defaultCurrencies)
            {
                Assert.IsTrue((Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency)), 
                    $"{currency} was not visible on the page");
            }

            string defaultValuePridetiValiuta = "pasirink...";                                                              //Step 3
            Assert.AreEqual(defaultValuePridetiValiuta, Valiutu_skaiciuokle.CheckPridetiValiutaDropdownValue());

            string defaultValueSkaiciaiPoKablelio = "2";                                                                    //Step 4
            Assert.AreEqual(defaultValueSkaiciaiPoKablelio, Valiutu_skaiciuokle.CheckSkaiciaiPoKablelioDropdownValue());
        }

        [Test, Order(2)]
        public void AddRemoveCurrencies()
        {
            List<string> currenciesToRemove = new List<string> { "EUR", "USD", "PLN" };

            foreach (string currency in currenciesToRemove)                                                                 //Step 1                                            
            {
                Valiutu_skaiciuokle.RemoveCurrencyLine(currency);
                Assert.IsFalse(Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency),                                        //Step 2
                    $"{currency} was visible on the page");
            }

            foreach (string currency in currenciesToRemove)                                                                 //Step 3
            {
                Valiutu_skaiciuokle.SelectCurrencyToAdd(currency);
                Assert.IsTrue(Valiutu_skaiciuokle.CheckIfCurrencyVisible(currency),                                         //Step 4
                    $"{currency} was not visible on the page");
            }

            Valiutu_skaiciuokle.SelectCurrencyToAdd(currenciesToRemove[0]);                                                 //Step 5
            Assert.AreEqual(1, Valiutu_skaiciuokle.CheckIfCurrencyNotDoubleAdded(currenciesToRemove[0]));                   //Step 6
        }

        [Test, Order(3)]
        public void NumbersAfterComma()
        {
            //Entering values 1-by-1 because with one line it sends numbers too fast for page to calculate
            //It generates very small delays which are enough for test to catch up with calculations
            string numberToTest = "100,16";
            string currencyToEnterNumber = "EUR";
            int defaultNumbersAfterComma = 2;
            int numbersAfterCommaToTest = 3;
            string currencyToCheckNumberAfterComma = "USD";

            char[] numbers = numberToTest.ToCharArray();                                                                    //Step 1
            foreach(char number in numbers)
            {
                Valiutu_skaiciuokle.EnterCurrencyValue(currencyToEnterNumber, Convert.ToString(number));
            }

            string[] defaultResult = Valiutu_skaiciuokle.GetCurrencyValue(currencyToCheckNumberAfterComma).Split('.');
            int defaultNumbersAfterCommaResult = defaultResult[1].Length;

            Assert.IsTrue(defaultNumbersAfterCommaResult == defaultNumbersAfterComma,                                       //Step 2
                $"Expected {defaultNumbersAfterComma} but got {defaultNumbersAfterCommaResult}");

            Valiutu_skaiciuokle.SelectNumbersAfterComma(Convert.ToString(numbersAfterCommaToTest));                         //Step 3
            Valiutu_skaiciuokle.ClearNumberEntered(currencyToEnterNumber);

            foreach (char number in numbers)                                                                                //Step 4
            {
                Valiutu_skaiciuokle.EnterCurrencyValue(currencyToEnterNumber, Convert.ToString(number));
            }

            string[] result = Valiutu_skaiciuokle.GetCurrencyValue(currencyToCheckNumberAfterComma).Split('.');
            int numbersAfterCommaResult = result[1].Length;

            Assert.IsTrue(numbersAfterCommaResult == numbersAfterCommaToTest,                                               //Step 5
                $"Expected {numbersAfterCommaResult} but got {numbersAfterCommaResult}");
        }
    }
}
