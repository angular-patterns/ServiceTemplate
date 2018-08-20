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
            Field<ShoppingCartType>("createCart",
                resolve: ctx =>
                {
                    return service.StartNewCart();
                });

            Field<BooleanGraphType>("deleteCart",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }
                ),
                resolve: ctx =>
                {
                    var cartId = ctx.GetArgument<int>("id");
                    service.AbandonCart(cartId);
                    return true;
                });

        }
    }
}
