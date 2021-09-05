using FluentAssertions;
using Milkman.End2end.Tests.Extensions;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Pages.Login;
using OpenQA.Selenium;

namespace Milkman.End2end.Tests.Pages.Common
{
    public class CommonPage : ICommon
    {
        protected readonly IWebDriver _driver;
        protected WaitHelper _wait;
        public CommonPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelper(_driver);
        }

        #region Locator 
        private readonly By _mobileNumberLocator = By.Id("phoneNo");
        private readonly By _passwordLocator = By.Id("password");
        private readonly By _emailAddressLocator = By.Id("email");
        #endregion

        private IWebElement MobileNumberField => _driver.FindElement(_mobileNumberLocator);
        private IWebElement PasswordField => _driver.FindElement(_passwordLocator);
        private IWebElement EmailAddressField => _driver.FindElement(_emailAddressLocator);

        public T WithPhoneNo<T>(string phoneNo) where T : class
        {
            MobileNumberField.Displayed.Should().BeTrue();
            MobileNumberField.Clear();
            MobileNumberField.SendKeys(phoneNo, 10);
            return this as T;
        }

        public T WithPassword<T>(string password) where T : class
        {
            PasswordField.Displayed.Should().BeTrue();
            PasswordField.Clear();
            PasswordField.SendKeys(password, 10);
            return this as T;
        }
        public T WithEmailAddress<T>(string email) where T : class
        {
            EmailAddressField.Displayed.Should().BeTrue();
            EmailAddressField.Clear();
            EmailAddressField.SendKeys(email);
            return this as T;
        }
    }
}
