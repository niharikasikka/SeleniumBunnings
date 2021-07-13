using OpenQA.Selenium;
using SmokeTest.BaseClass;
using SpecFlowProject.Specs.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Specs.Pages
{
    class SearchPage : BaseApplicationPage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        { }

        public By QuanityButton = By.XPath("//body/div[@id='__next']/main[1]/div[1]/div[3]/div[1]/div[4]/article[1]/a[1]/div[3]/div[1]/div[1]/span[1]/div[1]/button[2]");
        public By CartIcon = By.XPath("//a[@id='icon-cart']");
        internal void AddQuantity(int quantity)
        {
            CommonFunctions.ExplicitWait(Driver,QuanityButton);
            CommonFunctions.GetClick(Driver.FindElement(QuanityButton));
            CommonFunctions.ExplicitWait(Driver, QuanityButton);
            CommonFunctions.GetClick(Driver.FindElement(QuanityButton));

        }

        internal void ClickOnBasket()
        {
            CommonFunctions.ExplicitWait(Driver, CartIcon);
            CommonFunctions.GetClick(Driver.FindElement(CartIcon));
        }
    }
}
