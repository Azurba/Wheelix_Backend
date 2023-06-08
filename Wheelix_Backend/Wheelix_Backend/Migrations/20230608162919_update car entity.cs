using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wheelix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updatecarentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Car_RentalId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "BadSupport",
                table: "Car",
                newName: "BagSupport");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Car",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentalId",
                table: "Car",
                column: "RentalId",
                unique: true,
                filter: "[RentalId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Car_RentalId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "BagSupport",
                table: "Car",
                newName: "BadSupport");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentalId",
                table: "Car",
                column: "RentalId",
                unique: true);
        }
    }
}
