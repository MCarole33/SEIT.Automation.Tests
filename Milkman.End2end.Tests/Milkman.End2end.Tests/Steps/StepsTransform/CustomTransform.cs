using Milkman.End2end.Tests.Fixtures;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Pages.Common;
using Milkman.End2end.Tests.Pages.Dashboard;
using Milkman.End2end.Tests.Pages.Login;
using TechTalk.SpecFlow;

namespace Milkman.End2end.Tests.Steps.StepsTransform
{
    [Binding]
    public sealed class CustomTransform : LoginFixture
    {
        private readonly DashboardPage _dashboardPage;
        public CustomTransform(LoginPage login, NavigationBar nav,
            ConfigurationHelper config, DashboardPage dashboardPage) : base(login, nav, config)
        {
            _dashboardPage = dashboardPage;
        }


        [StepArgumentTransformation("customer logged in")]
        public string GIvenTheCustomerLogginToApplication()
        {
            GivenTheLoginPageIsDisplayed();
            UserEnterCorrectCredentials();

            return _dashboardPage.GetHomeHeaderName();
        }
    }
}
