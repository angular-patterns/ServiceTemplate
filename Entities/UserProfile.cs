using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public UserProfile()
        {

        }

    }
}
