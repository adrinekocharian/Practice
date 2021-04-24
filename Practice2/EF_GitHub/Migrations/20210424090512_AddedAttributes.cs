using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_GitHub.Migrations
{
    public partial class AddedAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repository_UserProfile_ProfileId",
                table: "Repository");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "Profile");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Profile",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Profile",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_Username",
                table: "Profile",
                newName: "IX_Profile_Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Profile_ProfileId",
                table: "Repository",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Profile_ProfileId",
                table: "Repository");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "UserProfile",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserProfile",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_Username",
                table: "UserProfile",
                newName: "IX_UserProfile_Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_UserProfile_ProfileId",
                table: "Repository",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
