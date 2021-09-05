using FluentAssertions;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Pages.Common;
using Milkman.End2end.Tests.Pages.Login;

namespace Milkman.End2end.Tests.Fixtures
{
    public class LoginFixture
    {
        public readonly LoginPage Login;
        protected readonly NavigationBar _nav;
        protected readonly ConfigurationHelper _config;
        public LoginFixture(LoginPage login, NavigationBar nav,
            ConfigurationHelper config)
        {
            Login = login;
            _nav = nav;
            _config = config;
        }

        public void GivenTheLoginPageIsDisplayed()
        {
            _nav.IsSignInDisplayed.Should().BeTrue();
            _nav.GoToSignIn();
        }

        public void UserEnterCredentials(string phoneNo, string password)
        {
            Login.WithPhoneNo<CommonPage>(phoneNo)
                  .WithPassword<LoginPage>(password)
                  .Login();
        }


        public void UserEnterCorrectCredentials()
        {
            Login.WithPhoneNo<CommonPage>(_config.PhoneNo)
                  .WithPassword<LoginPage>(_config.Password)
                  .Login();
        }

    }
}
