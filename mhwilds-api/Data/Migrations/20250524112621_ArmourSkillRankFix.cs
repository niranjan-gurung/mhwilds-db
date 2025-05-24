using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class ArmourSkillRankFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillRanks_Armours_ArmourId",
                table: "SkillRanks");

            migrationBuilder.DropIndex(
                name: "IX_SkillRanks_ArmourId",
                table: "SkillRanks");

            migrationBuilder.DropColumn(
                name: "ArmourId",
                table: "SkillRanks");

            migrationBuilder.CreateTable(
                name: "ArmourSkillRank",
                columns: table => new
                {
                    ArmoursId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourSkillRank", x => new { x.ArmoursId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ArmourSkillRank_Armours_ArmoursId",
                        column: x => x.ArmoursId,
                        principalTable: "Armours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmourSkillRank_SkillRanks_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SkillRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmourSkillRank_SkillsId",
                table: "ArmourSkillRank",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmourSkillRank");

            migrationBuilder.AddColumn<int>(
                name: "ArmourId",
                table: "SkillRanks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_ArmourId",
                table: "SkillRanks",
                column: "ArmourId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillRanks_Armours_ArmourId",
                table: "SkillRanks",
                column: "ArmourId",
                principalTable: "Armours",
                principalColumn: "Id");
        }
    }
}
