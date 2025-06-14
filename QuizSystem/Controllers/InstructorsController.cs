using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.StudentCourse;
using QuizSystem.Repositories;
using QuizSystem.Services;
using QuizSystem.DTOs;
using QuizSystem.DTOs.StudentCourse;
using QuizSystem.DTOs.Choice;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Instructor;
using QuizSystem.DTOs.Instructor;
using QuizSystem.Models.ViewModels.ExamInstructor;
using QuizSystem.DTOs;
using QuizSystem.DTOs.AssignExamToInstructor;
using AutoMapper;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private InstructorService _instructorService;
        private StudentCourseService _studentCourseService;
        private IMapper _mapper;
        public InstructorsController(IMapper mapper)
        {
            _instructorService = new InstructorService(mapper);
            _studentCourseService = new StudentCourseService(mapper);
            _mapper = mapper;
        }
        [HttpGet("All")]
        public IList<Instructor> GetAll()
        {
            return _instructorService.GetAllInstructors().ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _instructorService.GetInstructorById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstructorVM instructorVM)
        {
            var instructor = _mapper.Map<InstructorRequestDTO>(instructorVM);
            await _instructorService.AddInstructor(instructor);
            return Ok(instructor);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(InstructorUpdateVM instructorUpdateVM)
        {
            var instructor = _mapper.Map<InstructorUpdateRequestDTO>(instructorUpdateVM);
            await _instructorService.UpdateInstructor(instructor);
            return Ok(instructor);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorService.DeleteInstructor(id);
            return Ok();
        }

    
      
        [HttpPost]
        public async Task AssignExamToInstructor(AssignExamToInstructorVM assignExamToInstructorVM)
        {
            var exam = new AssignExamToInstructorDTO()
            {
                ExamId = assignExamToInstructorVM.ExamId,
                InstructorId = assignExamToInstructorVM.InstructorId
            };
           await _instructorService.AssignExamToInstructor(exam);
        }
    }
}
