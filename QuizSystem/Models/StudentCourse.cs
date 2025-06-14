using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using QuizSystem.Models.Enums;

namespace QuizSystem.Models
{
   
    public class StudentCourse:BaseModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Student Student { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; } 
        public bool IsCompleted { get; set; }
        public enStudentCourseStatus Status { get; set; }
    }
}
