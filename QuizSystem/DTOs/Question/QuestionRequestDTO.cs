using QuizSystem.Models;

namespace QuizSystem.DTOs.Question
{
    public class QuestionRequestDTO
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public enQuestionLevel QuestionLevel { get; set; }
    }
}
