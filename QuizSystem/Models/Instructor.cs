namespace QuizSystem.Models
{
    public class Instructor:Person
    {
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Title { get; set; }

        public ICollection<Course> TaughtCourses { get; set; }
        public ICollection<Exam> CreatedExams { get; set;}
    }
}
