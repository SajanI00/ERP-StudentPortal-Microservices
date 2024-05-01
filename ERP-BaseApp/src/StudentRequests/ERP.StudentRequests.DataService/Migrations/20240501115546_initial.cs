using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentRequests.DataService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    Batch = table.Column<string>(type: "TEXT", nullable: false),
                    Degree = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    RequestType = table.Column<string>(type: "TEXT", nullable: false),
                    LecturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentRegNo = table.Column<string>(type: "TEXT", nullable: false),
                    StudentBatch = table.Column<string>(type: "TEXT", nullable: false),
                    StudentDegree = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LecturerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Lecturer",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Student",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LecturerId",
                table: "Requests",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
