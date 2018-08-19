
using Business.Queries.Products;
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
        public RootQuery(ProductsQuery query)
        {
            Field<ListGraphType<ProductType>>(
                "accounts",
                description: "Retrieves all products",
                resolve: ctx =>
                {
                    return query.GetAllProducts(); 
                });
            Field<ProductType>(
                "account",
                description: "Retrieve a single account",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the product" }
                ),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return query.FindById(id);
                });
        }

    }


    public class ProductType : ObjectGraphType<Product>
    {

        public ProductType()

        {
            Name = "Account";
            Field("id", d => d.ProductId, nullable: true).Description("The id of the character.");
            Field(d => d.Name, nullable: true).Description("The name of the product.");
            Field(d => d.Price, nullable: true).Description("The price of the product.");
 
        }

    }

}
