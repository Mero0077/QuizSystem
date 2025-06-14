using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizSystem.Models
{
    public class Course:BaseModel
    {
        public string Name { get; set; }
        public decimal NumOfHours { get; set; }


        [JsonIgnore]
        [ValidateNever]
        public ICollection<StudentCourse> StudentCourses { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ICollection<Exam> Exams { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

        [InverseProperty(nameof(PrerequisiteCourse.MainCourse))]
        public ICollection<PrerequisiteCourse> Prerequisites { get; set; } 

        [InverseProperty(nameof(PrerequisiteCourse.prerequisiteCourse))]
        public ICollection<PrerequisiteCourse> IsPrerequisiteFor { get; set; } 

     
    }
}