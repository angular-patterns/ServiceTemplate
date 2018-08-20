using Business.Queries.Accounts;
using Business.Services;
using Entities;
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {
        public static ShoppingCartService Service;
        public RootQuery(ShoppingCartService service)
        {
            Service = service;

            Field<ListGraphType<ShoppingCartType>>(
                "shoppingCarts",
                description: "Retrieves all shopping carts.",
               
                resolve: ctx =>
                {
                    return service.GetAllCarts();
                });
            Field<ShoppingCartType>(
                "shoppingCart",
                description: "Retrieve a single cart",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the cart" }
                ),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return service.GetCart(id);
                });
        }

    }


    public class ShoppingCartType : ObjectGraphType<ShoppingCart>
    {
        public ShoppingCartType()

        {
            var service = RootQuery.Service;

            Name = "ShoppingCart";
            Field("id", d => d.ShoppingCartId, nullable: true).Description("The id of the shopping cart.");
            Field(d => d.UserId, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedOn, nullable: true).Description("The name of the character.");
            Field<ListGraphType<ShoppingCartItemType>>(
                "items",
                description: "Retrieve items for a cart",
                resolve: ctx =>
                {
                    
                    return service.GetItems(ctx.Source.ShoppingCartId);
                });

        }

    }
    public class ShoppingCartItemType : ObjectGraphType<ShoppingCartItem>
    {

        public ShoppingCartItemType()

        {
            Name = "ShoppingCartItem";
            Field("id", d => d.ShoppingCartItemId, nullable: true).Description("The id of the shopping cart item.");
            Field(d => d.ProductId, nullable: true).Description("The product ID.");
            Field(d => d.Quantity, nullable: true).Description("The quantity.");
        }

    }
}
