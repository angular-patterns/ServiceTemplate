using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int Sin { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string ProvinceState { get; set; }

        public string Country { get; set; }
    
    }

    public enum Gender
    {
        Male,
        Female
    }
}
