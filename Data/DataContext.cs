
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
                .HasIndex(t => new { t.ApplicationDisplay, t.VersionNumber, t.RevisionNumber })
                .IsUnique();

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
                .Property(b => b.Street)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.PostalCode)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.ProvinceState)
                .HasDefaultValue("");

            modelBuilder.Entity<Application>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Application>()
                .Property(b => b.CreatedBy)
                .HasDefaultValue("System");

            modelBuilder.Entity<Application>()
                .Property(b => b.VersionNumber)
                .HasDefaultValue(1);

            modelBuilder.Entity<Application>()
                .Property(b => b.RevisionNumber)
                .HasDefaultValue(1);

            modelBuilder.HasSequence<int>("ApplicationDisplayNumbers", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.Entity<Application>()
                .Property(o => o.ApplicationDisplay)
                .HasDefaultValueSql("NEXT VALUE FOR shared.ApplicationDisplayNumbers");
        }

    }
}
