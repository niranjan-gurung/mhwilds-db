using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class AddWeaponModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseWeaponId",
                table: "SkillRanks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ammo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Rapid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WeaponType = table.Column<int>(type: "integer", nullable: false),
                    Defense = table.Column<int>(type: "integer", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    Slot = table.Column<List<int>>(type: "integer[]", nullable: true),
                    Affinity = table.Column<int>(type: "integer", nullable: false),
                    DamageRaw = table.Column<int>(type: "integer", nullable: false),
                    DamageDisplay = table.Column<int>(type: "integer", nullable: false),
                    ElementType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ElementDamageRaw = table.Column<int>(type: "integer", nullable: true),
                    ElementDamageDisplay = table.Column<int>(type: "integer", nullable: true),
                    Elderseal = table.Column<int>(type: "integer", nullable: true),
                    Phial = table.Column<string>(type: "text", nullable: true),
                    SharpnessRed = table.Column<int>(type: "integer", nullable: true),
                    SharpnessOrange = table.Column<int>(type: "integer", nullable: true),
                    SharpnessYellow = table.Column<int>(type: "integer", nullable: true),
                    SharpnessGreen = table.Column<int>(type: "integer", nullable: true),
                    SharpnessBlue = table.Column<int>(type: "integer", nullable: true),
                    SharpnessWhite = table.Column<int>(type: "integer", nullable: true),
                    SharpnessPurple = table.Column<int>(type: "integer", nullable: true),
                    SwitchAxe_Phial = table.Column<string>(type: "text", nullable: true),
                    Coatings = table.Column<List<string>>(type: "text[]", nullable: true),
                    AmmoId = table.Column<int>(type: "integer", nullable: true),
                    LightBowgun_AmmoId = table.Column<int>(type: "integer", nullable: true),
                    SpecialAmmo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Ammo_AmmoId",
                        column: x => x.AmmoId,
                        principalTable: "Ammo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_Ammo_LightBowgun_AmmoId",
                        column: x => x.LightBowgun_AmmoId,
                        principalTable: "Ammo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_BaseWeaponId",
                table: "SkillRanks",
                column: "BaseWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AmmoId",
                table: "Weapons",
                column: "AmmoId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_LightBowgun_AmmoId",
                table: "Weapons",
                column: "LightBowgun_AmmoId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponType",
                table: "Weapons",
                column: "WeaponType");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillRanks_Weapons_BaseWeaponId",
                table: "SkillRanks",
                column: "BaseWeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillRanks_Weapons_BaseWeaponId",
                table: "SkillRanks");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Ammo");

            migrationBuilder.DropIndex(
                name: "IX_SkillRanks_BaseWeaponId",
                table: "SkillRanks");

            migrationBuilder.DropColumn(
                name: "BaseWeaponId",
                table: "SkillRanks");
        }
    }
}
