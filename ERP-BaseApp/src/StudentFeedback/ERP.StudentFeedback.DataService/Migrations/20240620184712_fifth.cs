using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_FeedbackGroup",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackGroupStudents");

            migrationBuilder.DropTable(
                name: "FeedbackGroups");

            migrationBuilder.RenameColumn(
                name: "FeedbackGroupId",
                table: "Feedbacks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_FeedbackGroupId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_StudentId");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackResponsesLecturerId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackResponsesModuleId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackResponsesSemesterId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeedbackResponses",
                columns: table => new
                {
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SemesterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LecturerName = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleName = table.Column<string>(type: "TEXT", nullable: false),
                    SemesterName = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackResponses", x => new { x.LecturerId, x.ModuleId, x.SemesterId });
                    table.ForeignKey(
                        name: "FK_FeedbackResponses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackResponses_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackResponses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks",
                columns: new[] { "FeedbackResponsesLecturerId", "FeedbackResponsesModuleId", "FeedbackResponsesSemesterId" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_ModuleId",
                table: "FeedbackResponses",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_SemesterId",
                table: "FeedbackResponses",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_FeedbackResponses_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks",
                columns: new[] { "FeedbackResponsesLecturerId", "FeedbackResponsesModuleId", "FeedbackResponsesSemesterId" },
                principalTable: "FeedbackResponses",
                principalColumns: new[] { "LecturerId", "ModuleId", "SemesterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Student",
                table: "Feedbacks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_FeedbackResponses_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Student",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackResponses");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackResponsesLecturerId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackResponsesModuleId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackResponsesSemesterId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Feedbacks",
                newName: "FeedbackGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_FeedbackGroupId");

            migrationBuilder.CreateTable(
                name: "FeedbackGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    StudentIds = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackGroups_Lecturer",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeedbackGroups_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeedbackGroupStudents",
                columns: table => new
                {
                    FeedbackGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackGroupStudents", x => new { x.FeedbackGroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_FeedbackGroupStudents_FeedbackGroups_FeedbackGroupId",
                        column: x => x.FeedbackGroupId,
                        principalTable: "FeedbackGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackGroupStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroupStudents_StudentId",
                table: "FeedbackGroupStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroups_LecturerId",
                table: "FeedbackGroups",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroups_StudentId",
                table: "FeedbackGroups",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_FeedbackGroup",
                table: "Feedbacks",
                column: "FeedbackGroupId",
                principalTable: "FeedbackGroups",
                principalColumn: "Id");
        }
    }
}
