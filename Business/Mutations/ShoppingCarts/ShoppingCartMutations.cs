using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace Business.Mutations.ShoppingCarts
{
    public class ShoppingCartMutations: GraphBase
    {
        public ShoppingCartMutations(DataContext context) : base(context)
        {

        }

        public Entities.ShoppingCart Create()
        {
            var cart = new ShoppingCart()
            {
               UserId = (Thread.CurrentPrincipal ?? new GenericPrincipal(new GenericIdentity("Guest","Anonymous"), new string[0])).Identity.Name,
               CreatedOn = DateTime.Now
            };

            Context.ShoppingCarts.Add(cart);
            Context.SaveChanges();
            return cart;
        }

        public void Delete(int id)
        {
            var entity = Context.ShoppingCarts.Find(id);
            if (entity != null)
            {
                Context.ShoppingCarts.Remove(entity);
                Context.SaveChanges();
            }
        }
    }
}
