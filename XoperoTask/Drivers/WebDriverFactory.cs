using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XoperoTask.Drivers
{
    public class WebDriverFactory
    {
        private readonly bool headless;
        public WebDriverFactory(bool headless)
        {
            this.headless = headless;
        }

        public IWebDriver CreateWebDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--incognito");

            if (headless)
            {
                options.AddArgument("--headless");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

           return new ChromeDriver(options);
        }
    }
}
