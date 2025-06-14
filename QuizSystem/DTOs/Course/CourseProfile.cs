using AutoMapper;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Course;

namespace QuizSystem.DTOs.Course
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
        CreateMap<CourseVM,CourseRequestDTO>();
        CreateMap<CourseUpdateVM,CourseUpdateRequestDTO>();
        CreateMap<CourseRequestDTO, QuizSystem.Models.Course>();
        CreateMap<CourseUpdateRequestDTO, QuizSystem.Models.Course>();
        CreateMap<QuizSystem.Models.Course,CourseVM>();
        }
    }
}
