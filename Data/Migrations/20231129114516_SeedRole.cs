using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learing_Core.Data.Migrations
{
    public partial class SeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table:"Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values:new object[] {Guid.NewGuid().ToString(),"User","User".ToUpper(),Guid.NewGuid().ToString() },
                schema: "secuirty"
                );


            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() },
                schema: "secuirty"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [secuirty].[Roles]");
        }
    }
}
