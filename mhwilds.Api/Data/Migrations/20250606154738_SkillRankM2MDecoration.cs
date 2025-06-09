using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class SkillRankM2MDecoration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillRanks_Decorations_DecorationId",
                table: "SkillRanks");

            migrationBuilder.DropIndex(
                name: "IX_SkillRanks_DecorationId",
                table: "SkillRanks");

            migrationBuilder.DropColumn(
                name: "DecorationId",
                table: "SkillRanks");

            migrationBuilder.CreateTable(
                name: "DecorationSkillRank",
                columns: table => new
                {
                    DecorationsId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationSkillRank", x => new { x.DecorationsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_DecorationSkillRank_Decorations_DecorationsId",
                        column: x => x.DecorationsId,
                        principalTable: "Decorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecorationSkillRank_SkillRanks_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SkillRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecorationSkillRank_SkillsId",
                table: "DecorationSkillRank",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecorationSkillRank");

            migrationBuilder.AddColumn<int>(
                name: "DecorationId",
                table: "SkillRanks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_DecorationId",
                table: "SkillRanks",
                column: "DecorationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillRanks_Decorations_DecorationId",
                table: "SkillRanks",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id");
        }
    }
}
