using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries.Products
{
    public class ProductsQuery: GraphBase
    {
        public ProductsQuery(DataContext context): base(context)
        {

        }

        public IList<Product> GetAllProducts()
        {
            return Context.Products.ToList();
        }

        public Product FindById(int id)
        {
            return Context.Products.Find(id);
        }
    }
}
