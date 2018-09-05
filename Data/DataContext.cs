
using Microsoft.EntityFrameworkCore;
using System;
using Entities;

namespace Data
{
    public class DataContext: DbContext
    {
        public DbQuery<ReviewView> ReviewViews { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
