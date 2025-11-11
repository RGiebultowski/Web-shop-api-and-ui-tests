using OpenQA.Selenium;

namespace XoperoTask.Pages
{
    public class CheckoutStepOnePage
    {
        private IWebDriver driver;
        private IWebElement continueButton => driver.FindElement(By.CssSelector("input[data-test='continue']"));
        private IWebElement firstNameInput => driver.FindElement(By.CssSelector("input[data-test='firstName']"));
        private IWebElement lastNameInput => driver.FindElement(By.CssSelector("input[data-test='lastName']"));
        private IWebElement postalCodeInput => driver.FindElement(By.CssSelector("input[data-test='postalCode']"));
        public CheckoutStepOnePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        private void EnterFirstName(string name)
        {
            firstNameInput.Clear();
            firstNameInput.SendKeys(name);
        }
        
        private void EnterLastName(string lastName)
        {
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);
        }

        private void EnterPostalCode(string postalCode)
        {
            postalCodeInput.Clear();
            postalCodeInput.SendKeys(postalCode);
        }

        public void FillCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterPostalCode(postalCode);
            continueButton.Click();
        }
    }
}
