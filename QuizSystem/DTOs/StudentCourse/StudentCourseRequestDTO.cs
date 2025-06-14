using QuizSystem.Models.Enums;

namespace QuizSystem.DTOs.StudentCourse
{
    public class StudentCourseRequestDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }
        public bool IsCompleted { get; set; }
        public enStudentCourseStatus Status { get; set; }
    }
}
