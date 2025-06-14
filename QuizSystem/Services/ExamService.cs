using Microsoft.AspNetCore.Mvc;
using QuizSystem.Models;
using QuizSystem.Repositories;
using QuizSystem.DTOs.Exams;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace QuizSystem.Services
{
    public class ExamService
    {
        private GeneralRepository<Exam> _generalrepository;
        private GeneralRepository<StudentAnswer> _studentAnswerRepository;
        private GeneralRepository<Question> _questionRepository;
        private GeneralRepository<StudentExam> _studentExamRepository;
        private IMapper _mapper;

        public ExamService(IMapper mapper)
        {
            _generalrepository = new GeneralRepository<Exam>();
            _studentAnswerRepository = new GeneralRepository<StudentAnswer>();
            _questionRepository= new GeneralRepository<Question>();
            _studentExamRepository = new GeneralRepository<StudentExam>();
            _mapper = mapper;
        }
        public  List<Exam> GetAllExams()
        {
            return _generalrepository.GetAll().ToList();
        }
        public async Task<Exam> GetExamById(int id)
        {
            return await _generalrepository.GetOneById(id);
        }
        public async Task<bool> AddExam(ExamRequestDTO examRequestDTO)
        {
            var exam= _mapper.Map<Exam>(examRequestDTO);
            if (!examRequestDTO.AssignQuestionsAutomatically)
            {
                exam.ExamQuestions = examRequestDTO.QuestionIds.Select(id => new ExamQuestion
                {
                    QuestionId = id
                }).ToList();

            }
            else
            {
                var easy = await GetRandomQuestions(enQuestionLevel.Easy, 5);
                var medium = await GetRandomQuestions(enQuestionLevel.Medium, 3);
                var hard = await GetRandomQuestions(enQuestionLevel.Hard, 2);

                exam.ExamQuestions = new List<ExamQuestion>();
                foreach (var question in easy)
                {
                    exam.ExamQuestions.Add(new ExamQuestion { QuestionId = question.Id });
                }
          
                foreach (var question in medium)
                {
                    exam.ExamQuestions.Add(new ExamQuestion { QuestionId = question.Id });
                }

                foreach (var question in hard)
                {
                    exam.ExamQuestions.Add(new ExamQuestion { QuestionId = question.Id });
                }

            }
             await _generalrepository.Add(exam);
            return true;
        }

        private async Task<List<Question>> GetRandomQuestions(enQuestionLevel questionLevel,int count)
        {
             var allquestions= await _questionRepository.Get(e=>e.QuestionLevel==questionLevel).OrderBy(e=>e.RandomKey).Take(count).ToListAsync();
            return allquestions;
             
        }
        public async Task<bool> UpdateExam(ExamUpdateRequestDTO examUpdateRequest)
        {
            var exam = _mapper.Map<Exam>(examUpdateRequest);
            await _generalrepository.Update(exam);
            return true;
        }
        public async Task<bool> DeleteExam(int id)
        {
          await  _generalrepository.Delete(id);
            return true;
        }

        public async Task<bool> EvaluateExam(int ExamId)
        {

            var studentexam = await _studentExamRepository.GetOne(e => e.ExamId == ExamId && e.StudentId == 1);
            if (studentexam == null || studentexam.SubmittedAt == null || studentexam.EntryDate == null) return false;


            //var correctanswers=  _studentAnswerRepository.GetAllExpression(sa => sa.ExamId == ExamId && sa.StudentId == 1 && sa.Choice.IsTheRightAnswer).
            //Include(e => e.Choice);
            var correctanswers = _studentAnswerRepository.Get(sa => sa.ExamId == ExamId && sa.StudentId == 1).Select(e => new
            {
                e.ExamId,
                e.StudentId,
                e.QuestionId,
                QuestionGrade = e.Question.Grade,
                rigtans = e.Choice.IsTheRightAnswer,
            });

            decimal TotalGrade = 0;

            

            foreach (var studentanswer in correctanswers)
            {

                if (studentanswer.rigtans)
                {
                    TotalGrade += studentanswer.QuestionGrade;
                }
            }
            var temp = await _generalrepository.GetOneById(ExamId);
            var examgrade = temp.TotalMarks;
            if (TotalGrade >= examgrade / 2)
            {
                studentexam.IsPassed = true;
            }
            studentexam.Grade = Convert.ToDouble(TotalGrade);
            await _studentExamRepository.Update(studentexam);

            return true;
        }

    }
}
