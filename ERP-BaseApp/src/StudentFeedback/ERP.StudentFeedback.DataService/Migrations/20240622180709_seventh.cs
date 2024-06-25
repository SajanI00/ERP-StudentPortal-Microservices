using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Lecturers_LecturerId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Lecturers_LecturerId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_LecturerId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Modules_LecturerId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Modules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LecturerId",
                table: "Semesters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LecturerId",
                table: "Modules",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_LecturerId",
                table: "Semesters",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LecturerId",
                table: "Modules",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Lecturers_LecturerId",
                table: "Modules",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Lecturers_LecturerId",
                table: "Semesters",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id");
        }
    }
}
