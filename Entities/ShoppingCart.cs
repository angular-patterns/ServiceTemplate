using GraphQL.Types;
using System;

namespace Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public ShoppingCart()
        {

        }

    }

}
