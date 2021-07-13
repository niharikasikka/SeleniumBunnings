using OpenQA.Selenium;
using SmokeTest.BaseClass;
using SpecFlowProject.Specs.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowAccelerator.Pages
{
    class HomePage : BaseApplicationPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        { }
        string url;
        public By Item1_SearchResults = By.XPath("//body/div[@id='__next']/main[1]/div[1]/div[3]/div[1]/div[4]/article[1]/a[1]");
        public By SearchTextBox = By.XPath("//input[@id='custom-css-outlined-input']");
        public By SearchIcon = By.XPath("//button[@id='crossIcon']");
        public By AddToCartButton1_SearchResults = By.XPath("//body/div[@id='__next']/main[1]/div[1]/div[3]/div[1]/div[4]/article[1]/a[1]/div[3]/div[2]/div[1]/button[1]");
        public By ReviewCheckoutButton = By.XPath("//body/div[@id='__next']/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/a[1]/button[1]");
        public By SignInIcon = By.XPath("//a[@id='icon-account']");
        public By SignInButton = By.XPath("//header/div[@id='main-header']/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/button[1]");

        internal string GetUrl()
        {
            //Navigate to url with or without authentication alert/pop up
             url = CommonFunctions.GetResourceValue("BunningsUrl");
             return url;

        }

        internal void GoToUrl(string url)
        {
            //navigate to the url
            Driver.Navigate().GoToUrl(url);
        }

        internal void SearchText(string text)
        {
            //wait for the search box to be visible
            CommonFunctions.ExplicitWait(Driver, SearchTextBox);
            //Search for a text 
            Driver.FindElement(SearchTextBox).SendKeys(text);
            Driver.FindElement(SearchIcon).Click();
            
        }
        
        internal string AddToCart(string AddedItem)
        {
            //Wait for element visibility
            CommonFunctions.ExplicitWait(Driver, AddToCartButton1_SearchResults);
            if (CommonFunctions.IsLoadComplete(Driver).Equals(true))
            
            
            
            {
                AddedItem = Driver.FindElement(Item1_SearchResults).Text;
                AddedItem = AddedItem.Split("\r\n")[1];
               
                //Add to cart the first item on search results page
                Driver.FindElement(AddToCartButton1_SearchResults).Click();
            }
            return AddedItem;
            
        }

        internal void ReviewCheckout()
        {
            //Wait for element visibility
            CommonFunctions.ExplicitWait(Driver, ReviewCheckoutButton);
            //Click on review checkout button
            Driver.FindElement(ReviewCheckoutButton).Click();
        }

        internal void ClickItem()
        {
            //Wait for element visibility
            CommonFunctions.ExplicitWait(Driver, AddToCartButton1_SearchResults);
            //Click on review checkout button
            Driver.FindElement(Item1_SearchResults).Click();
        }

        internal void GoToSignIn()
        {
            //Wait for element visibility
            CommonFunctions.ExplicitWait(Driver, SignInIcon);
            //Go to sign in page
            CommonFunctions.GetClick(Driver.FindElement(SignInIcon));
            CommonFunctions.GetClick(Driver.FindElement(SignInButton));
        }
    }
}
