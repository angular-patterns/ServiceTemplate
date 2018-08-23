using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReviewRules_ReviewTypeId",
                table: "ReviewRules",
                column: "ReviewTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewRules_ReviewTypes_ReviewTypeId",
                table: "ReviewRules",
                column: "ReviewTypeId",
                principalTable: "ReviewTypes",
                principalColumn: "ReviewTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewRules_ReviewTypes_ReviewTypeId",
                table: "ReviewRules");

            migrationBuilder.DropIndex(
                name: "IX_ReviewRules_ReviewTypeId",
                table: "ReviewRules");
        }
    }
}
