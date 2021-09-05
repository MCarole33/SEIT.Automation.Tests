using OpenQA.Selenium;

namespace Milkman.End2end.Tests.Factories
{
    public interface IWebDriverFactory
    {
        IWebDriver GetChromeWebDriver();
        IWebDriver GetFirefoxWebDriver();
    }
}
