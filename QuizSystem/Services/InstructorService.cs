using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.AssignExamToInstructor;
using QuizSystem.DTOs.Course;
using QuizSystem.DTOs.Instructor;
using QuizSystem.DTOs.StudentCourse;
using QuizSystem.Models;
using QuizSystem.Models.ViewModels.ExamInstructor;
using QuizSystem.Models.ViewModels.Instructor;
using QuizSystem.Repositories;

namespace QuizSystem.Services
{
    public class InstructorService
    {
        private GeneralRepository<Instructor> _InstructorRepository;
        private GeneralRepository<StudentCourse> _StudentCourseRepository;

        private GeneralRepository<Exam> _ExamRepository;
        private IMapper _mapper;

        public InstructorService(IMapper mapper)
        {
            _InstructorRepository = new GeneralRepository<Instructor>();
            _StudentCourseRepository= new GeneralRepository<StudentCourse>();
            _ExamRepository = new GeneralRepository<Exam>();
            _mapper = mapper;
        }


        public List<Instructor> GetAllInstructors()
        {
            return _InstructorRepository.GetAll().ToList();
        }
        public async Task<Instructor> GetInstructorById(int id)
        {
            return await _InstructorRepository.GetOneById(id);
        }

        public async Task<bool> AddInstructor(InstructorRequestDTO instructorRequestDTO)
        {
            var instructor = _mapper.Map<Instructor>(instructorRequestDTO);
            await _InstructorRepository.Add(instructor);
            return true;
        }
        public async Task<bool> UpdateInstructor(InstructorUpdateRequestDTO instructorRequestDTO)
        {

            var instructor = _mapper.Map<Instructor>(instructorRequestDTO);
            await _InstructorRepository.Update(instructor);
            return true;
        }
        public async Task<bool> DeleteInstructor(int id)
        {
            await _InstructorRepository.Delete(id);
            return true;
        }

       
        public async Task<bool> AssignExamToInstructor(AssignExamToInstructorDTO assignExamToInstructorDTO)
        {
           var Exam= await _ExamRepository.GetOneById(assignExamToInstructorDTO.ExamId);

            if (Exam!=null)
            {
                var instructor = await _InstructorRepository.GetOneById(assignExamToInstructorDTO.InstructorId);
                if(instructor==null) return false;

                Exam.InstructorId = instructor.Id;
               await _ExamRepository.Update(Exam);
                return true;
            }
          return false;
        }
    }
}
