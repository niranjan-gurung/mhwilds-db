using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveArmourSlugField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Armours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Armours",
                type: "text",
                nullable: true);
        }
    }
}
