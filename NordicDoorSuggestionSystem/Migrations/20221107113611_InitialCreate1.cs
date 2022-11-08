using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorSuggestionSystem.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_EmployeeNumber1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeNumber1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber1",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber1",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeNumber1",
                table: "Employee",
                column: "EmployeeNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_EmployeeNumber1",
                table: "Employee",
                column: "EmployeeNumber1",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber");
        }
    }
}
