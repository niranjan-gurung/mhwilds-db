using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDecorationSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decorations_Slot_SlotId",
                table: "Decorations");

            migrationBuilder.DropIndex(
                name: "IX_Decorations_SlotId",
                table: "Decorations");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "Decorations",
                newName: "Slot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slot",
                table: "Decorations",
                newName: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Decorations_SlotId",
                table: "Decorations",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decorations_Slot_SlotId",
                table: "Decorations",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
