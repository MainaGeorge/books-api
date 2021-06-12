using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class RenamingRatingToRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Books",
                newName: "Rate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Books",
                newName: "Rating");
        }
    }
}
