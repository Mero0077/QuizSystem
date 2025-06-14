using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.StudentCourse;
using QuizSystem.Models;
using QuizSystem.Repositories;

namespace QuizSystem.Services
{
    public class StudentCourseService
    {
        private GeneralRepository<StudentCourse> _StudentCourseRepository;
        private IMapper _mapper;
        public StudentCourseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<bool> EnrollStudent(StudentCourseRequestDTO studentCourse)
        {
            if (studentCourse == null) return false;
            if(await IsStudentAlreadyEnrolled(studentCourse.StudentId,studentCourse.CourseId)) return false;

            var Studentcourse = _mapper.Map<StudentCourse>(studentCourse);

            await _StudentCourseRepository.Add(Studentcourse);
            return true;
        }

        public async Task<bool> IsStudentAlreadyEnrolled(int studentId, int CourseId)
        {
            var res = await _StudentCourseRepository.GetOne(e => e.StudentId == studentId && e.CourseId == CourseId) ;
            return res==null ? true : false;
           
        }
    }
}
