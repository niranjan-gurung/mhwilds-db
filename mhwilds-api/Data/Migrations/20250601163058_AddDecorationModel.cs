using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class AddDecorationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecorationId",
                table: "SkillRanks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Decorations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    SlotId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decorations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decorations_Slot_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_DecorationId",
                table: "SkillRanks",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_SlotId",
                table: "Decorations",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillRanks_Decorations_DecorationId",
                table: "SkillRanks",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillRanks_Decorations_DecorationId",
                table: "SkillRanks");

            migrationBuilder.DropTable(
                name: "Decorations");

            migrationBuilder.DropIndex(
                name: "IX_SkillRanks_DecorationId",
                table: "SkillRanks");

            migrationBuilder.DropColumn(
                name: "DecorationId",
                table: "SkillRanks");
        }
    }
}
