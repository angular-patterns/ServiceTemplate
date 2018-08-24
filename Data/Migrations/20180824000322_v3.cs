using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RuleSets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "RuleSets",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Reviews",
                newName: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "RuleSets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "RuleSets",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Reviews",
                newName: "Code");
        }
    }
}
