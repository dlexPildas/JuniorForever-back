using Microsoft.EntityFrameworkCore.Migrations;

namespace JuniorForever.Repository.Migrations
{
    public partial class add_attribute_authorId_in_table_ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
