using OpenQA.Selenium;

namespace XoperoTask.Pages
{
    public class CheckoutStepTwoPage
    {
        private IWebDriver driver;
        private IWebElement finishButton => driver.FindElement(By.CssSelector("button[data-test='finish']"));

        public CheckoutStepTwoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickFinishButton()
        {
            finishButton.Click();
        }
    }
}
