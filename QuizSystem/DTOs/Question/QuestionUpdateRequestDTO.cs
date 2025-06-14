using QuizSystem.Models;

namespace QuizSystem.DTOs.Question
{
    public class QuestionUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public enQuestionLevel QuestionLevel { get; set; }
    }
}
