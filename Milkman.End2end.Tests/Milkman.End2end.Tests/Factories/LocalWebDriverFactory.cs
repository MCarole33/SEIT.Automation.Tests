using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Milkman.End2end.Tests.Factories
{
    public class LocalWebDriverFactory : IWebDriverFactory
    {
        private readonly DriverManager driverManager;

        public LocalWebDriverFactory()
        {
            driverManager = new DriverManager();
        }

        public IWebDriver GetChromeWebDriver()
        {
            var options = new ChromeOptions();
           
            options.AddArguments("--start-maximized", "--disable-extensions", "--no-sandbox", "--disable-infobars");

            driverManager.SetUpDriver(new ChromeConfig());

            return new ChromeDriver(options);
        }

        public IWebDriver GetFirefoxWebDriver()
        {
            driverManager.SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }
    }
}
