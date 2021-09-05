using Milkman.End2end.Tests.Pages.Common;
using OpenQA.Selenium;

namespace Milkman.End2end.Tests.Pages.Accounts
{
    public class MyAccountPage : CommonPage
    {
        private readonly IWebElement _container;
        public MyAccountPage(IWebDriver driver, IWebElement container) : base(driver)
        {
            _container = container;
        }

        #region Locator
        private readonly By _accountDetailsLocator = By.CssSelector(".account-nav li:nth-of-type(1) .arrow_right");
        #endregion

        private IWebElement AccountDetailsBtn => _container.FindElement(_accountDetailsLocator);


        public AccountDetailsPage GoToAccountDetails()
        {
            AccountDetailsBtn.Click();

            return new AccountDetailsPage(_driver);
        }
    }
}
