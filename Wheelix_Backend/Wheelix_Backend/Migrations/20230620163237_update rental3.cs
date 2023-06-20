using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wheelix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updaterental3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "driverEmail",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "driverPhone",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "driverEmail",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "driverPhone",
                table: "Rental");
        }
    }
}
