using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class TrainingCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainingCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetTrainingCategoryForView")]
        public async Task<TrainingCategoryDto> GetTrainingCategoryForView(int Id)
        {
            return await _unitOfWork.TrainingCategorys.GetTrainingCategoryForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditTrainingCategory")]
        public async Task CreateOrEditTrainingCategory(TrainingCategoryDto input)
        {
            await _unitOfWork.TrainingCategorys.CreateOrEditTrainingCategory(input);
        }

        [HttpGet]
        [Route("GetTrainingCategoryForEdit")]
        public async Task GetTrainingCategoryForEdit(TrainingCategoryDto input)
        {
            await _unitOfWork.TrainingCategorys.GetTrainingCategoryForEdit(input);
        }

        [HttpPost]
        [Route("DeleteTrainingCategory")]
        public async Task DeleteTrainingCategory(int Id)
        {
            await _unitOfWork.TrainingCategorys.DeleteTrainingCategory(Id);
        }

        [HttpGet]
        [Route("GetAllTrainingCategory")]
        public List<TrainingCategoryDto> GetAllTrainingCategory(TrainingCategoryDto input)
        {
            return _unitOfWork.TrainingCategorys.GetAllTrainingCategory(input);
        }
    }
}
