using AutoMapper;
using QuizSystem.DTOs.StudentCourse;
using QuizSystem.Models.ViewModels.StudentCourse;
using QuizSystem.Models.ViewModels.StudentExam;

namespace QuizSystem.DTOs.StudentExam
{
    public class StudentExamProfile:Profile
    {
        public StudentExamProfile()
        {
            CreateMap<StudentExamVM, GetStudentExamGradesRequestDTO>();
            CreateMap<GetStudentExamGradesRequestDTO, StudentExamVM>();
        }
    }
}
