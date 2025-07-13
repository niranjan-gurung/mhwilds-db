using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedElderSealWeaponModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elderseal",
                table: "Weapons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Elderseal",
                table: "Weapons",
                type: "integer",
                nullable: true);
        }
    }
}
