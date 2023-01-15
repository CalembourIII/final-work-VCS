using Framework;
using Framework.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Mokesciu_skaiciuokle_Tests : BaseTests
    {
        [SetUp]
        public void Open()
        {
            Mokesciu_skaiciuokle.Open();
        }

        [Test]
        public void MainFunctionalities()
        {
            string salary = "1518,68";
            string npd = "500";

            Mokesciu_skaiciuokle.ClickRadioButtonIRankas();
            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();
            Mokesciu_skaiciuokle.EnterNpd(npd);
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string result = Mokesciu_skaiciuokle.GetValueVisaDarboVietosKaina();

            Assert.IsTrue(result != null);
        }

        /// <summary>
        /// 
        /// This test is uses a Wait method after value are entered, as we have to wait a moment for calculations 
        /// on page to be visible.
        /// 
        /// Methods waits until expected result with NPD entered is visible. This also becomes the assertion of tests.
        /// In case of anything else than expected result visible - the test fails.
        /// 
        /// </summary>

        [Test]
        public void IncomeTaxCalculations()
        {
            string salary = "2489,62";
            string npd = "695,00";

            string expectedResultWithNpdEntered = "358,92 €";
            string expectedResultWithoutNpdEntered = "484,44 €";

            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();
            Mokesciu_skaiciuokle.ClearPreEnteredNpdValue();
            Mokesciu_skaiciuokle.EnterNpd(npd);

            Assert.IsTrue(Mokesciu_skaiciuokle.WaitForFullValueToAppear(expectedResultWithNpdEntered));

            Mokesciu_skaiciuokle.ClickRadioButtonPaskaiciuosSistema();

            string actualResultWithoutNpd = Mokesciu_skaiciuokle.GetValuePajamuMokestis();

            Assert.AreEqual(expectedResultWithoutNpdEntered, actualResultWithoutNpd);
        }

        [Test]
        public void PreviousYearsPensionPercentageOptions()
        {
            string salary = "1234";
            string year1 = "2019";
            string year2 = "2023";

            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.SelectYear(year1);
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string ismokamasAtlyginimas2019 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Mokesciu_skaiciuokle.SelectYear(year2);
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string ismokamasAtlyginimas2023 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Assert.AreNotEqual(ismokamasAtlyginimas2019, ismokamasAtlyginimas2023);
        }
    }
}
