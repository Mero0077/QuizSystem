namespace QuizSystem.DTOs.Student
{
    public class StudentUpdateRequestDTO
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }

    }
}
