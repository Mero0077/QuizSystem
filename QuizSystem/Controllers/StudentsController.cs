using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.Choice;
using QuizSystem.DTOs.Student;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Student;
using QuizSystem.Repositories;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentService _studentService;
        private IMapper _mapper;
        public StudentsController(IMapper mapper)
        {
            _studentService = new StudentService(mapper);
            _mapper = mapper;
        }

        [HttpGet("All")]
        public List<Student> GetAll()
        {
            return _studentService.GetAllStudents().ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _studentService.GetStudentById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentVM Student)
        {
            var student = _mapper.Map<StudentRequestDTO>(Student);
            await _studentService.AddStudent(student);
            return Ok(student);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(StudentUpdateVM Student)
        {
            var student = _mapper.Map<StudentUpdateRequestDTO>(Student);
            await _studentService.UpdateStudent(student);
            return Ok(student);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }


    }
}
