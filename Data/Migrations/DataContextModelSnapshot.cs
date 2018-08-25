﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:shared.ApplicationDisplayNumbers", "'ApplicationDisplayNumbers', 'shared', '1000', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("ApplicationDisplay")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR shared.ApplicationDisplayNumbers");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("City")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.Property<string>("Country")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("System");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ProvinceState");

                    b.Property<int>("RevisionNumber");

                    b.Property<int?>("Sin");

                    b.Property<string>("Street");

                    b.Property<int>("VersionNumber");

                    b.HasKey("ApplicationId");

                    b.ToTable("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
