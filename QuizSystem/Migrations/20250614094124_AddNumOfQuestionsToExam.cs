using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNumOfQuestionsToExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinal",
                table: "studentExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfQuestions",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinal",
                table: "studentExams");

            migrationBuilder.DropColumn(
                name: "NumberOfQuestions",
                table: "Exams");
        }
    }
}
