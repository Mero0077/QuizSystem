using AutoMapper;
using PredicateExtensions;
using QuizSystem.DTOs.Course;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.Course;
using QuizSystem.Repositories;
using System.Linq.Expressions;

namespace QuizSystem.Services
{
    public class CourseService
    {
        private GeneralRepository<Course> _Courserepository;
        private IMapper _mapper;

        public CourseService(IMapper mapper)
        {
            _Courserepository = new GeneralRepository<Course>();
            _mapper = mapper;
        }

        public List<Course> GetAllCourses()
        {
            return _Courserepository.GetAll().ToList();
        }
        public async Task<Course> GetCourseById(int id)
        {
            return await _Courserepository.GetOneById(id);
        }

        public async Task<bool> AddCourse(CourseRequestDTO CourseRequestDTO)
        {
            var Course = _mapper.Map<Course>(CourseRequestDTO);
            await _Courserepository.Add(Course);
            return true;
        }
        public async Task<bool> UpdateCourse(CourseUpdateRequestDTO CourseUpdateRequestDTO)
        {
            var Course = _mapper.Map<Course>(CourseUpdateRequestDTO);
            await _Courserepository.Update(Course);
            return true;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            await _Courserepository.Delete(id);
            return true;
        }

        private Expression<Func<Course, bool>> MyPredicateBuilder(int? courseID, string? courseName, int? courseHours)
        {
            var Predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);
            if (courseID.HasValue)
            {
                Predicate = Predicate.And(c => c.Id == courseID);
            }
            if (courseHours.HasValue)
            {
                Predicate = Predicate.And(c => c.NumOfHours >= courseHours);
            }
            if (!string.IsNullOrEmpty(courseName))
            {
                Predicate = Predicate.And(c => c.Name == courseName);
            }
            return Predicate;
        }

    }
}
