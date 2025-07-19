using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class GunlanceAndInsectGlaiveModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KinsectLevel",
                table: "Weapons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shell_Level",
                table: "Weapons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shell_Type",
                table: "Weapons",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KinsectLevel",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Shell_Level",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Shell_Type",
                table: "Weapons");
        }
    }
}
