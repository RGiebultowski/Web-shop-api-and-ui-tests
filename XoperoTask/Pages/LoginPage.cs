using OpenQA.Selenium;

namespace XoperoTask.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private IWebElement loginButton => driver.FindElement(By.CssSelector("[data-test='login-button']"));
        private IWebElement userNameInput => driver.FindElement(By.CssSelector("[data-test='username']"));
        private IWebElement passwordInput => driver.FindElement(By.CssSelector("[data-test='password']"));
        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private void EnterUserName(string username)
        {
            userNameInput.Clear();
            userNameInput.SendKeys(username);
        }

        private void EnterPassowrd(string password)
        {
            passwordInput.Clear();
            passwordInput.SendKeys(password);
        }

        private void ClickLogin()
        {
            loginButton.Click();
        }

        public void LoginUser(string username, string password)
        {
            EnterUserName(username);
            EnterPassowrd(password);
            ClickLogin();
        }
    }
}
