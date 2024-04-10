using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learing_Core.Data.Migrations
{
    public partial class RentalLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT rentalCar ON");
            migrationBuilder.Sql("insert into rentalCar (Id,Length) Values(1,'10 Days')");
            migrationBuilder.Sql("insert into rentalCar (Id,Length) Values(2,'20 Days')");
            migrationBuilder.Sql("insert into rentalCar (Id,Length) Values(3,'1 Month')");
            migrationBuilder.Sql("insert into rentalCar (Id,Length) Values(4,'2 Month')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT rentalCar OFF");
            migrationBuilder.Sql("delete from rentalCar where id = 1");
            migrationBuilder.Sql("delete from rentalCar where id = 2");
            migrationBuilder.Sql("delete from rentalCar where id = 3");
            migrationBuilder.Sql("delete from rentalCar where id = 4");
        }
    }
}
