using FluentAssertions;
using Milkman.End2end.Tests.Extensions;
using Milkman.End2end.Tests.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Milkman.End2end.Tests.Pages.SignUp
{
    public class SignUpPage : CommonPage
    {

        private IWebElement _container;
        public SignUpPage(IWebDriver driver, IWebElement element) : base(driver)
        {
            _container = element;

        }
        #region Locator

        private readonly By FirstNameLocator = By.Id("forename");
        private readonly By LastNameLocator = By.Id("surname");
        private readonly By WhereDidYouHearAboutUsLocator = By.Id("heardFrom");
        private readonly By CreateAccountLocator = By.CssSelector(".form-submit");
        private readonly By ReadPolicyLocator = By.CssSelector("input#terms");
        #endregion


        private IWebElement FirstNameField => _container.FindElement(FirstNameLocator);
        private IWebElement LastNameField => _container.FindElement(LastNameLocator);
        private IWebElement CreateAccountBtn => _container.FindElement(CreateAccountLocator);
        private IWebElement ClickpolicyBtn => _container.FindElement(ReadPolicyLocator);
        private SelectElement SelectOption => new(_container.FindElement(WhereDidYouHearAboutUsLocator));


        public SignUpPage WithFistName(string firstName)
        {
            FirstNameField.Clear();
            FirstNameField.SendKeys(firstName);
            return this;
        }

        public SignUpPage WithLastName(string lastName)
        {
            LastNameField.Clear();
            LastNameField.SendKeys(lastName);
            return this;
        }

        public SignUpPage HearAboutUs(string option)
        {
            SelectOption.SelectByText(option);
            return this;
        }

        public SignUpPage AcceptPolicy()
        {
            ClickpolicyBtn.Actions().MoveToElement(ClickpolicyBtn).Build().Perform();
            ClickpolicyBtn.JSClick();
            ClickpolicyBtn.IsChecked().Should().BeTrue();

            return this;
        }
        public void Create()
        {
            CreateAccountBtn.ScrollToElement();
            CreateAccountBtn.Click();
        }

    }
}
