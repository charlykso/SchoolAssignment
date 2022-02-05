using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.Migrations
{
    public partial class addingrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AssingmentFileUrl",
                table: "Submissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentsId",
                table: "Submissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Submissions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssignmentsId",
                table: "Submissions",
                column: "AssignmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentsId",
                table: "Submissions",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_LecturerId",
                table: "Assignments",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Lecturers_LecturerId",
                table: "Assignments",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Assignments_AssignmentsId",
                table: "Submissions",
                column: "AssignmentsId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Students_StudentsId",
                table: "Submissions",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Lecturers_LecturerId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentsId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Students_StudentsId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_AssignmentsId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_StudentsId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_LecturerId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentsId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "AssingmentFileUrl",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
