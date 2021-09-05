using AutoFixture;
using Faker;
using Milkman.End2end.Tests.Helpers;
using Milkman.End2end.Tests.Models;
using StringGenerator = ParkSquare.Testing.Generators.StringGenerator;

namespace Milkman.End2end.Tests.Builders
{
    public class PersonBuilder
    {
        private readonly Fixture _fixture;
        private readonly ConfigurationHelper _config;
        public PersonBuilder(ConfigurationHelper config)
        {
            _fixture = new Fixture();
            _config = config;
        }

        public Person CreatePersonInstance =>
           _fixture
           .Build<Person>()
           .With(x => x.FirstName, Name.First())
           .With(x => x.LastName, Name.Last())
           .With(x => x.PhoneNo, "07"+ StringGenerator.SequenceOfDigits(9))
           .With(x => x.Password, _config.Password)
           .With(x => x.Postcode, _config.Postcode)
           .With(x => x.EmailAddress,_config.EmailAddress)
           .Create();

    }
}
