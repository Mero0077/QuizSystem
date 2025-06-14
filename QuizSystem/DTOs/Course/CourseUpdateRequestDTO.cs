namespace QuizSystem.DTOs.Course
{
    public class CourseUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NumOfHours { get; set; }
        public int InstructorId { get; set; }
    }
}
