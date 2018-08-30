using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contexts",
                columns: table => new
                {
                    ContextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contexts", x => x.ContextId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    JsonSchema = table.Column<string>(nullable: true),
                    CSharpSource = table.Column<string>(nullable: true),
                    Namespace = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "ReviewContexts",
                columns: table => new
                {
                    ReviewContextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContextId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewContexts", x => x.ReviewContextId);
                });

            migrationBuilder.CreateTable(
                name: "ContextItems",
                columns: table => new
                {
                    ContextItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContextId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContextItems", x => x.ContextItemId);
                    table.ForeignKey(
                        name: "FK_ContextItems_Contexts_ContextId",
                        column: x => x.ContextId,
                        principalTable: "Contexts",
                        principalColumn: "ContextId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RuleSets",
                columns: table => new
                {
                    RuleSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: false),
                    ContextId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSets", x => x.RuleSetId);
                    table.ForeignKey(
                        name: "FK_RuleSets_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewContextItems",
                columns: table => new
                {
                    ReviewContextItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewContextId = table.Column<int>(nullable: false),
                    ContextItemId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewContextItems", x => x.ReviewContextItemId);
                    table.ForeignKey(
                        name: "FK_ReviewContextItems_ReviewContexts_ReviewContextId",
                        column: x => x.ReviewContextId,
                        principalTable: "ReviewContexts",
                        principalColumn: "ReviewContextId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewRuleTypes",
                columns: table => new
                {
                    ReviewRuleTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RuleSetId = table.Column<int>(nullable: false),
                    Logic = table.Column<string>(nullable: true),
                    BusinessId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRuleTypes", x => x.ReviewRuleTypeId);
                    table.ForeignKey(
                        name: "FK_ReviewRuleTypes_RuleSets_RuleSetId",
                        column: x => x.RuleSetId,
                        principalTable: "RuleSets",
                        principalColumn: "RuleSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RuleSetId = table.Column<int>(nullable: false),
                    ReviewContextId = table.Column<int>(nullable: false),
                    JsonValue = table.Column<string>(nullable: true),
                    BusinessId = table.Column<string>(nullable: true),
                    VersionNumber = table.Column<int>(nullable: false),
                    RevisionNumber = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_RuleSets_RuleSetId",
                        column: x => x.RuleSetId,
                        principalTable: "RuleSets",
                        principalColumn: "RuleSetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewRules",
                columns: table => new
                {
                    ReviewRuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewId = table.Column<int>(nullable: false),
                    ReviewRuleTypeId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    IsSatisfied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRules", x => x.ReviewRuleId);
                    table.ForeignKey(
                        name: "FK_ReviewRules_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewRules_ReviewRuleTypes_ReviewRuleTypeId",
                        column: x => x.ReviewRuleTypeId,
                        principalTable: "ReviewRuleTypes",
                        principalColumn: "ReviewRuleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContextItems_ContextId",
                table: "ContextItems",
                column: "ContextId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewContextItems_ReviewContextId",
                table: "ReviewContextItems",
                column: "ReviewContextId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRules_ReviewId",
                table: "ReviewRules",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRules_ReviewRuleTypeId",
                table: "ReviewRules",
                column: "ReviewRuleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRuleTypes_RuleSetId_BusinessId",
                table: "ReviewRuleTypes",
                columns: new[] { "RuleSetId", "BusinessId" },
                unique: true,
                filter: "[BusinessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RuleSetId",
                table: "Reviews",
                column: "RuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleSets_ModelId",
                table: "RuleSets",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContextItems");

            migrationBuilder.DropTable(
                name: "ReviewContextItems");

            migrationBuilder.DropTable(
                name: "ReviewRules");

            migrationBuilder.DropTable(
                name: "Contexts");

            migrationBuilder.DropTable(
                name: "ReviewContexts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ReviewRuleTypes");

            migrationBuilder.DropTable(
                name: "RuleSets");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
