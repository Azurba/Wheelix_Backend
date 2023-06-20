using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wheelix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updaterental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "carId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "driverId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "rentalDate",
                table: "Rental");

            migrationBuilder.RenameColumn(
                name: "additionalsId",
                table: "Rental",
                newName: "locationName");

            migrationBuilder.AddColumn<string>(
                name: "additionals",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "carName",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "carType",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "driverName",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "locationAddress",
                table: "Rental",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "additionals",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "carName",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "carType",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "driverName",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "locationAddress",
                table: "Rental");

            migrationBuilder.RenameColumn(
                name: "locationName",
                table: "Rental",
                newName: "additionalsId");

            migrationBuilder.AddColumn<int>(
                name: "carId",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "driverId",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "rentalDate",
                table: "Rental",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
