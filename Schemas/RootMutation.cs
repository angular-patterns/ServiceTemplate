using Business.Mutations.Accounts;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation(CreateProductMutation createProduct, DeleteProductMutation deleteProduct)
        {
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "name", DefaultValue = "" }
                    ,new QueryArgument<DecimalGraphType>() { Name = "price", DefaultValue = 0.00M }),
                resolve: ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    var price = ctx.GetArgument<decimal>("price");
                    var product = createProduct.Create(name, price);
                    return product;
                });

            Field<BooleanGraphType>("deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }
                ),
                resolve: ctx =>
                {
                    var accountId = ctx.GetArgument<int>("id");
                    deleteProduct.Delete(accountId);
                    return true;
                });

        }
    }
}
