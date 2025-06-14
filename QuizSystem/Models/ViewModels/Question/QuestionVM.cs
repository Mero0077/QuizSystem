namespace QuizSystem.Models.ViewModels.Question
{
    public class QuestionVM
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public enQuestionLevel QuestionLevel { get; set; }
    }
}
