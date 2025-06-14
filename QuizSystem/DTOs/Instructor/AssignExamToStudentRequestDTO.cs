namespace QuizSystem.DTOs.Instructor
{
    public class AssignExamToStudentRequestDTO
    {
        public int ExamId { get; set; }
        public int Studentid { get; set; }
        public int CourseId { get; set; }
        public double? Grade { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public bool IsPassed { get; set; }
        public bool IsFinal { get; set; }
    }
}
