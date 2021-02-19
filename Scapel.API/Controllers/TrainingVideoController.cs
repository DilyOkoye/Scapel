using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingVideoAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class TrainingVideoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainingVideoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetTrainingVideoForView")]
        public async Task<TrainingVideoDto> GetTrainingVideoForView(int Id)
        {
            return await _unitOfWork.TrainingVideos.GetTrainingVideoForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditTrainingVideo")]
        public async Task CreateOrEditTrainingVideo(TrainingVideoDto input)
        {
            await _unitOfWork.TrainingVideos.CreateOrEditTrainingVideo(input);
        }

        [HttpGet]
        [Route("GetTrainingVideoForEdit")]
        public async Task GetTrainingVideoForEdit(TrainingVideoDto input)
        {
            await _unitOfWork.TrainingVideos.GetTrainingVideoForEdit(input);
        }

        [HttpPost]
        [Route("DeleteTrainingVideo")]
        public async Task DeleteTrainingVideo(int Id)
        {
            await _unitOfWork.TrainingVideos.DeleteTrainingVideo(Id);
        }

        [HttpGet]
        [Route("GetAllTrainingVideo")]
        public List<TrainingVideoDto> GetAllTrainingVideo(TrainingVideoDto input)
        {
            return _unitOfWork.TrainingVideos.GetAllTrainingVideo(input);
        }
    }
}
