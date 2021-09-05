using FluentAssertions;
using Milkman.End2end.Tests.Fixtures;
using Milkman.End2end.Tests.Pages.Dashboard;
using TechTalk.SpecFlow;

namespace Milkman.End2end.Tests.Steps
{
    [Binding]
    public sealed class UserSignUpSteps
    {
        private readonly SignUpFixture _fixture;
        private readonly DashboardPage _dashboardPage;
        public UserSignUpSteps(SignUpFixture fixture, DashboardPage dashboardPage)
        {
            _fixture = fixture;
            _dashboardPage = dashboardPage;
        }

        [Given(@"the application is displayed")]
        public void GivenTheApplicationIsDisplayed()
        {
            _fixture.IsApplicationIsDisplayed().Should().BeTrue();
        }

        [When(@"the user sign up to the application")]
        public void WhenTheUserSignUpToTheApplication()
        {
            _fixture.WhenNewUserRegister();
        }

        [Then(@"the user should registered sucessfully")]
        public void ThenTheUserShouldRegisteredSucessfully()
        {
            _dashboardPage.GetHomeHeaderName().Should().Be(_fixture.Person.FirstName.ToUpper());
        }

    }
}
