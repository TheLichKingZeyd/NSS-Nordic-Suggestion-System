using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorSuggestionSystem.Migrations
{
    public partial class NullableTeamID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestion_Team_TeamID",
                table: "Suggestion");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Suggestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestion_Team_TeamID",
                table: "Suggestion",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestion_Team_TeamID",
                table: "Suggestion");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestion_Team_TeamID",
                table: "Suggestion",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
