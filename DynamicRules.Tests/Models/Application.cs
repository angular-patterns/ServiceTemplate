using System;

namespace Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int? Sin { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string ProvinceState { get; set; }

        public string Country { get; set; }

        public int ApplicationDisplay { get; set; }

        public int VersionNumber { get; set; }
        public int RevisionNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
