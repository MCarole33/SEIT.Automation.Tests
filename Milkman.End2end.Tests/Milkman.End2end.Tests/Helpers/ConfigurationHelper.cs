using Microsoft.Extensions.Configuration;
using Milkman.End2end.Tests.Models;

namespace Milkman.End2end.Tests.Helpers
{
    public class ConfigurationHelper
    {
        private readonly Configurations _configurations;
        private readonly IConfigurationRoot _configurationRoot;
        public ConfigurationHelper(IConfigurationRoot configurationRoot)
        {
            _configurations = new Configurations();
            _configurationRoot = configurationRoot;
            _configurationRoot.GetSection("AppSettings").Bind(_configurations);
        }


        public string BaseUrl => _configurationRoot.Get<Configurations>().AppSettings[0].BaseUrl;
        public string Browser => _configurationRoot.Get<Configurations>().AppSettings[0].Browser;
        public int ElementTimeout => System.Convert.ToInt32(_configurationRoot.Get<Configurations>().AppSettings[0].ElementTimeout);
        public int PageLoadTimeout => System.Convert.ToInt32(_configurationRoot.Get<Configurations>().AppSettings[0].PageLoadTimeout);
        public string PhoneNo => _configurationRoot.Get<Configurations>().AppSettings[1].PhoneNo;
        public string Password => _configurationRoot.Get<Configurations>().AppSettings[1].Password;
        public string Postcode => _configurationRoot.Get<Configurations>().AppSettings[1].Postcode;
        public string EmailAddress => _configurationRoot.Get<Configurations>().AppSettings[1].EmailAddress;

    }
}
