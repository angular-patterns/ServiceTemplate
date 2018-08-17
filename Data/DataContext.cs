using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext: DbContext
    {
       public DbSet<Account> Accounts { get; set; }
       public DbSet<UserProfile> UserProfiles { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
