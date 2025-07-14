using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class ConvertAmmoToOwnedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Ammo_AmmoId",
                table: "Weapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Ammo_LightBowgun_AmmoId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "Ammo");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_AmmoId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_LightBowgun_AmmoId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "LightBowgun_AmmoId",
                table: "Weapons",
                newName: "Ammo_Level");

            migrationBuilder.RenameColumn(
                name: "AmmoId",
                table: "Weapons",
                newName: "Ammo_Capacity");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammo_Rapid",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Ammo_Type",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "Ammo_Level",
                table: "Weapons",
                newName: "LightBowgun_AmmoId");

            migrationBuilder.RenameColumn(
                name: "Ammo_Capacity",
                table: "Weapons",
                newName: "AmmoId");

            migrationBuilder.CreateTable(
                name: "Ammo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Rapid = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AmmoId",
                table: "Weapons",
                column: "AmmoId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_LightBowgun_AmmoId",
                table: "Weapons",
                column: "LightBowgun_AmmoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Ammo_AmmoId",
                table: "Weapons",
                column: "AmmoId",
                principalTable: "Ammo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Ammo_LightBowgun_AmmoId",
                table: "Weapons",
                column: "LightBowgun_AmmoId",
                principalTable: "Ammo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
