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

        [Test]
        public void IncomeTaxCalculations()
        {
            string salary = "2489,62";
            string npd = "695,00";

            string expectedResultWithNpdEntered = "358,92 €";
            string expectedResultWithoutNpdEntered = "484,44 €";

            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();
            Mokesciu_skaiciuokle.ClearPreEnteredNpdSum();
            Mokesciu_skaiciuokle.EnterNpd(npd);
            System.Threading.Thread.Sleep(500);

            //Mokesciu_skaiciuokle.WaitForFullValueToAppear(npd);
            string actualResultWithNPD = Mokesciu_skaiciuokle.GetValuePajamuMokestis();

            Mokesciu_skaiciuokle.ClickRadioButtonPaskaiciuosSistema();

            string actualResultWithoutNpd = Mokesciu_skaiciuokle.GetValuePajamuMokestis();

            Assert.AreEqual(expectedResultWithNpdEntered, actualResultWithNPD);
            Assert.AreEqual(expectedResultWithoutNpdEntered, actualResultWithoutNpd);
        }

        [Test]
        public void PreviousYearsPensionPercentageOptions()
        {
            string salary = "1234";
            //string year1 = "2019";
            //string year2 = "2023";

            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.SelectYear("2019");
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string ismokamasAtlyginimas2019 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Mokesciu_skaiciuokle.SelectYear("2023");
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string ismokamasAtlyginimas2023 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Assert.AreNotEqual(ismokamasAtlyginimas2019, ismokamasAtlyginimas2023);
        }
    }
}
