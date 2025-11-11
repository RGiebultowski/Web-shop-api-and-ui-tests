using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.Pages;

namespace XoperoTask.UI_Tests
{
    public class CompletePurchaseStepDefinitions
    {
        private IWebDriver driver;
        private bool headlessMode = false;
        private WebDeserialization data = new WebDeserialization();
        private PurchaseHelper purchaseHelper = new PurchaseHelper();
        private CartPage cartPage;
        private CheckoutStepOnePage checkoutStepOnePage;
        private CheckoutStepTwoPage checkoutStepTwoPage;

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory(headlessMode).CreateWebDriver();
            driver.Navigate().GoToUrl(data.LoginURL);
            purchaseHelper.SetUpPurchase(driver, data.ValidUsername, data.ValidPassword);
        }

        [Test]
        public void CompletePurchase()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);

            cartPage.ClickCheckout();
            wait.Until(ExpectedConditions.UrlContains(data.CheckoutEndpoint));

            checkoutStepOnePage.FillCheckoutInformation("John", "Doe", "12345");
            wait.Until(ExpectedConditions.UrlContains(data.CheckoutTwoEndpoint));

            checkoutStepTwoPage.ClickFinishButton();
            wait.Until(ExpectedConditions.UrlContains(data.CheckoutCompleteEndpoint));

            Assert.That(driver.Url, Contains.Substring(data.CheckoutCompleteEndpoint));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
