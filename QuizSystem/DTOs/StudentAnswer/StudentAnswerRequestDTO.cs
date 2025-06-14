namespace QuizSystem.DTOs.StudentAnswer
{
    public class StudentAnswerRequestDTO
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public DateTime? AnsweredAt { get; set; }
    }
}
