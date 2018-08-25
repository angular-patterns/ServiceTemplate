using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationDisplay_VersionNumber_RevisionNumber",
                table: "Applications",
                columns: new[] { "ApplicationDisplay", "VersionNumber", "RevisionNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationDisplay_VersionNumber_RevisionNumber",
                table: "Applications");
        }
    }
}
