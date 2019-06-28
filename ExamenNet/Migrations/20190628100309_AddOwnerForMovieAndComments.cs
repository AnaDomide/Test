using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenNet.Migrations
{
    public partial class AddOwnerForMovieAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Movies",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                newName: "IX_Movies_OwnerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "AddedById");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AddedById",
                table: "Comments",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_OwnerId",
                table: "Movies",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AddedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_OwnerId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Movies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_OwnerId",
                table: "Movies",
                newName: "IX_Movies_UserId");

            migrationBuilder.RenameColumn(
                name: "AddedById",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AddedById",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
