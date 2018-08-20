using Business.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation(ShoppingCartService service)
        {
            Field<ShoppingCartType>(
                "createCart",
                resolve: ctx =>
                {
                    return service.StartNewCart();
                });

            Field<BooleanGraphType>(
                "deleteCart",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }
                ),
                resolve: ctx =>
                {
                    var cartId = ctx.GetArgument<int>("id");
                    service.AbandonCart(cartId);
                    return true;
                });

            Field<ShoppingCartItemType>(
                "addCartItem",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() {  Name = "shoppingCartId" },
                    new QueryArgument<IntGraphType>() {  Name = "productId"},
                    new QueryArgument<IntGraphType>() {  Name = "quantity"}
                ),
                resolve: ctx =>
                {
                    var cartId = ctx.GetArgument<int>("shoppingCartId");
                    var productId = ctx.GetArgument<int>("productId");
                    var quantity = ctx.GetArgument<int>("quantity");
                    return service.AddItem(cartId, productId, quantity);
                });

        }
    }
}
