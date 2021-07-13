using OpenQA.Selenium;
using SmokeTest.BaseClass;
using SpecFlowProject.Specs.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Specs.Pages
{
    class ProductDetailsPage : BaseApplicationPage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        { }

        public By AddToCartButton => By.XPath("//body/div[@id='__next']/main[1]/div[1]/div[3]/div[2]/div[1]/div[5]/section[1]/div[1]/div[1]/div[2]/div[1]/button[1]");
        public By ProductText => By.XPath("//div//h1[contains(@class,'MuiTypography-root productItemName  MuiTypography-h1')]");

        internal string AddToCart_ProductDetailsPage(string AddedItem)
        {
            //Wait for element visibility
            CommonFunctions.ExplicitWait(Driver, AddToCartButton);

                AddedItem = Driver.FindElement(ProductText).Text;
                //Add to cart 
                Driver.FindElement(AddToCartButton).Click();
        
            return AddedItem;

        }
    }
}
