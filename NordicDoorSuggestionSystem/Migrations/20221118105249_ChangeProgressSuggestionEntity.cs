using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorSuggestionSystem.Migrations
{
    public partial class ChangeProgressSuggestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamSgstnCount",
                table: "Team",
                type: "int",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Progress",
                table: "Suggestion",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "SuggestionCount",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ushort>(
                name: "TeamSgstnCount",
                table: "Team",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Progress",
                table: "Suggestion",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ushort>(
                name: "SuggestionCount",
                table: "Employee",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
