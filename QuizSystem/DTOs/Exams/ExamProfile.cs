using AutoMapper;
using QuizSystem.DTOs.Course;
using QuizSystem.Models.ViewModels.Course;
using QuizSystem.Models.ViewModels.Exams;

namespace QuizSystem.DTOs.Exams
{
    public class ExamProfile:Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamVM, ExamRequestDTO>();
            CreateMap<ExamUpdateVM, ExamUpdateRequestDTO>();
            CreateMap<ExamRequestDTO, QuizSystem.Models.Exam>();
            CreateMap<ExamUpdateRequestDTO, QuizSystem.Models.Exam>();

        }
    }
}
