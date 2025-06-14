using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Models;
using QuizSystem.Repositories;
using QuizSystem.Services;
using QuizSystem.DTOs;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.DTOs.Exams;
using AutoMapper;
using QuizSystem.DTOs.Course;
using QuizSystem.Models.ViewModels.Course;
namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private ExamService _examService;
        private IMapper _mapper;

        public ExamsController(IMapper mapper)
        {
           _examService = new ExamService(mapper);
            _mapper = mapper;
        }

        [HttpGet("All")]
        public IList<Exam> GetAll()
        {
            return _examService.GetAllExams();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _examService.GetExamById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExamVM examVM)
        {
            var examrequest = _mapper.Map<ExamRequestDTO>(examVM);
            var res = await _examService.AddExam(examrequest);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ExamUpdateVM Exam)

        {
            var examrequest = _mapper.Map<ExamUpdateRequestDTO>(Exam);
            await _examService.UpdateExam(examrequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            await _examService.DeleteExam(Id);
            return Ok();
        }


        [HttpPost("{ExamId}")]
        public async Task<bool> EvaluateExam(int ExamId)
        {

           return await _examService.EvaluateExam(ExamId);
        }


    }
}
