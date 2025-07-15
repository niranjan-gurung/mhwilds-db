using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class BowCoatingsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Coatings",
                table: "Weapons",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Coatings",
                table: "Weapons",
                type: "text",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);
        }
    }
}
