using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.StudentAnswer;
using QuizSystem.Models;
using QuizSystem.Repositories;

namespace QuizSystem.Services
{
    public class StudentAnswerService
    {
        private GeneralRepository<StudentAnswer> _studentAnswerRepository;
        private IMapper _mapper;

        public StudentAnswerService(IMapper mapper)
        {
            _studentAnswerRepository = new GeneralRepository<StudentAnswer>();
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<bool> StoreStudentAnswers(StudentAnswerRequestDTO studentAnswer)
        {
            studentAnswer.AnsweredAt = DateTime.Now;
            var res= _mapper.Map<StudentAnswer>(studentAnswer);
            await _studentAnswerRepository.Add(res);
            return true;
        }
    }
}
