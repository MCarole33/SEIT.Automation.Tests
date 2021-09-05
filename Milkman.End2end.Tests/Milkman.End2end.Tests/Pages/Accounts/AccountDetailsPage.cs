using Milkman.End2end.Tests.Extensions;
using Milkman.End2end.Tests.Pages.Common;
using OpenQA.Selenium;

namespace Milkman.End2end.Tests.Pages.Accounts
{
    public class AccountDetailsPage : CommonPage
    {

        public AccountDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        #region Locator
        private readonly By _saveLocator = By.XPath("/html//button[@id='update_profile']");
        private readonly By _headerTitleLocator = By.XPath("/html/body[@class='login']/section[1]//h1[.='Account details']");
        private readonly By _popUpMessageLocator = By.XPath("/html//div[@id='swal2-content']");
        private readonly By _okButtonLocator = By.CssSelector(".swal2-confirm.swal2-styled");
        private readonly By _errorMessageLocator = By.Id("error-otp");
        #endregion


        private IWebElement SaveBtn => _driver.FindElement(_saveLocator);
        private IWebElement HeaderName => _driver.FindElement(_headerTitleLocator);
        private IWebElement PopUpMessage => _driver.FindElement(_popUpMessageLocator);
        private IWebElement OkBtn => _driver.FindElement(_okButtonLocator);
        private IWebElement ErrorMessage => _driver.FindElement(_errorMessageLocator);

        public void Save() => SaveBtn.Click();
        public string GetPageTitle() => HeaderName.Text;
        public string GetErrorMessage() => ErrorMessage.Text;
        public string GetSuccessfulUpdateEmailMessage()
        {
            string message = PopUpMessage.Text;
            OkBtn.JSClick();
            return message;
        }
    }
}
