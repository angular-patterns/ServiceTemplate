using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleSetContextItems");

            migrationBuilder.DropTable(
                name: "RuleSetContexts");

            migrationBuilder.RenameColumn(
                name: "RuleSetContextId",
                table: "RuleSets",
                newName: "ContextId");

            migrationBuilder.RenameColumn(
                name: "RuleContextId",
                table: "ReviewContexts",
                newName: "ContextId");

            migrationBuilder.AddColumn<int>(
                name: "ReviewContextId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ReviewContexts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ContextItemId",
                table: "ReviewContextItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ReviewContextItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewContextId",
                table: "ReviewContextItems",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ReviewContextItems_ReviewContextId",
                table: "ReviewContextItems",
                column: "ReviewContextId");

            migrationBuilder.CreateIndex(
                name: "IX_ContextItems_ContextId",
                table: "ContextItems",
                column: "ContextId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewContextItems_ReviewContexts_ReviewContextId",
                table: "ReviewContextItems",
                column: "ReviewContextId",
                principalTable: "ReviewContexts",
                principalColumn: "ReviewContextId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewContextItems_ReviewContexts_ReviewContextId",
                table: "ReviewContextItems");

            migrationBuilder.DropTable(
                name: "ContextItems");

            migrationBuilder.DropTable(
                name: "Contexts");

            migrationBuilder.DropIndex(
                name: "IX_ReviewContextItems_ReviewContextId",
                table: "ReviewContextItems");

            migrationBuilder.DropColumn(
                name: "ReviewContextId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ContextItemId",
                table: "ReviewContextItems");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "ReviewContextItems");

            migrationBuilder.DropColumn(
                name: "ReviewContextId",
                table: "ReviewContextItems");

            migrationBuilder.RenameColumn(
                name: "ContextId",
                table: "RuleSets",
                newName: "RuleSetContextId");

            migrationBuilder.RenameColumn(
                name: "ContextId",
                table: "ReviewContexts",
                newName: "RuleContextId");

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "ReviewContexts",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "RuleSetContextItems",
                columns: table => new
                {
                    RuleSetContextItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JsonValue = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false)
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    RuleSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSetContexts", x => x.RuleSetContextId);
                });
        }
    }
}
