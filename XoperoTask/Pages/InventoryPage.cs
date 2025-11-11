using OpenQA.Selenium;

namespace XoperoTask.Pages
{
    public class InventoryPage
    {
        private IWebDriver driver;
        private IWebElement button => driver.FindElement(By.CssSelector("button[data-test='add-to-cart-sauce-labs-backpack']"));
        private IWebElement productName => driver.FindElement(By.CssSelector("a[data-test='item-4-title-link']"));
        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAddToCartButton()
        {
            button.Click();
        }

        public string GetProductName()
        {
            return productName.Text;
        }
    }
}
