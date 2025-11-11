using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace XoperoTask.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        private readonly WebDriverWait wait;
        private By cartListLocator = By.CssSelector("div[data-test='cart-list']");
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IReadOnlyCollection<IWebElement> cartList
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(cartListLocator));
                return driver.FindElements(cartListLocator);
            }
        }

        public bool IsItemInCart(string productName)
        {
            foreach(var item in cartList)
            {
                var itemName = item.FindElement(By.CssSelector("div[data-test='inventory-item-name']")).Text;
                Console.WriteLine($"Item in cart: {itemName}");
                if (productName.Equals(itemName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
