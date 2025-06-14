using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizSystem.DTOs.Instructor;
using QuizSystem.DTOs.StudentExam;
using QuizSystem.Models;
using QuizSystem.Models.Enums;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.Models.ViewModels.StudentExam;
using QuizSystem.Repositories;
using System.ComponentModel;
using System.Diagnostics;

namespace QuizSystem.Services
{
    public class StudentExamService
    {
        private GeneralRepository<StudentExam> _StudentExamRepository;
        private GeneralRepository<Student> _StudentRepository;
        private StudentCourseService _StudentCourseService;
        private GeneralRepository<Exam> _ExamRepository;
        private IMapper _mapper;
        public StudentExamService(IMapper mapper)

        {

            _StudentExamRepository = new GeneralRepository<StudentExam>();
            _StudentCourseService = new StudentCourseService(mapper);
        }

        public List<StudentExam> GetAllStudentExams()
        {
            return _StudentExamRepository.GetAll().ToList();
        }
        public async Task<StudentExam> GetStudentExamById(int id)
        {
            var res= await _StudentExamRepository.GetOne(e=>e.ExamId==id && e.StudentId==1 && e.SubmittedAt!=null);
            return res;
        }

        public async Task<List<StudentExamVM>> GetAllExamGrades(int examId)
        {
            var result = await _StudentExamRepository.Get(e => e.ExamId == examId).Select(e => new StudentExamVM
                {
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Grade = (double)e.Grade
            }).ToListAsync();

            return result;
        }

        public async Task<bool> AssignExamToStudent(AssignExamToStudentRequestDTO assignExamToStudentRequestDTO)
        {
            if (!await _StudentCourseService.IsStudentAlreadyEnrolled(assignExamToStudentRequestDTO.Studentid, assignExamToStudentRequestDTO.CourseId))
                return false;
            var studentexam = await _StudentExamRepository.GetOne(e => e.Id == assignExamToStudentRequestDTO.ExamId && e.CourserId == assignExamToStudentRequestDTO.CourseId);
            if (studentexam != null) return false;
            await _StudentExamRepository.Update(_mapper.Map<StudentExam>(assignExamToStudentRequestDTO));
            return true;


        }
        public async Task<bool> TakeQuiz([FromRoute] int Id)
        {
      
            var exam = await _ExamRepository.GetOneById(Id);
            if (exam == null) return false;
            var res = await _StudentExamRepository.GetOne(e=>e.ExamId==Id && e.StudentId==1);

            if  (res != null && res.SubmittedAt != null )  return false;

            if (await CheckExamType(exam))
            {

                var studentexam = new StudentExam
                {
                    StudentId = 1, // from jwt
                    ExamId = Id,
                    EntryDate = DateTime.Now,
                    IsPassed = false
                };

                await _StudentExamRepository.Add(studentexam);
                return true;
            }
            return false;
        }

        private async Task<bool> CheckExamType(Exam exam)
        {
            if(exam.ExamType==enExamType.FinalExam)
            {
                bool FinalExists = await _StudentExamRepository.Get(e =>e.StudentId == 1 &&e.CourserId == exam.CourseId &&
                                   e.Exam.ExamType == enExamType.FinalExam).AnyAsync();
                if (FinalExists) return false;

            }
            return true;
        }

        public async Task<bool> SubmitQuiz([FromRoute] int Id)
        {
            var studentexam = await _StudentExamRepository.GetOne(e => e.ExamId == Id && e.StudentId == 1);

            if (studentexam == null) return false;
            if (studentexam.SubmittedAt != null)
                //return BadRequest("You already submitted this quiz.");

                studentexam.SubmittedAt = DateTime.Now;
            await _StudentExamRepository.Update(studentexam);
            return true;
        }

       
    }
}
