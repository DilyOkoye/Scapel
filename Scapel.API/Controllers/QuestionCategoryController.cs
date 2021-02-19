using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetQuestionCategoryForView")]
        public async Task<QuestionCategoryDto> GetQuestionCategoryForView(int Id)
        {
            return await _unitOfWork.QuestionCategorys.GetQuestionCategoryForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditQuestionCategory")]
        public async Task CreateOrEditQuestionCategory(QuestionCategoryDto input)
        {
            await _unitOfWork.QuestionCategorys.CreateOrEditQuestionCategory(input);
        }

        [HttpGet]
        [Route("GetQuestionCategoryForEdit")]
        public async Task GetQuestionCategoryForEdit(QuestionCategoryDto input)
        {
            await _unitOfWork.QuestionCategorys.GetQuestionCategoryForEdit(input);
        }

        [HttpPost]
        [Route("DeleteQuestionCategory")]
        public async Task DeleteQuestionCategory(int Id)
        {
            await _unitOfWork.QuestionCategorys.DeleteQuestionCategory(Id);
        }

        [HttpGet]
        [Route("GetAllQuestionCategory")]
        public List<QuestionCategoryDto> GetAllQuestionCategory(QuestionCategoryDto input)
        {
            return _unitOfWork.QuestionCategorys.GetAllQuestionCategory(input);
        }
    }
}
