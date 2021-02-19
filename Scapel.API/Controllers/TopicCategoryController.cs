using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TopicCategoryAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class TopicCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TopicCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetTopicCategoryForView")]
        public async Task<TopicCategoryDto> GetTopicCategoryForView(int Id)
        {
            return await _unitOfWork.TopicCategorys.GetTopicCategoryForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditTopicCategory")]
        public async Task CreateOrEditTopicCategory(TopicCategoryDto input)
        {
            await _unitOfWork.TopicCategorys.CreateOrEditTopicCategory(input);
        }

        [HttpGet]
        [Route("GetTopicCategoryForEdit")]
        public async Task GetTopicCategoryForEdit(TopicCategoryDto input)
        {
            await _unitOfWork.TopicCategorys.GetTopicCategoryForEdit(input);
        }

        [HttpPost]
        [Route("DeleteTopicCategory")]
        public async Task DeleteTopicCategory(int Id)
        {
            await _unitOfWork.TopicCategorys.DeleteTopicCategory(Id);
        }

        [HttpGet]
        [Route("GetAllTopicCategory")]
        public List<TopicCategoryDto> GetAllTopicCategory(TopicCategoryDto input)
        {
            return _unitOfWork.TopicCategorys.GetAllTopicCategory(input);
        }
    }
}
