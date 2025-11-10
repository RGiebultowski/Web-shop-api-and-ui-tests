using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoTask.Drivers;
using XoperoTask.Helpers;
using XoperoTask.Pages;
using XoperoTask.TestData;

namespace XoperoTask.UI_Tests
{
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private WebDeserialization data = new WebDeserialization();
        private LoginPage loginPage;
        private bool headlessMode = false;

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory(headlessMode).CreateWebDriver();
            driver.Navigate().GoToUrl(data.LoginURL);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            loginPage.LoginUser(data.ValidUsername, data.ValidPassword);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.UrlContains("/inventory.html"));

            Assert.That(driver.Url, Contains.Substring("/inventory.html"));
        }

        [Test, TestCaseSource(typeof(UsersDataForLogin), nameof(UsersDataForLogin.testCaseUsers))]
        public void LoginWithInvalidCredentials(string username, string passowrd, string errorMessage)
        {
            loginPage.LoginUser(username, passowrd);

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
