using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Framework
{
    public class Driver
    {
       private static IWebDriver driver;

        public static void CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-notifications");
            options.AddArgument("start-maximized");
            //options.AddArgument("headless");  --start-maximized    start-maximized
            //options.AddArgument("window-size=1920,1080");
            driver = new ChromeDriver(options);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }

        public static void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void TakeScreenshot(string testMethodName)
        {
            string screenshotsDirectoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}screenshots";

            string screenshotName = $"{screenshotsDirectoryPath}\\scr-{testMethodName}-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.png";

            Directory.CreateDirectory(screenshotsDirectoryPath);
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
        }
    }
}
