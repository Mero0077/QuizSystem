using AutoMapper;
using QuizSystem.DTOs.Exams;
using QuizSystem.DTOs.Question;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.Models.ViewModels.Question;
using QuizSystem.Models.ViewModels.StudentCourse;

namespace QuizSystem.DTOs.StudentCourse
{
    public class StudentCourseProfile : Profile
    {
        public StudentCourseProfile()
        {
            CreateMap<StudentCourseVM, StudentCourseRequestDTO>();
            CreateMap<StudentCourseRequestDTO, Models.StudentCourse>();
        }
    }
}
