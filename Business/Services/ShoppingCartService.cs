using Business.Mutations.ShoppingCarts;
using Business.Queries.Accounts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ShoppingCartService
    {
        private ShoppingCartMutations shoppingCartMutations;
        private ShoppingCartItemMutations shoppingCartItemMutations;
        private ShoppingCartQuery shoppingCartQuery;

        public ShoppingCartService(
            ShoppingCartQuery shoppingCartQuery,
            ShoppingCartMutations shoppingCartMutations,
            ShoppingCartItemMutations shoppingCartItemMutations)
        {
            this.shoppingCartQuery = shoppingCartQuery;
            this.shoppingCartMutations = shoppingCartMutations;
            this.shoppingCartItemMutations = shoppingCartItemMutations;
        }

        public IList<ShoppingCart> GetAllCarts()
        {
            return this.shoppingCartQuery.GetAll();
        }

        public ShoppingCart GetCart(int id)
        {
            return this.shoppingCartQuery.FindById(id);
        }

        public ShoppingCart StartNewCart()
        {
            return this.shoppingCartMutations.Create();
        }

        public void AbandonCart(int id)
        {
            this.shoppingCartMutations.Delete(id);
        }
        public IList<ShoppingCartItem> GetItems(int shoppingCartId)
        {
            return this.shoppingCartQuery.GetItems(shoppingCartId);
        }

        public ShoppingCartItem AddItem(int shoppingCartId, int productId, int quantity)
        {
            return this.shoppingCartItemMutations.AddProduct(shoppingCartId, productId, quantity);
        }

        public void RemoveItem(int shoppingCartItemId)
        {
            this.shoppingCartItemMutations.RemoveProduct(shoppingCartItemId);
        }
        

    }
}
