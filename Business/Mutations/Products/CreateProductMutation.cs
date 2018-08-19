using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.Accounts
{
    public class CreateProductMutation: GraphBase
    {
        public CreateProductMutation(DataContext context) : base(context)
        {

        }

        public Product Create(string name, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Price = price
            };

            Context.Products.Add(product);
            Context.SaveChanges();
            return product;
        }

    }
}
