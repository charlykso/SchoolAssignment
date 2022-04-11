using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.Migrations
{
    public partial class added_lecturer_assignment_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentsId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Students_StudentsId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CourseTitle",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "Submissions",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "AssignmentsId",
                table: "Submissions",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_StudentsId",
                table: "Submissions",
                newName: "IX_Submissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_AssignmentsId",
                table: "Submissions",
                newName: "IX_Submissions_AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Students_StudentId",
                table: "Submissions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Students_StudentId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Submissions",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Submissions",
                newName: "AssignmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_StudentId",
                table: "Submissions",
                newName: "IX_Submissions_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_AssignmentId",
                table: "Submissions",
                newName: "IX_Submissions_AssignmentsId");

            // migrationBuilder.AddColumn<string>(
            //     name: "DueDate",
            //     table: "Submissions",
            //     type: "nvarchar(10)",
            //     maxLength: 10,
            //     nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Assignments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseTitle",
                table: "Assignments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
    }
}
