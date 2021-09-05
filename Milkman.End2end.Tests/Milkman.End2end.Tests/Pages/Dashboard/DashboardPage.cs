using Milkman.End2end.Tests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Milkman.End2end.Tests.Pages.Dashboard
{
    public class DashboardPage
    {

        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(_driver);
        }

        #region Locator
        private readonly By _homeHeadLocator = By.XPath("/html/body[@class='login']/section[@class='categories-section']//h1[@class='home_head']");
        #endregion

        private IWebElement HomeHeader => _wait.WaitForElement(ExpectedConditions.ElementExists(_homeHeadLocator));


        public string GetHomeHeaderName() => HomeHeader.Text.Split(' ')[1];
    }
}
