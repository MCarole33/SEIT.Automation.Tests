using Milkman.End2end.Tests.Helpers;
using OpenQA.Selenium;

namespace Milkman.End2end.Tests.Factories
{
    public class BrowserFactory
    {
        private readonly IWebDriverFactory WebDriverFactory;
        private ConfigurationHelper _configuration;
        public BrowserFactory(ConfigurationHelper configuration)
        {
            _configuration = configuration;
            WebDriverFactory = new LocalWebDriverFactory();
        }

        public bool IsChrome => _configuration.Browser.Equals("Chrome");
        public bool IsFirefox => _configuration.Browser.Equals("Firefox");


        public IWebDriver GetWebDriver()
        {
            IWebDriver result = null;

            if (IsChrome)
            {
                result = WebDriverFactory.GetChromeWebDriver();
            }
            else if (IsFirefox)
            {
                result = WebDriverFactory.GetFirefoxWebDriver();
            }

            return result;
        }
    }
}
