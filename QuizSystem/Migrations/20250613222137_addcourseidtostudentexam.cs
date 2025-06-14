using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Migrations
{
    /// <inheritdoc />
    public partial class addcourseidtostudentexam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourserId",
                table: "studentExams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourserId",
                table: "studentExams");
        }
    }
}
