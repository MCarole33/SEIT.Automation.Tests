using Milkman.End2end.Tests.Extensions;
using Milkman.End2end.Tests.Pages.Common;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace Milkman.End2end.Tests.Pages.SignUp
{
    public class GetStartedPage : CommonPage
    {
        private IWebElement _container;
        public GetStartedPage(IWebDriver driver, IWebElement element) : base(driver)
        {
            _container = element;
        }

        #region Locator

        private readonly By GetStartedLocator = By.XPath("//button[@id='submitPostcode']");
        private readonly By SignupContainerLocator = By.CssSelector(".signup-form");
        private readonly By PostcodeLocator = By.XPath("/html//input[@id='postcode']");
        #endregion

        private IWebElement GetStartedBtn => _container.FindElement(GetStartedLocator);
        private IWebElement PostcodeField => _container.FindElement(PostcodeLocator);


        public GetStartedPage WithPostcode(string postcode)
        {
            PostcodeField.SendKeys(postcode, 10);
            return this;
        }

        public SignUpPage GoToSignUpPage()
        {
            GetStartedBtn.Click();

            return new SignUpPage(_driver, _wait.WaitForAllElements(ExpectedConditions
                .PresenceOfAllElementsLocatedBy(SignupContainerLocator)).FirstOrDefault());
        }
    }
}
