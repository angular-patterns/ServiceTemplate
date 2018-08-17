using System;

namespace Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime CreatedBy { get; set; }
        public string CreatedOn { get; set; }

        public Account()
        {

        }
    }
}
