using QuizSystem.Models.Enums;
namespace QuizSystem.Models
{

    public class Exam:BaseModel
    {
        public string Title { get; set; }        
        public string Description { get; set; }       
        public int NumberOfQuestions { get; set; }

        public int TotalMarks { get; set; }           
        public int DurationMinutes { get; set; }       

        public DateTime ScheduledDate { get; set; }
        public enExamType ExamType { get; set; }= enExamType.Quiz;


        public ICollection<StudentExam> StudentExams { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
