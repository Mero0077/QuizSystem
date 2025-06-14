namespace QuizSystem.Models.ViewModels.Question
{
    public class QuestionUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public enQuestionLevel QuestionLevel { get; set; }
    }
}
