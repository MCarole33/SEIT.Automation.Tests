using FluentAssertions;
using Milkman.End2end.Tests.Fixtures;
using Milkman.End2end.Tests.TestData;
using TechTalk.SpecFlow;

namespace Milkman.End2end.Tests.Steps
{
    [Binding]
    public sealed class AccountSteps
    {
        private readonly AccountFixture _accountFixture;
        public AccountSteps(AccountFixture accountFixture)
        {
            _accountFixture = accountFixture;
        }

        [Given(@"the (customer logged in)")]
        public void GivenTheCustomerLoggedIn(string name)
        {
            name.Should().Be(Ressources.CustomerName.ToUpper());
        }

        [Given(@"the customer accounts details page is dsiplayed")]
        public void GivenTheCustomerAccountsDetailsPageIsDsiplayed()
        {
            _accountFixture.GoToAccountDetails();
        }

        [When(@"the customer update the email address with (.*)")]
        public void WhenTheCustomerUpdateTheEmailAddressWith(string email)
        {
            _accountFixture.CustomerUpdateEmail(email);
        }

        [When(@"the customer enter a valid email ""(.*)""")]
        public void WhenTheCustomerEnterAValidEmail(string email)
        {
            _accountFixture.CustomerUpdateEmail(email);
        }

        [Then(@"the email address messge ""(.*)"" should be successfully updated")]
        public void ThenTheEmailAddressMessgeShouldBeSuccessfullyUpdated(string message)
        {
            _accountFixture.AccountDetails.GetSuccessfulUpdateEmailMessage().Should().Be(message);

        }

        [Then(@"the Error message ""(.*)"" should be displayed")]
        public void ThenTheErrorMessageShouldBeDisplayed(string errorMessage)
        {
            _accountFixture.AccountDetails.GetErrorMessage().Should().Be(errorMessage);
        }

    }
}
