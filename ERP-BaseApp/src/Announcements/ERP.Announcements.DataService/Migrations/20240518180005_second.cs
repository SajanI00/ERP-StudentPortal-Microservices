using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Announcements.DataService.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Announcements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Batch",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Announcements",
                type: "TEXT",
                nullable: true);
        }
    }
}
