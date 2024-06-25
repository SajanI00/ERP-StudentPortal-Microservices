using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LecturersModules_LecturerId",
                table: "LecturersModules",
                column: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules");

            migrationBuilder.DropIndex(
                name: "IX_LecturersModules_LecturerId",
                table: "LecturersModules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturersModules",
                table: "LecturersModules",
                columns: new[] { "LecturerId", "ModuleId" });
        }
    }
}
