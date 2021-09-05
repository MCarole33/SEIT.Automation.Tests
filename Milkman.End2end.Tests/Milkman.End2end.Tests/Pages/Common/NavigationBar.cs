using Milkman.End2end.Tests.Extensions;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Pages.Accounts;
using Milkman.End2end.Tests.Pages.Login;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace Milkman.End2end.Tests.Pages.Common
{
    public class NavigationBar
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _wait;
        public NavigationBar(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(_driver);

        }
        #region Locator
        private readonly By _signInLocator = By.CssSelector(".account-login1.pull-left ul li:first-of-type a");
        private readonly By _dropdownLocator = By.XPath("/html/body[@class='login']/nav//div[@class='account-login pull-right']/ul//a[@href='#']");
        private readonly By _accountLocator = By.CssSelector(".dropdown-menu.show [href*='myAccount']");
        private readonly By _accounContainerLocator = By.CssSelector(".account-up.myaccount-section > div > div:nth-of-type(2)");
        #endregion

        private IWebElement Dropdown => _wait.WaitForAllElements(ExpectedConditions.PresenceOfAllElementsLocatedBy(_dropdownLocator)).FirstOrDefault();
        private IWebElement Account => _driver.FindElement(_accountLocator);

        public LoginPage GoToSignIn()
        {
            _wait.FindWithWait(_signInLocator).RetryClick();
            return new LoginPage(_driver);
        }


        public MyAccountPage GoToAccount()
        {
            Dropdown.RetryClick();
            Account.RetryClick();

            return new(_driver, _wait.WaitForAllElements(ExpectedConditions
                 .PresenceOfAllElementsLocatedBy(_accounContainerLocator)).FirstOrDefault());
        }

        public bool IsSignInDisplayed => _wait.FindWithWait(_signInLocator).Displayed;
    }
}
