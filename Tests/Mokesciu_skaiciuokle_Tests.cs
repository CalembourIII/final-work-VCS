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
        public void CheckMainFunctionalities()
        {
            string salary = "1518.68";
            string npd = "500";

            Mokesciu_skaiciuokle.ClickRadioButtonIRankas();
            Mokesciu_skaiciuokle.EnterSalary(salary);
            Mokesciu_skaiciuokle.ClickRadioButtonNurodysiuPats();
            Mokesciu_skaiciuokle.EnterNpd(npd);
            Mokesciu_skaiciuokle.ClickCheckboxKaupiuPensijaiPapildomai();

            string result = Mokesciu_skaiciuokle.GetValueVisaDarboVietosKaina();

            Assert.IsTrue(result != null);
        }
    }
}
