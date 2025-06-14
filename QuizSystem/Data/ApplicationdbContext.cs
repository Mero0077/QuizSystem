using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizSystem.Models;
using System.Diagnostics;

namespace QuizSystem.Data
{
    public class ApplicationdbContext:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<StudentExam > studentExams { get; set; }
        public DbSet<StudentAnswer> studentAnswers { get; set; }
        public DbSet<PrerequisiteCourse> prerequisiteCourses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ExamSystemDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
                 .LogTo(log => Debug.WriteLine(log), LogLevel.Information).EnableSensitiveDataLogging(true).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


    }
}
