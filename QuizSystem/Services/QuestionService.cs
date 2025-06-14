using AutoMapper;
using QuizSystem.DTOs.Choice;
using QuizSystem.DTOs.Question;
using QuizSystem.Models;
using QuizSystem.Repositories;

namespace QuizSystem.Services
{
    public class QuestionService
    {
        private GeneralRepository<Question> _questionsRepository;
        private IMapper _mapper;
        public QuestionService(IMapper mapper)
        {
            _questionsRepository = new GeneralRepository<Question>();
            _mapper = mapper;
        }
        public List<Question> GetAllQuestions()
        {
            return _questionsRepository.GetAll().ToList();
        }
        public async Task<Question> GetQuestionById(int id)
        {
            return await _questionsRepository.GetOneById(id);
        }

        public async Task<bool> AddQuestion(QuestionRequestDTO questionRequestDTO)
        {
            var question = _mapper.Map<Question>(questionRequestDTO);
            await _questionsRepository.Add(question);
            return true;
        }
        public async Task<bool> UpdateQuestion(QuestionUpdateRequestDTO questionRequestDTO)
        {

            var question = _mapper.Map<Question>(questionRequestDTO);
            await _questionsRepository.Update(question);
            return true;
        }
        public async Task<bool> DeleteQuestion(int id)
        {
            await _questionsRepository.Delete(id);
            return true;
        }
    }
}
