using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RuleSetId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "ReviewRule",
                columns: table => new
                {
                    ReviewRuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewTypeId = table.Column<int>(nullable: false),
                    RuleSetId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    IsSatisfied = table.Column<bool>(nullable: false),
                    ReviewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRule", x => x.ReviewRuleId);
                    table.ForeignKey(
                        name: "FK_ReviewRule_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleSets_ModelId",
                table: "RuleSets",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTypes_RuleSetId",
                table: "ReviewTypes",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRule_ReviewId",
                table: "ReviewRule",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewTypes_RuleSets_RuleSetId",
                table: "ReviewTypes",
                column: "RuleSetId",
                principalTable: "RuleSets",
                principalColumn: "RuleSetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleSets_Models_ModelId",
                table: "RuleSets",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewTypes_RuleSets_RuleSetId",
                table: "ReviewTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleSets_Models_ModelId",
                table: "RuleSets");

            migrationBuilder.DropTable(
                name: "ReviewRule");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_RuleSets_ModelId",
                table: "RuleSets");

            migrationBuilder.DropIndex(
                name: "IX_ReviewTypes_RuleSetId",
                table: "ReviewTypes");
        }
    }
}
