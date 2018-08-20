using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.ShoppingCarts
{
    public class ShoppingCartItemMutations: GraphBase
    {
        public ShoppingCartItemMutations(DataContext context): base(context)
        {

        }

        public ShoppingCartItem AddProduct(int shoppingCartId, int productId, int quantity)
        {
            var item = new ShoppingCartItem();
            item.ShoppingCartId = shoppingCartId;
            item.ProductId = productId;
            item.Quantity = quantity;

            Context.ShoppingCartItems.Add(item);
            Context.SaveChanges();

            return item;
        }

        public bool RemoveProduct(int shoppingCartItemId)
        {
            var cartItem = Context.ShoppingCartItems.Find(shoppingCartItemId);

            Context.ShoppingCartItems.Remove(cartItem);
            Context.SaveChanges();

            return true;
        }
    }
}
