using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoTask.Pages;

namespace XoperoTask.Helpers
{
    public class PurchaseHelper
    {
        public void SetUpPurchase(IWebDriver driver, string username, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            InventoryPage inventoryPage = new InventoryPage(driver);
            HeaderPage headerPage = new HeaderPage(driver);
            loginPage.LoginUser(username, password);
            inventoryPage.ClickAddToCartButton();
            headerPage.ClickShoppingCart();
        }
    }
}
