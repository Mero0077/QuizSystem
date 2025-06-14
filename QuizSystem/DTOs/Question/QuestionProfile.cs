using AutoMapper;
using QuizSystem.Models.ViewModels.Question;

namespace QuizSystem.DTOs.Question
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionVM,QuestionRequestDTO>();
            CreateMap<QuestionUpdateVM,QuestionUpdateRequestDTO>();
            CreateMap<QuestionRequestDTO, QuizSystem.Models.Question>();
            CreateMap<QuestionUpdateRequestDTO, QuizSystem.Models.Question>();
        }
    }
}
