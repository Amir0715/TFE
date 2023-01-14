using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorOfTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorProfileId",
                table: "Tests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AuthorProfileId",
                table: "Tests",
                column: "AuthorProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_UserProfiles_AuthorProfileId",
                table: "Tests",
                column: "AuthorProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_UserProfiles_AuthorProfileId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AuthorProfileId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AuthorProfileId",
                table: "Tests");
        }
    }
}
