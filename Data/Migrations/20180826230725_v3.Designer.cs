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
    [Migration("20180826230725_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Context", b =>
                {
                    b.Property<int>("ContextId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("ContextId");

                    b.ToTable("Contexts");
                });

            modelBuilder.Entity("Entities.ContextItem", b =>
                {
                    b.Property<int>("ContextItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContextId");

                    b.Property<string>("JsonValue");

                    b.Property<string>("Key");

                    b.Property<int>("ModelId");

                    b.HasKey("ContextItemId");

                    b.HasIndex("ContextId");

                    b.ToTable("ContextItems");
                });

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

                    b.Property<int>("ReviewContextId");

                    b.Property<int>("RevisionNumber");

                    b.Property<int>("RuleSetId");

                    b.Property<int>("VersionNumber");

                    b.HasKey("ReviewId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Entities.ReviewContext", b =>
                {
                    b.Property<int>("ReviewContextId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContextId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.HasKey("ReviewContextId");

                    b.ToTable("ReviewContexts");
                });

            modelBuilder.Entity("Entities.ReviewContextItem", b =>
                {
                    b.Property<int>("ReviewContextItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContextItemId");

                    b.Property<string>("JsonValue");

                    b.Property<string>("Key");

                    b.Property<int>("ModelId");

                    b.Property<int>("ReviewContextId");

                    b.HasKey("ReviewContextItemId");

                    b.HasIndex("ReviewContextId");

                    b.ToTable("ReviewContextItems");
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

                    b.Property<int>("ReviewRuleTypeId");

                    b.HasKey("ReviewRuleId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("ReviewRuleTypeId");

                    b.ToTable("ReviewRules");
                });

            modelBuilder.Entity("Entities.ReviewRuleType", b =>
                {
                    b.Property<int>("ReviewRuleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<string>("Logic");

                    b.Property<string>("Message");

                    b.Property<int>("RuleSetId");

                    b.HasKey("ReviewRuleTypeId");

                    b.HasIndex("RuleSetId");

                    b.ToTable("ReviewRuleTypes");
                });

            modelBuilder.Entity("Entities.RuleSet", b =>
                {
                    b.Property<int>("RuleSetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessId");

                    b.Property<int>("ContextId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ModelId");

                    b.Property<string>("Title");

                    b.HasKey("RuleSetId");

                    b.HasIndex("ModelId");

                    b.ToTable("RuleSets");
                });

            modelBuilder.Entity("Entities.ContextItem", b =>
                {
                    b.HasOne("Entities.Context")
                        .WithMany("ContextItems")
                        .HasForeignKey("ContextId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Review", b =>
                {
                    b.HasOne("Entities.RuleSet", "RuleSet")
                        .WithMany("Reviews")
                        .HasForeignKey("RuleSetId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.ReviewContextItem", b =>
                {
                    b.HasOne("Entities.ReviewContext")
                        .WithMany("ContextItems")
                        .HasForeignKey("ReviewContextId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ReviewRule", b =>
                {
                    b.HasOne("Entities.Review")
                        .WithMany("ReviewRules")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.ReviewRuleType", "ReviewType")
                        .WithMany()
                        .HasForeignKey("ReviewRuleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ReviewRuleType", b =>
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
