using Framework.POM;
using NUnit.Framework;

namespace Tests
{
    internal class Mokesciu_skaiciuokle_Tests : BaseTests
    {
        [SetUp]
        public void Open()
        {
            Mokesciu_skaiciuokle.Open();
        }

        [Test, Order(1)]
        public void MainFunctionalities()
        {
            string salary = "1518,68";
            string npd = "500";

            Mokesciu_skaiciuokle.ClickRadioButtonIRankas();                                                 //Step 1
            Mokesciu_skaiciuokle.EnterSalary(salary);                                                       //Step 2
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();                                           //Step 3
            Mokesciu_skaiciuokle.EnterNpd(npd);                                                             //Step 4
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();                                   //Step 5

            string result = Mokesciu_skaiciuokle.GetValueVisaDarboVietosKaina();

            Assert.IsTrue(result != null, "Expected 'Any value' but got null");                           //Step 6
        }

        /// <summary>
        /// 
        /// This test is uses a Wait method after value are entered, as we have to wait a moment for calculations 
        /// on page to be visible. Method waits until expected result with NPD entered is visible. 
        /// This also becomes one of the the assertions of the test.
        /// In case of anything else than expected result visible - the test fails.
        /// 
        /// </summary>

        [Test, Order(2)]
        public void IncomeTaxCalculations()
        {
            string salary = "2489,62";
            string npd = "695,00";

            string expectedResultWithNpdEntered = "358,92 €";
            string expectedResultWithoutNpdEntered = "484,44 €";

            Mokesciu_skaiciuokle.EnterSalary(salary);                                                       //Step 1
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();                                           //Step 2
            Mokesciu_skaiciuokle.ClearPreEnteredNpdValue();                                                 
            Mokesciu_skaiciuokle.EnterNpd(npd);                                                             //Step 3

            Assert.IsTrue(Mokesciu_skaiciuokle.WaitForFullValueToAppear(expectedResultWithNpdEntered));     //Step 5

            Mokesciu_skaiciuokle.ClickRadioButtonPaskaiciuosSistema();                                      //STep 4

            string actualResultWithoutNpd = Mokesciu_skaiciuokle.GetValuePajamuMokestis();

            Assert.AreEqual(expectedResultWithoutNpdEntered, actualResultWithoutNpd);                       //Step 5
        }

        [Test, Order(3)]
        public void PreviousYearsSalaryCalculation()
        {
            string salary = "1234";
            string year1 = "2019";
            string year2 = "2023";

            Mokesciu_skaiciuokle.EnterSalary(salary);                                                       //Step 1
            Mokesciu_skaiciuokle.SelectYear(year1);                                                         //Step 2
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();                                   //Step 3

            string ismokamasAtlyginimas2019 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Mokesciu_skaiciuokle.SelectYear(year2);                                                         //Step 4
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();                                   //Step 5

            string ismokamasAtlyginimas2023 = Mokesciu_skaiciuokle.GetValueAtlyginimasIRankas();

            Assert.AreNotEqual(ismokamasAtlyginimas2019, ismokamasAtlyginimas2023);                         //Step 6
        }
    }
}
