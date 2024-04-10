using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learing_Core.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [secuirty].[Users] ([Id], [FirstName], [LastName], [ProfilePic], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'4968dccb-9d34-4f39-8ab1-bdac692bb0e9', N'Ali Khalid', N'Bamatraf',NULL, 0, N'8bf52a34-494b-4a07-99d6-ceda1049dd45', N'admin@test.com', 0, 1, NULL, N'ADMIN@TEST.COM', N'ADMIN', N'AQAAAAEAACcQAAAAELda3YuobSgrdakd/hE1SCD8s3gSONkMp+ur0CX+DHdxJuOl3ivEs7YErbtX37saJQ==', NULL, 0, N'OFK3BNLG3DC6YIWSPYJYMXVZYGGUDFTJ', 0, N'admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM [secuirty].[Users] Where id = '4968dccb-9d34-4f39-8ab1-bdac692bb0e9'");
        }
    }
}
