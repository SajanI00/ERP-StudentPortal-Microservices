using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.StudentFeedback.DataService.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_FeedbackResponses_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks",
                columns: new[] { "FeedbackResponsesLecturerId", "FeedbackResponsesModuleId", "FeedbackResponsesSemesterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_FeedbackResponses_FeedbackResponsesLecturerId_FeedbackResponsesModuleId_FeedbackResponsesSemesterId",
                table: "Feedbacks",
                columns: new[] { "FeedbackResponsesLecturerId", "FeedbackResponsesModuleId", "FeedbackResponsesSemesterId" },
                principalTable: "FeedbackResponses",
                principalColumns: new[] { "LecturerId", "ModuleId", "SemesterId" });
        }
    }
}
