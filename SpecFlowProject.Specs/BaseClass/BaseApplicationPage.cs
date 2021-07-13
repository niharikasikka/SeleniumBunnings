using OpenQA.Selenium;


namespace SmokeTest.BaseClass
{
    class BaseApplicationPage
    {
        public IWebDriver Driver { get; private set; }

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }

}
