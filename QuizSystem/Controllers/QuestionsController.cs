using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.Question;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Question;
using QuizSystem.Repositories;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private QuestionService _questionService;
        private IMapper _mapper;

        public QuestionsController(IMapper mapper)
        {
            _questionService = new QuestionService(mapper);
            _mapper = mapper;
        }


        [HttpGet("All")]
        public IList<Question> GetAll()
        {
            return _questionService.GetAllQuestions();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _questionService.GetQuestionById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuestionVM question)
        {
            var Question = _mapper.Map<QuestionRequestDTO>(question);

           await _questionService.AddQuestion(Question);
            return Ok(question);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(QuestionUpdateVM question)
        {
            var Question = _mapper.Map<QuestionUpdateRequestDTO>(question);
            await _questionService.UpdateQuestion(Question);
            return Ok(question);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _questionService.DeleteQuestion(id);
            return Ok();
        }
    }
}
