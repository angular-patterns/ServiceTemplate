using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewRules_ReviewTypes_ReviewRuleTypeId",
                table: "ReviewRules");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTypes_RuleSets_RuleSetId",
                table: "ReviewTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewTypes",
                table: "ReviewTypes");

            migrationBuilder.RenameTable(
                name: "ReviewTypes",
                newName: "ReviewRuleTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewTypes_RuleSetId",
                table: "ReviewRuleTypes",
                newName: "IX_ReviewRuleTypes_RuleSetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewRuleTypes",
                table: "ReviewRuleTypes",
                column: "ReviewRuleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewRules_ReviewRuleTypes_ReviewRuleTypeId",
                table: "ReviewRules",
                column: "ReviewRuleTypeId",
                principalTable: "ReviewRuleTypes",
                principalColumn: "ReviewRuleTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewRuleTypes_RuleSets_RuleSetId",
                table: "ReviewRuleTypes",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewRules_ReviewRuleTypes_ReviewRuleTypeId",
                table: "ReviewRules");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewRuleTypes_RuleSets_RuleSetId",
                table: "ReviewRuleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewRuleTypes",
                table: "ReviewRuleTypes");

            migrationBuilder.RenameTable(
                name: "ReviewRuleTypes",
                newName: "ReviewTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewRuleTypes_RuleSetId",
                table: "ReviewTypes",
                newName: "IX_ReviewTypes_RuleSetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewTypes",
                table: "ReviewTypes",
                column: "ReviewRuleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewRules_ReviewTypes_ReviewRuleTypeId",
                table: "ReviewRules",
                column: "ReviewRuleTypeId",
                principalTable: "ReviewTypes",
                principalColumn: "ReviewRuleTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTypes_RuleSets_RuleSetId",
                table: "ReviewTypes",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
