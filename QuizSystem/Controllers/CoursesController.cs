using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredicateExtensions;
using QuizSystem.DTOs.Choice;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Course;
using QuizSystem.Repositories;
using QuizSystem.Services;
using System;
using System.Linq.Expressions;
using QuizSystem.DTOs;
using QuizSystem.DTOs.Course;
using AutoMapper;
using QuizSystem.Models.Enums;
using QuizSystem.Models.ViewModels.Error;
namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private CourseService _CourseService;
        private IMapper _Mapper;
        public CoursesController(IMapper mapper)
        {
            _CourseService = new CourseService(mapper);
            _Mapper = mapper;
        }

        [HttpGet("All")]
        public ResponseVM<IEnumerable<CourseVM>> GetAll()
        {
            var allCourss = _CourseService.GetAllCourses();
            var courseResponses = _Mapper.Map<IEnumerable<CourseVM>>(allCourss);
            return new SuccessResponseVM<IEnumerable<CourseVM>>(courseResponses);
        }

        [HttpGet("{id}")]
        public async Task<ResponseVM<CourseVM>> Get(int id)
        {
            var res = await _CourseService.GetCourseById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseVM course)
        {
            var Course = _Mapper.Map<CourseRequestDTO>(course);
            await _CourseService.AddCourse(Course);
            return Ok(Course);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(CourseUpdateVM course)
        {
            var Course = _Mapper.Map<CourseUpdateRequestDTO>(course);

            await _CourseService.UpdateCourse(Course);
            return Ok(Course);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _CourseService.DeleteCourse(id);
            return Ok();
        }

        //[HttpGet]
        //public IEnumerable<Course> Get(int? courseID, string? courseName, int? courseHours)
        //{
        //    var predicate = MyPredicateBuilder(courseID, courseName, courseHours);
        //    var query = _generalRepository.Get(predicate).ToList();
        //    return query;
        //}

        //private Expression<Func<Course, bool>> MyPredicateBuilder(int? courseID, string? courseName, int? courseHours)
        //{
        //    var Predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);
        //    if (courseID.HasValue)
        //    {
        //        Predicate = Predicate.And(c => c.Id == courseID);
        //    }
        //    if (courseHours.HasValue)
        //    {
        //        Predicate = Predicate.And(c => c.NumOfHours >= courseHours);
        //    }
        //    if (!string.IsNullOrEmpty(courseName))
        //    {
        //        Predicate = Predicate.And(c => c.Name == courseName);
        //    }
        //    return Predicate;
        //}


        //[HttpPut]
        //public IActionResult EditReflection(Course course)

        //{
        //    _generalRepository.UpdateReflection(course,nameof(course.Name), nameof(course.NumOfHours) ); // values changed only, so  i only update name and hrs
        //    return Ok();
        //}



    }
}
