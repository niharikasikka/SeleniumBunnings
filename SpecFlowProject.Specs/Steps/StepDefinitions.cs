using OpenQA.Selenium;
using SpecFlowAccelerator;
using SpecFlowAccelerator.Pages;
using SpecFlowProject.Specs.Drivers;
using SpecFlowProject.Specs.Pages;
using SpecFlowProject.Specs.UtilityClasses;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Specs.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private string url;
        string browser;
        string AddedItem;
        public IWebDriver Driver { get; private set; }

        [BeforeScenario]
        public static void StartUp()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            //To kill any driver running in the system
            //Only kills chromedriver
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }

        }

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I navigate to bunnings home page")]
        public void GivenINavigateToBunningsHomePage()
        {
            //Initialising the browser
            Driver = GetBrowser.InitBrowser(CommonFunctions.GetResourceValue("Browser"));
            //Navigating to KIM1 homepage
            HomePage homePage = new HomePage(Driver);
            url = homePage.GetUrl();
            homePage.GoToUrl(url);
        }
        [When(@"I search for a ""(.*)""")]
        public void WhenISearchForA(string text)
        {
            HomePage homePage = new HomePage(Driver);
            homePage.SearchText(text);
        }

        [Then(@"I can see the results and add to cart the first search result item")]
        public void ThenICanSeeTheResultsAndAddToCartTheFirstSearchResultItem()
        {
            HomePage homePage = new HomePage(Driver);
            AddedItem = homePage.AddToCart(AddedItem);
        }
        [Then(@"I add ""(.*)""")]
        public void ThenIAdd(int quantity)
        {
            SearchPage searchPage = new SearchPage(Driver);
            searchPage.AddQuantity(quantity);
        }

        [Then(@"I navigate to review cart page")]
        public void ThenINavigateToReviewCartPage()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.ReviewCheckout();
        }

        [Then(@"I navigate to review cart page from basket icon")]
        public void ThenINavigateToReviewCartPageFromBasketIcon()
        {
            SearchPage searchPage = new SearchPage(Driver);
            searchPage.ClickOnBasket();
        }


        [Then(@"I verify that the item is displayed under review cart")]
        public void ThenIVerifyThatTheItemIsDisplayedUnderReviewCart()
        {
            ReviewCartPage reviewCartPage = new ReviewCartPage(Driver);
            reviewCartPage.VerifyResults_ReviewCart(AddedItem);
        }

        [Then(@"I can see the results and click on the first displayed item")]
        public void ThenICanSeeTheResultsAndClickOnTheFirstDisplayedItem()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.ClickItem();
        }

        [Then(@"I add to cart the first item")]
        public void ThenIAddToCartTheFirstItem()
        {
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(Driver);
            AddedItem = productDetailsPage.AddToCart_ProductDetailsPage(AddedItem);
        }

        [AfterScenario]
        public static void CleanUp()
        {
            GetBrowser.Cleanup();
        }

        [Then(@"I close the browser successfully")]
        public void ThenICloseTheBrowserSuccessfully()
        {
            CommonFunctions.Cleanup_Close(Driver);
        }

        [Given(@"I login to the bunnings website")]
        public void GivenILoginToTheBunningsWebsite()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoToSignIn();
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.Login();
        }

    }
}
