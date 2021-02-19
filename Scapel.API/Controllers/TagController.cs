using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TagAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetTagForView")]
        public async Task<TagDto> GetTagForView(int Id)
        {
            return await _unitOfWork.Tags.GetTagForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditTag")]
        public async Task CreateOrEditTag(TagDto input)
        {
            await _unitOfWork.Tags.CreateOrEditTag(input);
        }

        [HttpGet]
        [Route("GetTagForEdit")]
        public async Task GetTagForEdit(TagDto input)
        {
            await _unitOfWork.Tags.GetTagForEdit(input);
        }

        [HttpPost]
        [Route("DeleteTag")]
        public async Task DeleteTag(int Id)
        {
            await _unitOfWork.Tags.DeleteTag(Id);
        }

        [HttpGet]
        [Route("GetAllTag")]
        public List<TagDto> GetAllTag(TagDto input)
        {
            return _unitOfWork.Tags.GetAllTag(input);
        }
    }
}
