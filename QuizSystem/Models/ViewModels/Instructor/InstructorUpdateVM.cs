namespace QuizSystem.Models.ViewModels.Instructor
{
    public class InstructorUpdateVM
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Title { get; set; }

    }
}
