namespace QuizSystem.DTOs.StudentAnswer
{
    public class StudentAnswerUpdateRequestDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public DateTime? AnsweredAt { get; set; }
    }
}
