using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
