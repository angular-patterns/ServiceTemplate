
using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .Property(b => b.City)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.Country)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.FirstName)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.LastName)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Application>()
                .Property(b => b.CreatedBy)
                .HasDefaultValue("System");


            modelBuilder.HasSequence<int>("ApplicationDisplayNumbers", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.Entity<Application>()
                .Property(o => o.ApplicationDisplay)
                .HasDefaultValueSql("NEXT VALUE FOR shared.ApplicationDisplayNumbers");
        }

    }
}
