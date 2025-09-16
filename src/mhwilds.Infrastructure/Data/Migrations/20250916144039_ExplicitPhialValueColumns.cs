using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitPhialValueColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phial_Value",
                table: "Weapons",
                newName: "SA_PhialValue");

            migrationBuilder.RenameColumn(
                name: "Phial_Type",
                table: "Weapons",
                newName: "SA_Phial");

            migrationBuilder.AlterColumn<string>(
                name: "SA_Phial",
                table: "Weapons",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CBPhial",
                table: "Weapons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CBPhialValue",
                table: "Weapons",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBPhial",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CBPhialValue",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "SA_PhialValue",
                table: "Weapons",
                newName: "Phial_Value");

            migrationBuilder.RenameColumn(
                name: "SA_Phial",
                table: "Weapons",
                newName: "Phial_Type");

            migrationBuilder.AlterColumn<int>(
                name: "Phial_Type",
                table: "Weapons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
