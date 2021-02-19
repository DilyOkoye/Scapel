using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {   
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetQuestionForView")]
        public async Task<QuestionDto> GetQuestionForView(int Id)
        {
            return await _unitOfWork.Questions.GetQuestionForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditQuestion")]
        public async Task CreateOrEditQuestion(QuestionDto input)
        {
            await _unitOfWork.Questions.CreateOrEditQuestion(input);
        }

        [HttpGet]
        [Route("GetQuestionForEdit")]
        public async Task GetQuestionForEdit(QuestionDto input)
        {
            await _unitOfWork.Questions.GetQuestionForEdit(input);
        }

        [HttpPost]
        [Route("DeleteQuestion")]
        public async Task DeleteQuestion(int Id)
        {
            await _unitOfWork.Questions.DeleteQuestion(Id);
        }

        [HttpGet]
        [Route("GetAllQuestion")]
        public List<QuestionDto> GetAllQuestion(QuestionDto input)
        {
            return _unitOfWork.Questions.GetAllQuestion(input);
        }
    }
}
