using Milkman.End2end.Tests.Pages.Common;
using Milkman.End2end.Tests.Pages.SignUp;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace Milkman.End2end.Tests.Pages.Login
{
    public class LoginPage : CommonPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        #region Locator
        private readonly By _loginLocator = By.CssSelector("button#checkLogin");
        private readonly By _rememberMeLocator = By.CssSelector("input#remember_me");
        private readonly By _forgetPasswordLocator = By.CssSelector("a[href*='forgot-password']");
        private readonly By _signUpLocator = By.CssSelector(".dont_account [href*='check-postcode']");
        private readonly By _getStartedContainerLocator = By.XPath("/html/body/section[@class='get-started-page']//div[@class='get-started']");
        private readonly By _popUpmessageLocator = By.XPath("//*[@id='swal2-content']");
        #endregion


        private IWebElement LoginBtn => _driver.FindElement(_loginLocator);
        private IWebElement RememberMeBtn => _driver.FindElement(_rememberMeLocator);
        private IWebElement ForgotPasswordLink => _driver.FindElement(_forgetPasswordLocator);
        private IWebElement SignUpLink => _driver.FindElement(_signUpLocator);
        private IWebElement PopUpMessage => _wait.FindWithWait(_popUpmessageLocator);


        public LoginPage Login()
        {
            LoginBtn.Click();
            return this;
        }

        public string GetLoginPopUpErrorMessage() => PopUpMessage.Text;

        public GetStartedPage GoToGetStartedPage()
        {
            SignUpLink.Click();

            return new GetStartedPage(_driver, _wait.WaitForAllElements(ExpectedConditions
                .PresenceOfAllElementsLocatedBy(_getStartedContainerLocator)).FirstOrDefault());
        }

    }
}
