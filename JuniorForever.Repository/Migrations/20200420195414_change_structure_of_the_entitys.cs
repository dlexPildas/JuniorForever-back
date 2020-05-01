using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorForever.Repository.Migrations
{
    public partial class change_structure_of_the_entitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Authors_AuthorId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Authors_AuthorId",
                table: "Ratings",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
