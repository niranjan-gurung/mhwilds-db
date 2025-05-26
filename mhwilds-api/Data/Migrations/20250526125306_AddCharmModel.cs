using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCharmModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharmRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    CharmId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharmRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharmRanks_Charms_CharmId",
                        column: x => x.CharmId,
                        principalTable: "Charms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharmRankSkillRank",
                columns: table => new
                {
                    CharmsId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharmRankSkillRank", x => new { x.CharmsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CharmRankSkillRank_CharmRanks_CharmsId",
                        column: x => x.CharmsId,
                        principalTable: "CharmRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharmRankSkillRank_SkillRanks_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SkillRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharmRanks_CharmId",
                table: "CharmRanks",
                column: "CharmId");

            migrationBuilder.CreateIndex(
                name: "IX_CharmRankSkillRank_SkillsId",
                table: "CharmRankSkillRank",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharmRankSkillRank");

            migrationBuilder.DropTable(
                name: "CharmRanks");

            migrationBuilder.DropTable(
                name: "Charms");
        }
    }
}
