using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bacit_dotnet.MVC.Migrations
{
    public partial class RenameSuggestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Suggestion",
                table: "Suggestion");

            migrationBuilder.RenameTable(
                name: "Suggestion",
                newName: "Suggestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suggestions",
                table: "Suggestions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Suggestions",
                table: "Suggestions");

            migrationBuilder.RenameTable(
                name: "Suggestions",
                newName: "Suggestion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suggestion",
                table: "Suggestion",
                column: "Id");
        }
    }
}
