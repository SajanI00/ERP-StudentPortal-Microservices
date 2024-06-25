using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LecturerIds",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "LecturerIds",
                table: "Modules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LecturerIds",
                table: "Semesters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LecturerIds",
                table: "Modules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
