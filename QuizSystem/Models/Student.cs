namespace QuizSystem.Models
{
    public class Student:Person
    {
        public string StudentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentExam> StudentExams { get; set; }
    }
}
