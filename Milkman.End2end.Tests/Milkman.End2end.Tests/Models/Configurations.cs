using System.Collections.Generic;

namespace Milkman.End2end.Tests.Models
{
    public class Configurations
    {
           public List<AppSettings> AppSettings { get; set; }
    }


    public class AppSettings
    {
           public string BaseUrl { get; set; }
           public string Browser { get; set; }
           public int PageLoadTimeout { get; set; }
           public int ElementTimeout { get; set; }
           public string PhoneNo { get; set; }
           public string Password { get; set; }
           public string Postcode { get; set; }
           public string EmailAddress { get; set; }
    }

}
