using FluentAssertions;
using Milkman.End2end.Tests.Fixtures;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Pages.Dashboard;
using TechTalk.SpecFlow;

namespace Milkman.End2end.Tests.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly LoginFixture _loginFixture;
        private readonly DashboardPage _dashboardPage;
        public readonly ConfigurationHelper _config;
        public LoginSteps(DashboardPage dashboardPage,
            LoginFixture loginFixture, ConfigurationHelper config)
        {
            _dashboardPage = dashboardPage;
            _loginFixture = loginFixture;
            _config = config;
        }
        [Given(@"the login page is showed")]
        public void GivenTheLoginPageIsShowed()
        {
            _loginFixture.GivenTheLoginPageIsDisplayed();
        }

        [When(@"the user enter the valid credentails")]
        public void WhenTheUserEnterTheValidCredentails()
        {
            _loginFixture.UserEnterCredentials(_config.PhoneNo, _config.Password);
        }

        [When(@"the user enter an invalid pasword ""(.*)""")]
        public void WhenTheUserEnterAnInvalidPasword(string password)
        {
            _loginFixture.UserEnterCredentials(_config.PhoneNo, password);
        }


        [Then(@"""(.*)"" should be displayed on the dashboard")]
        public void ThenShouldBeDisplayedOnTheDashboard(string name)
        {
            _dashboardPage.GetHomeHeaderName().Should().Be(name.ToUpper());
        }

        [Then(@"""(.*)"" should be displayed")]
        public void ThenShouldBeDisplayed(string message)
        {
            _loginFixture.Login.GetLoginPopUpErrorMessage().Should().Be(message);
        }

    }
}
