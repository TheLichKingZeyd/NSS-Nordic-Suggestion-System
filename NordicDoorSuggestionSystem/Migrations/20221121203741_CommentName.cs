using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorSuggestionSystem.Migrations
{
    public partial class CommentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Comment",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Comment",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Comment");
        }
    }
}
