using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.SiteHome.DataService.Migrations
{
    /// <inheritdoc />
    public partial class semesters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semester_Department",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Semesters",
                newName: "BatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_DepartmentId",
                table: "Semesters",
                newName: "IX_Semesters_BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_Batch",
                table: "Semesters",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semester_Batch",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "Semesters",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_BatchId",
                table: "Semesters",
                newName: "IX_Semesters_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_Department",
                table: "Semesters",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
