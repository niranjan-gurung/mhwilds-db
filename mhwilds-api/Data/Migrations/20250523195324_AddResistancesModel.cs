using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class AddResistancesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fire = table.Column<string>(type: "text", nullable: false),
                    Water = table.Column<string>(type: "text", nullable: false),
                    Ice = table.Column<string>(type: "text", nullable: false),
                    Thunder = table.Column<string>(type: "text", nullable: false),
                    Dragon = table.Column<string>(type: "text", nullable: false),
                    ArmourId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resistances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resistances_Armours_ArmourId",
                        column: x => x.ArmourId,
                        principalTable: "Armours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resistances_ArmourId",
                table: "Resistances",
                column: "ArmourId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resistances");
        }
    }
}
