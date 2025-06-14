using System.Numerics;

namespace QuizSystem.Models
{
    public class PrerequisiteCourse:BaseModel
    {
        public int MainCourseId { get; set; }
        public Course MainCourse { get; set; }

        public int PrerequisiteCourseId { get; set; }
        public Course prerequisiteCourse { get; set; }
    }

}
