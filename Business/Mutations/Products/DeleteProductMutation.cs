using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.Accounts
{
    public class DeleteProductMutation: GraphBase
    {
        public DeleteProductMutation(DataContext context) : base(context)
        {

        }

        public void Delete(int id)
        {
            var entity = Context.Products.Find(id);
            if (entity != null)
            {
                Context.Products.Remove(entity);
                Context.SaveChanges();
            }
        }

    }
}
