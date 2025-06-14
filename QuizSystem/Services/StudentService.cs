using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.Student;
using QuizSystem.Models;
using QuizSystem.Repositories;

namespace QuizSystem.Services
{
    public class StudentService
    {
        private GeneralRepository<StudentExam> _StudentExamRepository;
        private GeneralRepository<Student> _StudentRepository;
        private IMapper _mapper;
        public StudentService(IMapper mapper)

        {
            _StudentExamRepository = new GeneralRepository<StudentExam>();
            _StudentRepository = new GeneralRepository<Student>();
            _mapper = mapper;
        }

        public async Task<Student> GetExamById(int id)
        {
            return await _StudentRepository.GetOneById(id);
        }


        [HttpGet("{ExamId}")]
        public async Task<StudentExam> GetResults(int ExamId)
        {
            var studentexam = await _StudentExamRepository.GetOne(e => e.ExamId == ExamId && e.StudentId == 1);

            return studentexam;

        }

        public List<Student> GetAllStudents()
        {
            return _StudentRepository.GetAll().ToList();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _StudentRepository.GetOneById(id);
        }

        public async Task<bool> AddStudent(StudentRequestDTO StudentRequestDTO)
        {
            var Student = _mapper.Map<Student>(StudentRequestDTO);
            await _StudentRepository.Add(Student);
            return true;
        }
        public async Task<bool> UpdateStudent(StudentUpdateRequestDTO StudentUpdateRequestDTO)
        {

            var Student = _mapper.Map<Student>(StudentUpdateRequestDTO);
            await _StudentRepository.Update(Student);
            return true;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            await _StudentRepository.Delete(id);
            return true;
        }
    }
}
