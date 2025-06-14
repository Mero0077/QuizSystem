namespace QuizSystem.Models
{
    public class Choice:BaseModel
    {
        public string Description { get; set; }
        public bool IsTheRightAnswer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
