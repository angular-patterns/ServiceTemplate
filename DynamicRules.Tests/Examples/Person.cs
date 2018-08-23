using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Test
{
    public class Models
    {

        public const string Person = @"
using Newtonsoft.Json;
using System.ComponentModel;
namespace Test {
    public class Person
    {
        [DefaultValue(""Blue"")]
        public string FirstName { get; set; }
        [DefaultValue(""Blue"")]
        public string LastName { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public Address Address { get; set; }
        public Person() {
            Address = new Address();
        }
    }
    public class Address
    {
        [DefaultValue(""Blue"")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string City { get; set; }
        [DefaultValue(""Blue"")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Province { get; set; }
    }
}
";
    }
}

namespace Test
{
    public class Person
    {
        [DefaultValue("Blue")]
        public string FirstName { get; set; }
        [DefaultValue("Blue")]
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
        [DefaultValue("Blue")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string City { get; set; }
        [DefaultValue("Blue")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Province { get; set; }
    }
}