﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180824000322_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("CSharpSource");

                    b.Property<string>("JsonSchema");

                    b.Property<string>("Namespace");

                    b.Property<string>("Source");

                    b.Property<string>("TypeName");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("JsonValue");

                    b.Property<int>("RevisionNumber");

                    b.Property<int>("RuleSetId");

                    b.Property<int>("VersionNumber");

                    b.HasKey("ReviewId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Entities.ReviewRule", b =>
                {
                    b.Property<int>("ReviewRuleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<bool>("IsSatisfied");

                    b.Property<string>("Message");

                    b.Property<int>("ReviewId");

                    b.Property<int>("ReviewTypeId");

                    b.HasKey("ReviewRuleId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("ReviewTypeId");

                    b.ToTable("ReviewRules");
                });

            modelBuilder.Entity("Entities.ReviewType", b =>
                {
                    b.Property<int>("ReviewTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<string>("Logic");

                    b.Property<string>("Message");

                    b.Property<int>("RuleSetId");

                    b.HasKey("ReviewTypeId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("ReviewTypes");
                });

            modelBuilder.Entity("Entities.RuleSet", b =>
                {
                    b.Property<int>("RuleSetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ModelId");

                    b.Property<string>("Title");

                    b.HasKey("RuleSetId");

                    b.HasIndex("ModelId");

                    b.ToTable("RuleSets");
                });

            modelBuilder.Entity("Entities.Review", b =>
                {
                    b.HasOne("Entities.RuleSet", "RuleSet")
                        .WithMany("Reviews")
                        .HasForeignKey("RuleSetId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.ReviewRule", b =>
                {
                    b.HasOne("Entities.Review")
                        .WithMany("ReviewRules")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.ReviewType", "ReviewType")
                        .WithMany()
                        .HasForeignKey("ReviewTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ReviewType", b =>
                {
                    b.HasOne("Entities.RuleSet")
                        .WithMany("ReviewTypes")
                        .HasForeignKey("RuleSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.RuleSet", b =>
                {
                    b.HasOne("Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
