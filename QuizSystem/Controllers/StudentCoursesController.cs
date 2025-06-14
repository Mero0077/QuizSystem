using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.StudentCourse;
using QuizSystem.Models.ViewModels.StudentCourse;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private StudentCourseService studentCourseService;
        private IMapper _mapper;
        public StudentCoursesController(IMapper mapper)
        {
            studentCourseService = new StudentCourseService(mapper);
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<bool> EnrollStudent([FromBody] StudentCourseVM studentCourse)
        {
            var Studentcourse = _mapper.Map<StudentCourseRequestDTO>(studentCourse);
            return await studentCourseService.EnrollStudent(Studentcourse);
        }

    }
}
