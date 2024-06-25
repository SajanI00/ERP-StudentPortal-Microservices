using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackGroupStudent_FeedbackGroups_FeedbackGroupId",
                table: "FeedbackGroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackGroupStudent_Students_StudentId",
                table: "FeedbackGroupStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules");

            migrationBuilder.DropIndex(
                name: "IX_LecturersModules_LecturerId",
                table: "LecturersModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackGroupStudent",
                table: "FeedbackGroupStudent");

            migrationBuilder.RenameTable(
                name: "FeedbackGroupStudent",
                newName: "FeedbackGroupStudents");

            migrationBuilder.RenameIndex(
                name: "IX_FeedbackGroupStudent_StudentId",
                table: "FeedbackGroupStudents",
                newName: "IX_FeedbackGroupStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules",
                columns: new[] { "LecturerId", "ModuleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackGroupStudents",
                table: "FeedbackGroupStudents",
                columns: new[] { "FeedbackGroupId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackGroupStudents_FeedbackGroups_FeedbackGroupId",
                table: "FeedbackGroupStudents",
                column: "FeedbackGroupId",
                principalTable: "FeedbackGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackGroupStudents_Students_StudentId",
                table: "FeedbackGroupStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackGroupStudents_FeedbackGroups_FeedbackGroupId",
                table: "FeedbackGroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackGroupStudents_Students_StudentId",
                table: "FeedbackGroupStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackGroupStudents",
                table: "FeedbackGroupStudents");

            migrationBuilder.RenameTable(
                name: "FeedbackGroupStudents",
                newName: "FeedbackGroupStudent");

            migrationBuilder.RenameIndex(
                name: "IX_FeedbackGroupStudents_StudentId",
                table: "FeedbackGroupStudent",
                newName: "IX_FeedbackGroupStudent_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackGroupStudent",
                table: "FeedbackGroupStudent",
                columns: new[] { "FeedbackGroupId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_LecturersModules_LecturerId",
                table: "LecturersModules",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackGroupStudent_FeedbackGroups_FeedbackGroupId",
                table: "FeedbackGroupStudent",
                column: "FeedbackGroupId",
                principalTable: "FeedbackGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackGroupStudent_Students_StudentId",
                table: "FeedbackGroupStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
