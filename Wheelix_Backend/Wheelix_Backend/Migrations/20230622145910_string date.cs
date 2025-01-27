﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wheelix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class stringdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BagSupport = table.Column<int>(type: "int", nullable: false),
                    PeopleSupport = table.Column<int>(type: "int", nullable: false),
                    LicencePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DriverLicense = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPStackAPI",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APIKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPStackAPI", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    additionals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Additionals");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "IPStackAPI");

            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
