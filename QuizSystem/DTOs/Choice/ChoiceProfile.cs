using AutoMapper;
using QuizSystem.DTOs.Course;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Course;

namespace QuizSystem.DTOs.Choice
{
    public class ChoiceProfile:Profile
    {
        public ChoiceProfile()
        {
            CreateMap<ChoiceVM, ChoiceRequestDTO>();
            CreateMap<QuizSystem.Models.Choice, ChoiceVM>();
            CreateMap<ChoiceUpdateVM, ChoiceUpdateRequestDTO>();
            CreateMap<ChoiceRequestDTO, QuizSystem.Models.Choice>();
            CreateMap<ChoiceUpdateRequestDTO, QuizSystem.Models.Choice>();

         

        }
    }
}
