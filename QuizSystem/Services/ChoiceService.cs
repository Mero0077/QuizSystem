using QuizSystem.DTOs.Exams;
using QuizSystem.Models;
using QuizSystem.Repositories;
using QuizSystem.Models.ViewModels;
using QuizSystem.DTOs.Choice;
using AutoMapper;

namespace QuizSystem.Services
{
    public class ChoiceService
    {
        private GeneralRepository<Choice> _Choicerepository;
        private IMapper _mapper;

        public ChoiceService(IMapper mapper)
        {
            _Choicerepository = new GeneralRepository<Choice>();
            _mapper = mapper;
        }

        public List<Choice> GetAllChoices()
        {
            return _Choicerepository.GetAll().ToList();
        }
        public async Task<Choice> GetChoiceById(int id)
        {
            return await _Choicerepository.GetOneById(id);
        }

        public async Task<Choice> AddChoice(ChoiceRequestDTO choiceRequestDTO)
        {
            var choice = _mapper.Map<Choice>(choiceRequestDTO);
            var res=  await _Choicerepository.Add(choice);
            return res;
        }
        public async Task<Choice> UpdateChoice(ChoiceUpdateRequestDTO choiceUpdateRequestDTO)
        {

            var choice = _mapper.Map<Choice>(choiceUpdateRequestDTO);
           var res= await _Choicerepository.Update(choice);
            return res;
        }
        public async Task<Choice> DeleteChoice(int id)
        {
           return await _Choicerepository.Delete(id);
            
        }


    }
}
