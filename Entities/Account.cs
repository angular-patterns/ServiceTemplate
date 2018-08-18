using GraphQL.Types;
using System;

namespace Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Account()
        {

        }

    }

}
