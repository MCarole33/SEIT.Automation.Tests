using Milkman.End2end.Tests.Builders;
using Milkman.End2end.Tests.Models;
using Milkman.End2end.Tests.Pages.Common;
using Milkman.End2end.Tests.Pages.Login;
using Milkman.End2end.Tests.Pages.SignUp;
using Milkman.End2end.Tests.TestData;

namespace Milkman.End2end.Tests.Fixtures
{
    public class SignUpFixture
    {
        private readonly NavigationBar _nav;
        private readonly LoginPage _login;
        private readonly PersonBuilder _person;
        public Person Person;
        public SignUpFixture(NavigationBar nav, LoginPage login,
            PersonBuilder person)
        {
            _nav = nav;
            _login = login;
            _person = person;
        }

        public void WhenNewUserRegister()
        {
            Person = _person.CreatePersonInstance;
            _nav.GoToSignIn();
            RegisterAUser(Person, Ressources.AboutUsOption);
        }
        public bool IsApplicationIsDisplayed()
        {
            return _nav.IsSignInDisplayed;
        }

        private void RegisterAUser(Person person, string option)
        {
            _login.GoToGetStartedPage()
                  .WithPhoneNo<GetStartedPage>(person.PhoneNo)
                  .WithPostcode(person.Postcode)
                  .GoToSignUpPage()
                  .WithFistName(person.FirstName)
                  .WithLastName(person.LastName)
                  .WithEmailAddress<CommonPage>(person.EmailAddress)
                  .WithPhoneNo<CommonPage>(person.PhoneNo)
                  .WithPassword<SignUpPage>(person.Password)
                  .HearAboutUs(option)
                  .AcceptPolicy()
                  .Create();
        }
    }
}
