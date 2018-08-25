using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "ApplicationDisplayNumbers",
                schema: "shared",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true, defaultValue: ""),
                    LastName = table.Column<string>(nullable: true, defaultValue: ""),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Sin = table.Column<int>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true, defaultValue: ""),
                    PostalCode = table.Column<string>(nullable: true),
                    ProvinceState = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true, defaultValue: ""),
                    ApplicationDisplay = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR shared.ApplicationDisplayNumbers"),
                    VersionNumber = table.Column<int>(nullable: false),
                    RevisionNumber = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true, defaultValue: "System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropSequence(
                name: "ApplicationDisplayNumbers",
                schema: "shared");
        }
    }
}
