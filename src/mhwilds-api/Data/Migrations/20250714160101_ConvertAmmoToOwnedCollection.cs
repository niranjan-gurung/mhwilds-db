using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class ConvertAmmoToOwnedCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammo_Capacity",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Ammo_Level",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Ammo_Rapid",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Ammo_Type",
                table: "Weapons");

            migrationBuilder.CreateTable(
                name: "HeavyBowgunAmmo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeavyBowgunId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Rapid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeavyBowgunAmmo", x => new { x.HeavyBowgunId, x.Id });
                    table.ForeignKey(
                        name: "FK_HeavyBowgunAmmo_Weapons_HeavyBowgunId",
                        column: x => x.HeavyBowgunId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LightBowgunAmmo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LightBowgunId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Rapid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightBowgunAmmo", x => new { x.LightBowgunId, x.Id });
                    table.ForeignKey(
                        name: "FK_LightBowgunAmmo_Weapons_LightBowgunId",
                        column: x => x.LightBowgunId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeavyBowgunAmmo");

            migrationBuilder.DropTable(
                name: "LightBowgunAmmo");

            migrationBuilder.AddColumn<int>(
                name: "Ammo_Capacity",
                table: "Weapons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ammo_Level",
                table: "Weapons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ammo_Rapid",
                table: "Weapons",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ammo_Type",
                table: "Weapons",
                type: "text",
                nullable: true);
        }
    }
}
