using OpenQA.Selenium;
using SmokeTest.BaseClass;
using SpecFlowProject.Specs.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Specs.Pages
{
    class SignInPage : BaseApplicationPage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        { }

        public By UserId = By.XPath("//input[@id='okta-signin-username']");
        public By Password = By.XPath("//input[@id='okta-signin-password']");
        public By SignInButton = By.XPath("//input[@id='okta-signin-submit']");

        internal void Login()
        {
            CommonFunctions.ExplicitWait(Driver,UserId);
            CommonFunctions.GetClick(Driver.FindElement(UserId));
            Driver.FindElement(UserId).SendKeys(CommonFunctions.GetResourceValue("UserId"));
            CommonFunctions.GetClick(Driver.FindElement(Password));
            Driver.FindElement(Password).SendKeys(CommonFunctions.GetResourceValue("Password"));
            CommonFunctions.GetClick(Driver.FindElement(SignInButton));
        }
    }
}
