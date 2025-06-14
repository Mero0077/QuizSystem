namespace QuizSystem.Models
{

    public enum enQuestionLevel
    {
        Easy,Medium,Hard
    }
    public class Question:BaseModel
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Description { get; set; }
        public enQuestionLevel QuestionLevel { get; set; }= enQuestionLevel.Easy;
        public Guid RandomKey { get; set; } = Guid.NewGuid();

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }

    }
}
