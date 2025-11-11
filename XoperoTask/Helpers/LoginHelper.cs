using OpenQA.Selenium;
using XoperoTask.Pages;

namespace XoperoTask.Helpers
{
    public class LoginHelper
    {
        public void LoginUser(IWebDriver driver, string username, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginUser(username, password);
        }
    }
}
