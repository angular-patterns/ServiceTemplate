using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext: DbContext
    {
       public DbSet<Model> Models { get; set; }

       public DbSet<RuleSet> RuleSets { get; set; }


       public DbSet<ReviewRuleType> ReviewRuleTypes { get; set; }

       public DbSet<Review> Reviews { get; set; }

       public DbSet<ReviewRule> ReviewRules { get; set; }

       public DbSet<Context> Contexts { get; set; }

        public DbSet<ContextItem> ContextItems { get; set; }

        public DbSet<ReviewContext> ReviewContexts { get; set; }

        public DbSet<ReviewContextItem> ReviewContextItems { get; set; }


        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
            .HasOne(t=>t.RuleSet)
            .WithMany(t=>t.Reviews)
            .HasForeignKey(t=>t.RuleSetId)
            .OnDelete(DeleteBehavior.Restrict); // set ON DELETE CASCADE

            modelBuilder.Entity<ReviewRuleType>()
                .HasIndex(t => new { t.RuleSetId, t.BusinessId })
                .IsUnique();

            modelBuilder
                .Entity<RuleSet>()
                .Property(e => e.Status)
                .HasConversion<string>();

        }

        public void Seed()
        {
            
        }

    }
}
