using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentRequests.DataService.Migrations
{
    /// <inheritdoc />
    public partial class addedsenderName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Replies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Replies");
        }
    }
}
