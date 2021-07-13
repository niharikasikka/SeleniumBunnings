using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace SpecFlowProject.Specs.Drivers
{
    class GetBrowser
    {
        private static IWebDriver Driver;
        public static IWebDriver InitBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    Driver = new ChromeDriver(@"C:\Users\NiharikaS\source\repos\SpecFlow\specflowrunner\SpecFlowAccelerator\bin\Debug\netstandard2.0");
                    //For headless browser uncomment the following code
                    //options.AddArguments("headless", "disable-gpu", "--test-type", "--ignore-certificate-errors");
                    //options.AddArguments("window-size=1200,1100");
                    //Driver = new ChromeDriver(options);
                    break;
                case "ie":
                    Driver = new InternetExplorerDriver();
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    Driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(3);
                    break;
            }
            Driver.Manage().Window.Maximize();
            return Driver;
        }
        public static void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                if (Driver != null)

                {
                    DateTime time = DateTime.Now;
                    string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");
                    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    screenshot.SaveAsFile(@"C:\Users\NiharikaS\source\repos\SpecFlowProject.Specs\Screenshots\Screenshot" + dateToday + ".png", ScreenshotImageFormat.Png);
                }
            }
            //Close the browser
            Driver.Dispose();

        }
        public static void Cleanup_Close()
        {

            //Close the browser
            Driver.Dispose();
        }

    }
}
