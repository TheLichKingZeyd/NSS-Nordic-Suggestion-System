using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bacit_dotnet.MVC.Migrations
{
    public partial class DatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suggestions",
                table: "Suggestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Suggestions");

            migrationBuilder.RenameTable(
                name: "Suggestions",
                newName: "Suggestion");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "Team",
                table: "Comment",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Comment",
                newName: "CommentTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "SuggestionEntitySgstnID");

            migrationBuilder.RenameColumn(
                name: "Team",
                table: "Suggestion",
                newName: "ProbDescr");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suggestion",
                newName: "TeamEntityTeamID");

            migrationBuilder.AlterColumn<int>(
                name: "SuggestionEntitySgstnID",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeEntityEmployeeNumber",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SgstnID",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamEntityTeamID",
                table: "Suggestion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SgstnID",
                table: "Suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Deadline",
                table: "Suggestion",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeEntityEmployeeNumber",
                table: "Suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "Suggestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasMediaAttachments",
                table: "Suggestion",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasReasoning",
                table: "Suggestion",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "Progress",
                table: "Suggestion",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionTime",
                table: "Suggestion",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Suggestion",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<ushort>(
                name: "SgstnCount",
                table: "Employee",
                type: "smallint unsigned",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "AccountState",
                table: "Employee",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Employee",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Employee",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TeamEntityTeamID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suggestion",
                table: "Suggestion",
                column: "SgstnID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeNumber");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentLeader = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UploadTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeEntityEmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    UploadedFile = table.Column<byte[]>(type: "longblob", nullable: false),
                    SgstnID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SuggestionEntitySgstnID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaID);
                    table.ForeignKey(
                        name: "FK_Media_Employee_EmployeeEntityEmployeeNumber",
                        column: x => x.EmployeeEntityEmployeeNumber,
                        principalTable: "Employee",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Media_Suggestion_SuggestionEntitySgstnID",
                        column: x => x.SuggestionEntitySgstnID,
                        principalTable: "Suggestion",
                        principalColumn: "SgstnID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SgstnReason",
                columns: table => new
                {
                    ReasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReasonForDenial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgstnReason", x => x.ReasonID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamLeader = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamSgstnCount = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    DepartmentEntityDepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Department_DepartmentEntityDepartmentID",
                        column: x => x.DepartmentEntityDepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EmployeeEntityEmployeeNumber",
                table: "Comment",
                column: "EmployeeEntityEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SuggestionEntitySgstnID",
                table: "Comment",
                column: "SuggestionEntitySgstnID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_EmployeeEntityEmployeeNumber",
                table: "Suggestion",
                column: "EmployeeEntityEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_TeamEntityTeamID",
                table: "Suggestion",
                column: "TeamEntityTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TeamEntityTeamID",
                table: "Employee",
                column: "TeamEntityTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_EmployeeEntityEmployeeNumber",
                table: "Media",
                column: "EmployeeEntityEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Media_SuggestionEntitySgstnID",
                table: "Media",
                column: "SuggestionEntitySgstnID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_DepartmentEntityDepartmentID",
                table: "Team",
                column: "DepartmentEntityDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Employee_EmployeeEntityEmployeeNumber",
                table: "Comment",
                column: "EmployeeEntityEmployeeNumber",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Suggestion_SuggestionEntitySgstnID",
                table: "Comment",
                column: "SuggestionEntitySgstnID",
                principalTable: "Suggestion",
                principalColumn: "SgstnID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Team_TeamEntityTeamID",
                table: "Employee",
                column: "TeamEntityTeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestion_Employee_EmployeeEntityEmployeeNumber",
                table: "Suggestion",
                column: "EmployeeEntityEmployeeNumber",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestion_Team_TeamEntityTeamID",
                table: "Suggestion",
                column: "TeamEntityTeamID",
                principalTable: "Team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Employee_EmployeeEntityEmployeeNumber",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Suggestion_SuggestionEntitySgstnID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Team_TeamEntityTeamID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestion_Employee_EmployeeEntityEmployeeNumber",
                table: "Suggestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestion_Team_TeamEntityTeamID",
                table: "Suggestion");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "SgstnReason");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_EmployeeEntityEmployeeNumber",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_SuggestionEntitySgstnID",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suggestion",
                table: "Suggestion");

            migrationBuilder.DropIndex(
                name: "IX_Suggestion_EmployeeEntityEmployeeNumber",
                table: "Suggestion");

            migrationBuilder.DropIndex(
                name: "IX_Suggestion_TeamEntityTeamID",
                table: "Suggestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TeamEntityTeamID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "EmployeeEntityEmployeeNumber",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "SgstnID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "SgstnID",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "EmployeeEntityEmployeeNumber",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "HasMediaAttachments",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "HasReasoning",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "SubmissionTime",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Suggestion");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TeamEntityTeamID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Suggestion",
                newName: "Suggestions");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "SuggestionEntitySgstnID",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comment",
                newName: "Team");

            migrationBuilder.RenameColumn(
                name: "CommentTime",
                table: "Comment",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "TeamEntityTeamID",
                table: "Suggestions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProbDescr",
                table: "Suggestions",
                newName: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comment",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comment",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Comment",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Suggestions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Suggestions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Suggestions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SgstnCount",
                table: "Employees",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "AccountState",
                table: "Employees",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suggestions",
                table: "Suggestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeNumber");
        }
    }
}
