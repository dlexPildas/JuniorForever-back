using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorForever.Repository.Migrations
{
    public partial class add_postId_to_entity_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
