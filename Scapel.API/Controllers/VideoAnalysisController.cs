using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class VideoAnalysisController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VideoAnalysisController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetVideoAnalysisForView")]
        public async Task<VideoAnalysisDto> GetVideoAnalysisForView(int Id)
        {
            return await _unitOfWork.VideoAnalysis.GetVideoAnalysisForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditVideoAnalysis")]
        public async Task CreateOrEditVideoAnalysis(VideoAnalysisDto input)
        {
            await _unitOfWork.VideoAnalysis.CreateOrEditVideoAnalysis(input);
        }

        [HttpGet]
        [Route("GetVideoAnalysisForEdit")]
        public async Task GetVideoAnalysisForEdit(VideoAnalysisDto input)
        {
            await _unitOfWork.VideoAnalysis.GetVideoAnalysisForEdit(input);
        }

        [HttpPost]
        [Route("DeleteVideoAnalysis")]
        public async Task DeleteVideoAnalysis(int Id)
        {
            await _unitOfWork.VideoAnalysis.DeleteVideoAnalysis(Id);
        }

        [HttpGet]
        [Route("GetAllVideoAnalysis")]
        public List<VideoAnalysisDto> GetAllVideoAnalysis(VideoAnalysisDto input)
        {
            return _unitOfWork.VideoAnalysis.GetAllVideoAnalysis(input);
        }
    }
}
