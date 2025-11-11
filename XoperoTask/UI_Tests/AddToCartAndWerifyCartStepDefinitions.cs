using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory(headlessMode).CreateWebDriver();
            driver.Navigate().GoToUrl(data.LoginURL);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginUser(data.ValidUsername, data.ValidPassword);
        }

        [Test]
        public void AddToCartAndVerifyCart()
        {

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
