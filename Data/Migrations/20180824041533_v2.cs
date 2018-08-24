using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RuleSetContextId",
                table: "RuleSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReviewContextItems",
                columns: table => new
                {
                    ReviewContextItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewContextItems", x => x.ReviewContextItemId);
                });

            migrationBuilder.CreateTable(
                name: "ReviewContexts",
                columns: table => new
                {
                    ReviewContextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RuleContextId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewContexts", x => x.ReviewContextId);
                });

            migrationBuilder.CreateTable(
                name: "RuleSetContextItems",
                columns: table => new
                {
                    RuleSetContextItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSetContextItems", x => x.RuleSetContextItemId);
                });

            migrationBuilder.CreateTable(
                name: "RuleSetContexts",
                columns: table => new
                {
                    RuleSetContextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RuleSetId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSetContexts", x => x.RuleSetContextId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewContextItems");

            migrationBuilder.DropTable(
                name: "ReviewContexts");

            migrationBuilder.DropTable(
                name: "RuleSetContextItems");

            migrationBuilder.DropTable(
                name: "RuleSetContexts");

            migrationBuilder.DropColumn(
                name: "RuleSetContextId",
                table: "RuleSets");
        }
    }
}
