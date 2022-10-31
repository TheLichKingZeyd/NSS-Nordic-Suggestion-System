using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bacit_dotnet.MVC.Migrations
{
    public partial class Suggestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "AccountPrivilege",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Suggestions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suggestions",
                newName: "Context");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Suggestions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Suggestions");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Suggestions",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Context",
                table: "Suggestions",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "Suggestions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AccountPrivilege",
                table: "Employees",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
