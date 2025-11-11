using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.Pages;

namespace XoperoTask.UI_Tests
{
    public class AddToCartAndWerifyCartStepDefinitions
    {
        private IWebDriver driver;
        private bool headlessMode = false;
        private WebDeserialization data = new WebDeserialization();
        private LoginHelper loginHelper = new LoginHelper();
        private InventoryPage inventoryPage;
        private HeaderPage headerPage;
        private CartPage cartPage;

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory(headlessMode).CreateWebDriver();
            driver.Navigate().GoToUrl(data.LoginURL);
            loginHelper.LoginUser(driver, data.ValidUsername, data.ValidPassword);
        }

        [Test]
        public void AddToCartAndVerifyCart()
        {
            inventoryPage = new InventoryPage(driver);
            headerPage = new HeaderPage(driver);
            cartPage = new CartPage(driver);

            inventoryPage.ClickAddToCartButton();
            var productName = inventoryPage.GetProductName();
            Console.WriteLine($"Added product: {productName}");

            headerPage.ClickShoppingCart();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.UrlContains(data.CartEndpoint));

            Assert.That(driver.Url, Contains.Substring(data.CartEndpoint));
            Assert.IsTrue(cartPage.IsItemInCart(productName));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
