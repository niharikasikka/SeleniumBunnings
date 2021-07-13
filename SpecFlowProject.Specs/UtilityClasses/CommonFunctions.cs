using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Specs.Data;
using System;
using System.Threading;

namespace SpecFlowProject.Specs.UtilityClasses
{
    class CommonFunctions
    {

        public static string GetResourceValue(string ResourceName)
        {
            //Using URL variable from resources file
            string value = Resource.ResourceManager.GetString(ResourceName);
            return value;
        }
        public static void GetUrl(IWebDriver Driver, string url)
        {
            //Thread.Sleep(5000);
            string urlValue = GetResourceValue(url);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
            Driver.Navigate().GoToUrl(urlValue);
        }

        /*This function will be used to enter text to any textfield*/
        public static void EnterText(IWebElement element, string text)
        {
            //string enterText = GetResourceValue(text);
            element.Click();
            element.Clear();
            element.SendKeys(text);

        }
        //Function to click any element or button
        internal static void GetClick(IWebElement element)
        {
            try
            {
                Thread.Sleep(2);
                if (element.Displayed)
                {
                    element.Click();
                    Thread.Sleep(5);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        internal static void ClearCache(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("chrome://settings/clearBrowserData");
            Thread.Sleep(5000);
            Driver.SwitchTo().ActiveElement();
            Thread.Sleep(5000);
            Driver.FindElement(By.CssSelector("* /deep/ #clearBrowsingDataConfirm")).Click();
            Thread.Sleep(5000);

        }
        internal static void ExplicitWait(IWebDriver Driver, By element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            wait.Until(x => x.FindElement(element));
        }

        internal static void Cleanup_Close(IWebDriver Driver)
        {
            //Close the browser
            Driver.Dispose();
        }

        public static bool IsElementDisplayed(IWebDriver driver, By element)
        {
            if (driver.FindElements(element).Count > 0)
            {
                if (driver.FindElement(element).Displayed)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        internal static int Nav_Max(IWebDriver driver, IWebElement arrow_Element)
        {
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                if (arrow_Element.Displayed)
                {
                    j++;
                    arrow_Element.Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }
            return j;
        }
        //method to scroll down the page
        public static void ScrollDownPage(IWebDriver driver, By element)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(element));
        }

        //switch to frame by frame name

        public static void SwitchFrameName(IWebDriver driver, By frame)
        {

            WebDriverWait waitAgency = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitAgency.Until(c => c.FindElement(frame));
            driver.SwitchTo().Frame(driver.FindElement(frame));
        }

        //switch to default frame
        public static void SwitchDefaultFrame(IWebDriver driver, By frame)
        {

            WebDriverWait waitAgency = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitAgency.Until(c => c.FindElement(frame));
            driver.SwitchTo().DefaultContent();
        }

        public static string GetPageTitle(IWebDriver driver)
        {
            String pageTitle = "";
            try
            {
                pageTitle = driver.Title;
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Fetch Page Title");
            }
            return pageTitle;
        }

        public static void navigateBrowserBack(IWebDriver driver)
        {
            try
            {
                driver.Navigate().Back();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To Navigate Back In Current Browser Session");
            }
        }
        //Right click function
        public void RightClick(IWebDriver driver, By elementLocator)
        {
            try
            {
                Actions action = new Actions(driver);
                action.ContextClick(driver.FindElement(elementLocator)).Perform();
            }
            catch (Exception e)
            {
                throw new Exception("Failed To right click on the element");
            }

        }

        public static void AssertStringEquals(string actual, string expected, string message)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch (Exception e)
            {
                throw new Exception("Actual result is not equal to expected result");
            }
        }

      

        public static void assertIntTrue(bool actual, string message)
        {
            try
            {
                Assert.IsTrue(actual, message);
            }
            catch (Exception e)
            {
                throw new Exception("Result is not true");
            }

        }

       
    public static void SelectDropDown(By locator, String val, IWebDriver driver)
    {
        SelectElement dropdownValue = new SelectElement(driver.FindElement(locator));
        dropdownValue.SelectByText(val);
    }


    //method to generate random number
    public int GenerateRandomNum(int num)
    {
        Random rand = new Random();
        int upperBound = 0;
        if (num == 3)
        {
            upperBound = 999;

        }
        else if (num == 2)
        {
            upperBound = 99;
        }
            int randNum = rand.Next(upperBound);
        return randNum;
    }
        /*  public static bool IsManageJobFound(string job)
          {
              SearchJob_Element.SendKeys(CommonFunctions.GetResourceValue(job));
              FilterButton_Element.Click();
              //Thread.Sleep(2000);
              ViewJob_Element.Click();
              return true;
          } 
       */
        public static void EnterKeyPress(By objectName, IWebDriver driver) 
        {

		try {
                IWebElement txtBox = driver.FindElement(objectName);
                txtBox.SendKeys(Keys.Enter);

            } catch (Exception e) {

		}
}
        public static Boolean IsLoadComplete(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("loaded")
                    || ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }
    }
}
