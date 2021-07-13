using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SmokeTest.BaseClass;
using SpecFlowProject.Specs.Data;
using SpecFlowProject.Specs.UtilityClasses;
using System;
using System.Threading;

namespace SpecFlowAccelerator
{

     class ReviewCartPage : BaseApplicationPage
    {
        public ReviewCartPage(IWebDriver driver) : base(driver)
        { }
        By ReviewCartText => By.CssSelector("#reviewCart");
        By AddedItems_Cart => By.XPath("//body/div[@id='__next']/main[1]/div[1]/div[3]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]");

        //variables
        WebDriverWait waitAgency;
        //Methods
      
        internal void VerifyResults_ReviewCart(String AddedItem)
        {
            CommonFunctions.ExplicitWait(Driver, ReviewCartText);
            Assert.IsTrue(Driver.FindElement(ReviewCartText).Displayed, "User is not on review cart page");
            Assert.IsTrue(Driver.FindElement(AddedItems_Cart).Text.Contains(AddedItem), "Added item is not displayed in the cart");

        }
    }
}