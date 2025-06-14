using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.Instructor;
using QuizSystem.DTOs.StudentExam;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.Models.ViewModels.Instructor;
using QuizSystem.Models.ViewModels.StudentExam;
using QuizSystem.Repositories;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamsController : ControllerBase
    {
        private StudentExamService _studentExamService;
        private IMapper _mapper;

        public StudentExamsController(IMapper mapper)
        {
            _mapper = mapper;
            
            _studentExamService = new StudentExamService(mapper);
        }

        [HttpGet]
        public List<StudentExam> GetAllStudentExams()
        {
            return _studentExamService.GetAllStudentExams().ToList();
        }

        [HttpGet("{id}")]
        public async Task<StudentExam> GetExamById(int id)
        {
            return await _studentExamService.GetStudentExamById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AssignExamTostudent(AssignExamToStudentVM assignExamToStudentVM)
        {

            var assignexam = _mapper.Map<AssignExamToStudentRequestDTO>(assignExamToStudentVM);
            await _studentExamService.AssignExamToStudent(assignexam);
            return Ok();
        }


        [HttpPost("{Id}")]
        public async Task<IActionResult> TakeQuiz([FromRoute] int Id)
        {

            await _studentExamService.TakeQuiz(Id);
            return Ok();
        }


        [HttpPost("{Id}")]
        public async Task<IActionResult> SubmitQuiz([FromRoute] int Id)
        {
            await _studentExamService.SubmitQuiz(Id);
            return Ok();
        }

        [HttpGet("{ExamId}")]
        public async Task<ActionResult<List<StudentExamVM>>> GetAllExamGrades(int ExamId)
        {

            var result = await _studentExamService.GetAllExamGrades(ExamId);
            return Ok(result);

        }

        [HttpGet("{ExamId}")]
        public async Task<StudentExam> GetStudentResults(int ExamId)
        {
            return await _studentExamService.GetStudentExamById(ExamId);

        }
    }
}
