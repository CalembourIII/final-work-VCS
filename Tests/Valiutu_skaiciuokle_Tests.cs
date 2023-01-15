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

        [Test]
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

        [Test]
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

        [Test]
        public void MaxNumbersAfterCommaSelection()
        {
            Valiutu_skaiciuokle.EnterValue("100");
            System.Threading.Thread.Sleep(3000);

            string result = Valiutu_skaiciuokle.GetAttributeValue();

            //double result = Valiutu_skaiciuokle.GetValueDouble();
            //string[] number = Valiutu_skaiciuokle.GetValueString().Split('.');

            ////string[] parts = number.ToString().Split('.');

            //int skaiciaiPoKablelio = number[0].Length;

            //Assert.IsTrue(skaiciaiPoKablelio == 2);

            Assert.IsTrue(result == "107.72");

        }

    }
}
