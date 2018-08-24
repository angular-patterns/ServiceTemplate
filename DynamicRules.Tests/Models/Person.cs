using Newtonsoft.Json;
using System.ComponentModel;

namespace Models
{
    public class Person
    {
        [DefaultValue("")]
        public string FirstName { get; set; }
        [DefaultValue("")]
        public string LastName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public Address Address { get; set; }
        public Person()
        {
            Address = new Address();
        }
    }
    public class Address
    {
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string City { get; set; }
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Province { get; set; }
    }
}