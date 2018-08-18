using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.Accounts
{
    public class CreateAccountMutation: GraphBase
    {
        public CreateAccountMutation(DataContext context) : base(context)
        {

        }

        public Account Create(string username, string password)
        {
            var account = new Account()
            {
                Username = username,
                Password = password,
                CreatedOn = DateTime.Now,
                CreatedBy = "Guest"
            };

            Context.Accounts.Add(account);
            Context.SaveChanges();
            return account;
        }

    }
}
