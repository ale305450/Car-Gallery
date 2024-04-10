using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learing_Core.Data.Migrations
{
    public partial class IntitalTablesWithImageAsByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rentalCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentalCar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Car_Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumbr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarImage1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CarImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CarImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GalleryId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    RentalCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "gallery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_rentalCar_RentalCarId",
                        column: x => x.RentalCarId,
                        principalTable: "rentalCar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_CompanyId",
                table: "car",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_car_GalleryId",
                table: "car",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_car_RentalCarId",
                table: "car",
                column: "RentalCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "gallery");

            migrationBuilder.DropTable(
                name: "rentalCar");
        }
    }
}
