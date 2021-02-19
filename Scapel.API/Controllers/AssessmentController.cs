using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.AssessmentAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssessmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET: /<controller>/
        [HttpGet]
        [Route("GetAssessmentForView")]
        public async Task<AssessmentDto> GetAssessmentForView(int Id)
        {
            return await _unitOfWork.Assessments.GetAssessmentForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditAssessment")]
        public async Task CreateOrEditAssessment(AssessmentDto input)
        {
            await _unitOfWork.Assessments.CreateOrEditAssessment(input);
        }

        [HttpGet]
        [Route("GetAssessmentForEdit")]
        public async Task GetAssessmentForEdit(AssessmentDto input)
        {
            await _unitOfWork.Assessments.GetAssessmentForEdit(input);
        }

        [HttpPost]
        [Route("DeleteAssessment")]
        public async Task DeleteAssessment(int Id)
        {
            await _unitOfWork.Assessments.DeleteAssessment(Id);
        }

        [HttpGet]
        [Route("GetAllAssessment")]
        public List<AssessmentDto> GetAllAssessment(AssessmentDto input)
        {
            return _unitOfWork.Assessments.GetAllAssessment(input);
        }
    }
}
