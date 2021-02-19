using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.AnswerAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET: /<controller>/
        [HttpGet]
        [Route("GetAnswerForView")]
        public async Task<AnswerDto> GetAnswerForView(int Id)
        {
            return await _unitOfWork.Answers.GetAnswerForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditAnswer")]
        public async Task CreateOrEditAnswer(AnswerDto input)
        {
            await _unitOfWork.Answers.CreateOrEditAnswer(input);
        }

        [HttpGet]
        [Route("GetAnswerForEdit")]
        public async Task GetAnswerForEdit(AnswerDto input)
        {
            await _unitOfWork.Answers.GetAnswerForEdit(input);
        }

        [HttpPost]
        [Route("DeleteAnswer")]
        public async Task DeleteAnswer(int Id)
        {
            await _unitOfWork.Answers.DeleteAnswer(Id);
        }

        [HttpGet]
        [Route("GetAllAnswer")]
        public List<AnswerDto> GetAllAnswer(AnswerDto input)
        {
            return _unitOfWork.Answers.GetAllAnswer(input);
        }
    }
}
