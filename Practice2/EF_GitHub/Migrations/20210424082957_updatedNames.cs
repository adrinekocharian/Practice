using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_GitHub.Migrations
{
    public partial class updatedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repositories_UserProfiles_ProfileId",
                table: "Repositories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repositories",
                table: "Repositories");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "UserProfile");

            migrationBuilder.RenameTable(
                name: "Repositories",
                newName: "Repository");

            migrationBuilder.RenameIndex(
                name: "IX_Repositories_ProfileId",
                table: "Repository",
                newName: "IX_Repository_ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Repository",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repository",
                table: "Repository",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_UserProfile_ProfileId",
                table: "Repository",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repository_UserProfile_ProfileId",
                table: "Repository");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repository",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Repository");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "Repository",
                newName: "Repositories");

            migrationBuilder.RenameIndex(
                name: "IX_Repository_ProfileId",
                table: "Repositories",
                newName: "IX_Repositories_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repositories",
                table: "Repositories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repositories_UserProfiles_ProfileId",
                table: "Repositories",
                column: "ProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
