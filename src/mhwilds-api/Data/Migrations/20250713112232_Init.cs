using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Armours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    Defense = table.Column<int>(type: "integer", nullable: false),
                    Resistances_Fire = table.Column<int>(type: "integer", nullable: true),
                    Resistances_Water = table.Column<int>(type: "integer", nullable: true),
                    Resistances_Ice = table.Column<int>(type: "integer", nullable: true),
                    Resistances_Thunder = table.Column<int>(type: "integer", nullable: true),
                    Resistances_Dragon = table.Column<int>(type: "integer", nullable: true),
                    Slots = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charms", x => x.Id);
                });

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
                    Slot = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decorations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
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
                    Phial = table.Column<int>(type: "integer", nullable: true),
                    SharpnessRed = table.Column<int>(type: "integer", nullable: true),
                    SharpnessOrange = table.Column<int>(type: "integer", nullable: true),
                    SharpnessYellow = table.Column<int>(type: "integer", nullable: true),
                    SharpnessGreen = table.Column<int>(type: "integer", nullable: true),
                    SharpnessBlue = table.Column<int>(type: "integer", nullable: true),
                    SharpnessWhite = table.Column<int>(type: "integer", nullable: true),
                    SharpnessPurple = table.Column<int>(type: "integer", nullable: true),
                    SwitchAxe_Phial = table.Column<int>(type: "integer", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "CharmRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
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
                name: "SkillRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillRanks_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "BaseWeaponSkillRank",
                columns: table => new
                {
                    BaseWeaponId = table.Column<int>(type: "integer", nullable: false),
                    SkillsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWeaponSkillRank", x => new { x.BaseWeaponId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_BaseWeaponSkillRank_SkillRanks_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SkillRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseWeaponSkillRank_Weapons_BaseWeaponId",
                        column: x => x.BaseWeaponId,
                        principalTable: "Weapons",
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
                name: "IX_ArmourSkillRank_SkillsId",
                table: "ArmourSkillRank",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseWeaponSkillRank_SkillsId",
                table: "BaseWeaponSkillRank",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharmRanks_CharmId",
                table: "CharmRanks",
                column: "CharmId");

            migrationBuilder.CreateIndex(
                name: "IX_CharmRankSkillRank_SkillsId",
                table: "CharmRankSkillRank",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_DecorationSkillRank_SkillsId",
                table: "DecorationSkillRank",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillRanks_SkillId",
                table: "SkillRanks",
                column: "SkillId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmourSkillRank");

            migrationBuilder.DropTable(
                name: "BaseWeaponSkillRank");

            migrationBuilder.DropTable(
                name: "CharmRankSkillRank");

            migrationBuilder.DropTable(
                name: "DecorationSkillRank");

            migrationBuilder.DropTable(
                name: "Armours");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "CharmRanks");

            migrationBuilder.DropTable(
                name: "Decorations");

            migrationBuilder.DropTable(
                name: "SkillRanks");

            migrationBuilder.DropTable(
                name: "Ammo");

            migrationBuilder.DropTable(
                name: "Charms");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
