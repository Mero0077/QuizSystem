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
            if (res == null)
                return new FailureResponseVM<CourseVM>(ErrorCode.CourseNotFound, "Course does not exist!");
            var coursevm = _Mapper.Map<CourseVM>(res);
            return new SuccessResponseVM<CourseVM>(coursevm, "Course retrieved successfully");
        }

        [HttpPost]
        public async Task<ResponseVM<CourseVM>> Add(CourseVM course)
        {
            var Course = _Mapper.Map<CourseRequestDTO>(course);
            var addedCourse=  await _CourseService.AddCourse(Course);
            var coursevm = _Mapper.Map<CourseVM>(addedCourse);
            return new SuccessResponseVM<CourseVM>(coursevm, "Course added successfully");
        }

        [HttpPatch]
        public async Task<ResponseVM<CourseUpdateVM>> Edit(CourseUpdateVM course)
        {
            var Course = _Mapper.Map<CourseUpdateRequestDTO>(course);

           var addedCourse= await _CourseService.UpdateCourse(Course);
            var coursevm = _Mapper.Map<CourseUpdateVM>(addedCourse);
            return new SuccessResponseVM<CourseUpdateVM>(coursevm, "Choice added successfully");
        }


        [HttpDelete]
        public async Task<ResponseVM<CourseVM>> Delete(int id)
        {
            var entity = await _CourseService.DeleteCourse(id);

            if (entity == null)
                return new FailureResponseVM<CourseVM>(ErrorCode.CourseNotFound, "Course not found");

            var vm = _Mapper.Map<CourseVM>(entity);
            return new SuccessResponseVM<CourseVM>(vm, "Course deleted successfully");
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
