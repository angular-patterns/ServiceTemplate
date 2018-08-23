using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext: DbContext
    {
       public DbSet<Model> Models { get; set; }

       public DbSet<RuleSet> RuleSets { get; set; }


       public DbSet<ReviewType> ReviewTypes { get; set; }

       public DbSet<Review> Reviews { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
