using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RuleSets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RevisionNumber",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNumber",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "RuleSets");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RevisionNumber",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "Reviews");
        }
    }
}
