using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.Accounts
{
    public class DeleteAccountMutation: GraphBase
    {
        public DeleteAccountMutation(DataContext context) : base(context)
        {

        }

        public void Delete(int id)
        {
            var entity = Context.Accounts.Find(id);
            if (entity != null)
            {
                Context.Accounts.Remove(entity);
                Context.SaveChanges();
            }
        }

    }
}
