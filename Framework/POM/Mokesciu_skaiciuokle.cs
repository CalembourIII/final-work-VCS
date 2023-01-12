using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.POM
{
    public class Mokesciu_skaiciuokle
    {
        private static string url = "https://tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle";
        private static string acceptCookiesLocator = "//div[@class='fc-footer-buttons']//button[@aria-label='Sutikimas']";

        public static void Open()
        {
            Driver.OpenPage(url);
            Common.ClickElement(acceptCookiesLocator);
        }
    }
}
