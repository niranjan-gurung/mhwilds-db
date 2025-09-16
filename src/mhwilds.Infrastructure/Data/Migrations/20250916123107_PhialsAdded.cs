using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhialsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SwitchAxe_Phial",
                table: "Weapons",
                newName: "Phial_Value");

            migrationBuilder.RenameColumn(
                name: "Phial",
                table: "Weapons",
                newName: "Phial_Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phial_Value",
                table: "Weapons",
                newName: "SwitchAxe_Phial");

            migrationBuilder.RenameColumn(
                name: "Phial_Type",
                table: "Weapons",
                newName: "Phial");
        }
    }
}
