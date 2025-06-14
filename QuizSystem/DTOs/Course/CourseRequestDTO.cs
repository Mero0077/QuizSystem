namespace QuizSystem.DTOs.Course
{
    public class CourseRequestDTO
    {
        public string Name { get; set; }
        public decimal NumOfHours { get; set; }
        public int InstructorId { get; set; }
    }
}
