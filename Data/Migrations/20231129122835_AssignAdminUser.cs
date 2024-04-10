using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learing_Core.Data.Migrations
{
    public partial class AssignAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into secuirty.UserRoles (UserId,RoleId) select '4968dccb-9d34-4f39-8ab1-bdac692bb0e9',Id from secuirty.Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from  secuirty.UserRoles where UserId ='4968dccb-9d34-4f39-8ab1-bdac692bb0e9'");
        }
    }
}
