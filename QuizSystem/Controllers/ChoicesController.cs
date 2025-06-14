using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.DTOs.Choice;
using QuizSystem.DTOs.Course;
using QuizSystem.Models;
using QuizSystem.Models.Enums;
using QuizSystem.Models.ViewModels.Choice;
using QuizSystem.Models.ViewModels.Course;
using QuizSystem.Models.ViewModels.Error;
using QuizSystem.Repositories;
using QuizSystem.Services;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController : ControllerBase
    {
        private ChoiceService _choiceService;
        private IMapper _mapper;
        public ChoicesController(IMapper mapper)
        {
            _choiceService = new ChoiceService(mapper);
            _mapper = mapper;
        }

        [HttpGet("All")]
        public ResponseVM<IEnumerable<ChoiceVM>>  GetAll()
        {
            var allChoices = _choiceService.GetAllChoices();
            var choiceResponses = _mapper.Map<IEnumerable<ChoiceVM>>(allChoices);
            return new SuccessResponseVM<IEnumerable<ChoiceVM>>(choiceResponses) ;
        }

        [HttpGet("{id}")]
        public async Task<ResponseVM<ChoiceVM>> Get(int id)
        {
            var res = await _choiceService.GetChoiceById(id);
            if (res == null)
                return new FailureResponseVM<ChoiceVM>( ErrorCode.ChoiceNotFound,"Choice does not exist!");
            var choicevm= _mapper.Map<ChoiceVM>(res);
            return new SuccessResponseVM<ChoiceVM>(choicevm, "Choice retrieved successfully");

        }

        [HttpPost]
        public async Task<ResponseVM<ChoiceVM>> Add(ChoiceVM Choice)
        {
            var choice = _mapper.Map<ChoiceRequestDTO>(Choice);
            var addedChoice=  await _choiceService.AddChoice(choice);
            var choicevm= _mapper.Map<ChoiceVM>(addedChoice);
            return new SuccessResponseVM<ChoiceVM>(choicevm, "Choice added successfully");
        }

        [HttpPatch]
        public async Task<ResponseVM<ChoiceUpdateVM>> Edit(ChoiceUpdateVM Choice)
        {
            var choice = _mapper.Map<ChoiceUpdateRequestDTO>(Choice);
            var updatedChoice= await _choiceService.UpdateChoice(choice);
            var choicevm = _mapper.Map<ChoiceUpdateVM>(updatedChoice);
            return new SuccessResponseVM<ChoiceUpdateVM>(choicevm, "Choice updated successfully");
        }


        [HttpDelete("{id}")]
        public async Task<ResponseVM<ChoiceVM>> Delete(int id)
        {
            var entity = await _choiceService.DeleteChoice(id);

            if (entity == null)
                return new FailureResponseVM<ChoiceVM>(ErrorCode.ChoiceNotFound, "Choice not found");

            var vm = _mapper.Map<ChoiceVM>(entity);
            return new SuccessResponseVM<ChoiceVM>(vm, "Choice deleted successfully");
        }
    }
}
