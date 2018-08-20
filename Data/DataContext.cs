using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext: DbContext
    {
       public DbSet<ShoppingCart> ShoppingCarts { get; set; }
       public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
