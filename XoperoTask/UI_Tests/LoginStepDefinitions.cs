using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.TestData;

namespace XoperoTask.UI_Tests
{
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private WebDeserialization data = new WebDeserialization();
        private LoginHelper loginHelper = new LoginHelper();
        private bool headlessMode = true;

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory(headlessMode).CreateWebDriver();
            driver.Navigate().GoToUrl(data.LoginURL);
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            loginHelper.LoginUser(driver, data.ValidUsername, data.ValidPassword);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.UrlContains(data.InventoryEndpoint));

            Assert.That(driver.Url, Contains.Substring(data.InventoryEndpoint));
        }

        [Test, TestCaseSource(typeof(UsersDataForLogin), nameof(UsersDataForLogin.testCaseUsers))]
        public void LoginWithInvalidCredentials(string username, string passowrd, string errorMessage)
        {
            loginHelper.LoginUser(driver, username, passowrd);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var error = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3[data-test='error']")));

            Assert.That(error.Displayed, Is.True);
            Assert.That(error.Text, Is.EqualTo(errorMessage));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
