using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Models;
using QuizSystem.Repositories;
using QuizSystem.Services;
using QuizSystem.DTOs;
using QuizSystem.Models.ViewModels.Exams;
using QuizSystem.DTOs.Exams;
using AutoMapper;
using QuizSystem.DTOs.Course;
using QuizSystem.Models.ViewModels.Course;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Error;
using QuizSystem.Models.Enums;
using QuizSystem.DTOs.Choice;
using QuizSystem.Models.ViewModels.StudentExam;
namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private ExamService _examService;
        private IMapper _mapper;

        public ExamsController(IMapper mapper)
        {
           _examService = new ExamService(mapper);
            _mapper = mapper;
        }

        [HttpGet("All")]
        public ResponseVM<IEnumerable<ExamVM>> GetAll()
        {
            var allExams = _examService.GetAllExams();
            var courseResponses = _mapper.Map<IEnumerable<ExamVM>>(allExams);
            return new SuccessResponseVM<IEnumerable<ExamVM>>(courseResponses);
        }

        [HttpGet("{id}")]
        public async Task<ResponseVM<ExamVM>> Get(int id)
        {
            var res = await _examService.GetExamById(id);
            if (res == null)
                return new FailureResponseVM<ExamVM>(ErrorCode.ExamNotFound, "Exam does not exist!");
            var examvm = _mapper.Map<ExamVM>(res);
            return new SuccessResponseVM<ExamVM>(examvm, "Exam retrieved successfully");
        }

        [HttpPost]
        public async Task<ResponseVM<ExamVM>> Add(ExamVM examVM)
        {
            var exam = _mapper.Map<ExamRequestDTO>(examVM);
            var addedExam = await _examService.AddExam(exam);
            var examvm = _mapper.Map<ExamVM>(addedExam);
            return new SuccessResponseVM<ExamVM>(examvm, "Exam added successfully");
        }

        [HttpPut]
        public async Task<ResponseVM<ExamUpdateVM>> Edit(ExamUpdateVM Exam)

        {
            var exam = _mapper.Map<ExamUpdateRequestDTO>(Exam);
            var updatedExam =  _examService.UpdateExam(exam);
            var examvm = _mapper.Map<ExamUpdateVM>(updatedExam);
            return new SuccessResponseVM<ExamUpdateVM>(examvm, "Exam updated successfully");
        }

        [HttpDelete("{Id}")]
        public async Task<ResponseVM<ExamVM>> Delete([FromRoute] int Id)
        {
            var entity = await _examService.DeleteExam(Id);

            if (entity == null)
                return new FailureResponseVM<ExamVM>(ErrorCode.ExamNotFound, "Exam not found");

            var vm = _mapper.Map<ExamVM>(entity);
            return new SuccessResponseVM<ExamVM>(vm, "Exam deleted successfully");
        }


        [HttpPost("{ExamId}")]
        public async Task<ResponseVM<StudentExamVM>> EvaluateExam(int ExamId)
        {

            var res = await _examService.EvaluateExam(ExamId);
            if (res == null)
                return new FailureResponseVM<StudentExamVM>(ErrorCode.ExamNotFound, "Exam does not exist!");
            var examvm = _mapper.Map<StudentExamVM>(res);
            return new SuccessResponseVM<StudentExamVM>(examvm, "Exam retrieved successfully");
        }


    }
}
