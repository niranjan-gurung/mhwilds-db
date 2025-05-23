using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class AddSKillFieldToArmour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
