using Microsoft.EntityFrameworkCore;

namespace QuizSystem.Models
{
    public class StudentExam:BaseModel
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int CourserId { get; set; }
        public Student Student { get; set; } 
        public Exam Exam { get; set; }
        public double? Grade { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? SubmittedAt { get; set; } 
        public bool IsPassed { get; set; }
        public bool IsFinal { get; set; }
    }
}
