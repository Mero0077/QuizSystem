using AutoMapper;
using QuizSystem.Models.ViewModels.StudentAnswer;

namespace QuizSystem.DTOs.StudentAnswer
{
    public class StudentAsnwerProfile:Profile
    {
        public StudentAsnwerProfile()
        {
            CreateMap<StudentAnswerVM, StudentAnswerRequestDTO>();
            CreateMap<StudentAnswerUpdateVM, StudentAnswerRequestDTO>();
            CreateMap<StudentAnswerRequestDTO, QuizSystem.Models.StudentAnswer>();
            CreateMap<StudentAnswerRequestDTO, QuizSystem.Models.StudentAnswer>();
        }
    }
}
