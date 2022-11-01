using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bacit_dotnet.MVC.Migrations
{
    public partial class ChangeSuggestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Suggestions",
                newName: "Solution");

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Suggestions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Suggestions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Suggestions");

            migrationBuilder.RenameColumn(
                name: "Solution",
                table: "Suggestions",
                newName: "Context");
        }
    }
}
