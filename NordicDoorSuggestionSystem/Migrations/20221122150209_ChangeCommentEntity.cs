using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorSuggestionSystem.Migrations
{
    public partial class ChangeCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Suggestion_SuggestionID",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "SuggestionID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Suggestion_SuggestionID",
                table: "Comment",
                column: "SuggestionID",
                principalTable: "Suggestion",
                principalColumn: "SuggestionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Suggestion_SuggestionID",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "SuggestionID",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Suggestion_SuggestionID",
                table: "Comment",
                column: "SuggestionID",
                principalTable: "Suggestion",
                principalColumn: "SuggestionID");
        }
    }
}
