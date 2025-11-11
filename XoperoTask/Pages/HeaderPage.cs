using OpenQA.Selenium;

namespace XoperoTask.Pages
{
    public class HeaderPage
    {
        private IWebDriver driver;
        private IWebElement shoppingCart => driver.FindElement(By.CssSelector("a[data-test='shopping-cart-link']"));

        public HeaderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickShoppingCart()
        {
            shoppingCart.Click();
        }
    }
}
