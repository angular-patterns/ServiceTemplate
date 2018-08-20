using Data;

using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries.Accounts
{
    public class ShoppingCartQuery: GraphBase
    {
        public ShoppingCartQuery(DataContext context) : base(context)
        {

        }

        public IList<ShoppingCart> GetAll()
        {
            return Context.ShoppingCarts.ToList();
        }

        public ShoppingCart FindById(int id)
        {
            return Context.ShoppingCarts.Find(id);
        }

        public IList<ShoppingCartItem> GetItems(int shoppingCartId)
        {
            return Context.ShoppingCartItems.Where(t => t.ShoppingCartId == shoppingCartId).ToList();
        }

    }
}
