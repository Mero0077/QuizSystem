using AutoMapper;
using QuizSystem.DTOs.Exams;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.Models.ViewModels.Instructor;

namespace QuizSystem.DTOs.Instructor
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {
            CreateMap<InstructorVM, InstructorRequestDTO>();
            CreateMap<InstructorUpdateVM, InstructorUpdateRequestDTO>();
            CreateMap<InstructorRequestDTO, QuizSystem.Models.Instructor>();
            CreateMap<InstructorUpdateRequestDTO, QuizSystem.Models.Instructor>();
            CreateMap<AssignExamToStudentVM,AssignExamToStudentRequestDTO >();
            CreateMap<AssignExamToStudentRequestDTO, QuizSystem.Models.StudentExam >();

        }
    }
}
