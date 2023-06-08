using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wheelix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class adjustdriverentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Driver_RentalId",
                table: "Driver");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Driver",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_RentalId",
                table: "Driver",
                column: "RentalId",
                unique: true,
                filter: "[RentalId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Driver_RentalId",
                table: "Driver");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_RentalId",
                table: "Driver",
                column: "RentalId",
                unique: true);
        }
    }
}
