using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_GitHub.Migrations
{
    public partial class addUniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_Username",
                table: "UserProfile",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfile_Username",
                table: "UserProfile");
        }
    }
}
