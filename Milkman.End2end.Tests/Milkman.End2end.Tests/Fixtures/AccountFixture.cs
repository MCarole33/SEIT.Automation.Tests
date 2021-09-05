using FluentAssertions;
using Milkman.End2end.Tests.Pages.Accounts;
using Milkman.End2end.Tests.Pages.Common;
using Milkman.End2end.Tests.TestData;

namespace Milkman.End2end.Tests.Fixtures
{
    public class AccountFixture
    {
        public readonly AccountDetailsPage AccountDetails;
        private readonly NavigationBar _nav;
        public AccountFixture(AccountDetailsPage accountDetails,
            NavigationBar nav)
        {
            AccountDetails = accountDetails;
            _nav = nav;
        }

        public void GoToAccountDetails()
        {
            _nav.GoToAccount()
                .GoToAccountDetails()
                .GetPageTitle()
                .Should().Be(Ressources.AccountDetailsTitle);
        }

        public void CustomerUpdateEmail(string email)
            => AccountDetails.WithEmailAddress<AccountDetailsPage>(email).Save();

    }
}
