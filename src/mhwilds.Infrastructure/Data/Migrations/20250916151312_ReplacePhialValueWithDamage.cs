using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplacePhialValueWithDamage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SA_Phial",
                table: "Weapons",
                newName: "SAPhial");

            migrationBuilder.RenameColumn(
                name: "SA_PhialValue",
                table: "Weapons",
                newName: "SAPhialDamageRaw");

            migrationBuilder.RenameColumn(
                name: "CBPhialValue",
                table: "Weapons",
                newName: "SAPhialDamageDisplay");

            migrationBuilder.AddColumn<int>(
                name: "CBPhialDamageDisplay",
                table: "Weapons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBPhialDamageRaw",
                table: "Weapons",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBPhialDamageDisplay",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CBPhialDamageRaw",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "SAPhial",
                table: "Weapons",
                newName: "SA_Phial");

            migrationBuilder.RenameColumn(
                name: "SAPhialDamageRaw",
                table: "Weapons",
                newName: "SA_PhialValue");

            migrationBuilder.RenameColumn(
                name: "SAPhialDamageDisplay",
                table: "Weapons",
                newName: "CBPhialValue");
        }
    }
}
