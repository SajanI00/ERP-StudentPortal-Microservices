using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RegNo = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleName = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerIds = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SemesterName = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerIds = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeedbackGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentIds = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "LecturersModules",
                columns: table => new
                {
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturersModules", x => new { x.LecturerId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_LecturersModules_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturersModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturersSemesters",
                columns: table => new
                {
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SemesterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturersSemesters", x => new { x.LecturerId, x.SemesterId });
                    table.ForeignKey(
                        name: "FK_LecturersSemesters_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturersSemesters_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackGroupStudent",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FeedbackGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackGroupStudent", x => new { x.FeedbackGroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_FeedbackGroupStudent_FeedbackGroups_FeedbackGroupId",
                        column: x => x.FeedbackGroupId,
                        principalTable: "FeedbackGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackGroupStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleName = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerName = table.Column<string>(type: "TEXT", nullable: false),
                    SemesterName = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    OverallFeedback = table.Column<string>(type: "TEXT", nullable: false),
                    LectureContentRating = table.Column<int>(type: "INTEGER", nullable: false),
                    LectureEngagementRating = table.Column<int>(type: "INTEGER", nullable: false),
                    CommunicationRating = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamplesRating = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverageRating = table.Column<int>(type: "INTEGER", nullable: false),
                    PaceRating = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipationRating = table.Column<int>(type: "INTEGER", nullable: false),
                    VisualAidsRating = table.Column<int>(type: "INTEGER", nullable: false),
                    RealWorldApplicationsRating = table.Column<int>(type: "INTEGER", nullable: false),
                    ConceptRating = table.Column<int>(type: "INTEGER", nullable: false),
                    LectureOrganizationRating = table.Column<int>(type: "INTEGER", nullable: false),
                    InteractionRating = table.Column<int>(type: "INTEGER", nullable: false),
                    ExplanationClarityRating = table.Column<int>(type: "INTEGER", nullable: false),
                    SummaryEffectivenessRating = table.Column<int>(type: "INTEGER", nullable: false),
                    RelevanceToCourseRating = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SemesterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackGroup",
                        column: x => x.FeedbackGroupId,
                        principalTable: "FeedbackGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Lecturer",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroupStudent_StudentId",
                table: "FeedbackGroupStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroups_LecturerId",
                table: "FeedbackGroups",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackGroups_StudentId",
                table: "FeedbackGroups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackGroupId",
                table: "Feedbacks",
                column: "FeedbackGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LecturerId",
                table: "Feedbacks",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ModuleId",
                table: "Feedbacks",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SemesterId",
                table: "Feedbacks",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturersModules_ModuleId",
                table: "LecturersModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturersSemesters_SemesterId",
                table: "LecturersSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LecturerId",
                table: "Modules",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_LecturerId",
                table: "Semesters",
                column: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackGroupStudent");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LecturersModules");

            migrationBuilder.DropTable(
                name: "LecturersSemesters");

            migrationBuilder.DropTable(
                name: "FeedbackGroups");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lecturers");
        }
    }
}
