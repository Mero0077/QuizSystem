using QuizSystem.Models.Enums;

namespace QuizSystem.Models.ViewModels.Exams
{
    public class ExamUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Description { get; set; }

        public int TotalMarks { get; set; }
        public int DurationMinutes { get; set; }

        public DateTime ScheduledDate { get; set; }
        public enExamType ExamType { get; set; } = enExamType.Quiz;
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public List<int> QuestionIds { get; set; }
 
    }
}
