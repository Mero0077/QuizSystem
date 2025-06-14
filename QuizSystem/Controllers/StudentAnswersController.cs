using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.StudentAnswer;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.StudentAnswer;
using QuizSystem.Repositories;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswersController : ControllerBase
    {
        private StudentAnswerService _studentAnswerService;
        private IMapper _mapper;

        public StudentAnswersController(IMapper mapper)
        {
            _studentAnswerService = new StudentAnswerService(mapper);
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> StoreStudentAnswers(StudentAnswerVM studentAnswer)
        {
            var res= _mapper.Map<StudentAnswerRequestDTO>(studentAnswer);
            await _studentAnswerService.StoreStudentAnswers(res);
            return Ok(studentAnswer);
        }
    }
}
