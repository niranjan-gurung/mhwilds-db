using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class SkillAndSkillRankRelationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillRanks_Skills_SkillId1",
                table: "SkillRanks");

            migrationBuilder.DropIndex(
                name: "IX_SkillRanks_SkillId1",
                table: "SkillRanks");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "SkillRanks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId1",
                table: "SkillRanks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_SkillId1",
                table: "SkillRanks",
                column: "SkillId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillRanks_Skills_SkillId1",
                table: "SkillRanks",
                column: "SkillId1",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
