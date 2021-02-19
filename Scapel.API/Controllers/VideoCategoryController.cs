using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoCategoryAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class VideoCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VideoCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetVideoCategoryForView")]
        public async Task<VideoCategoryDto> GetVideoCategoryForView(int Id)
        {
            return await _unitOfWork.VideoCategory.GetVideoCategoryForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditVideoCategory")]
        public async Task CreateOrEditVideoCategory(VideoCategoryDto input)
        {
            await _unitOfWork.VideoCategory.CreateOrEditVideoCategory(input);
        }

        [HttpGet]
        [Route("GetVideoCategoryForEdit")]
        public async Task GetVideoCategoryForEdit(VideoCategoryDto input)
        {
            await _unitOfWork.VideoCategory.GetVideoCategoryForEdit(input);
        }

        [HttpPost]
        [Route("DeleteVideoCategory")]
        public async Task DeleteVideoCategory(int Id)
        {
            await _unitOfWork.VideoCategory.DeleteVideoCategory(Id);
        }

        [HttpGet]
        [Route("GetAllVideoCategory")]
        public List<VideoCategoryDto> GetAllVideoCategory(VideoCategoryDto input)
        {
            return _unitOfWork.VideoCategory.GetAllVideoCategory(input);
        }
    }
}
