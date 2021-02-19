using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.CommentAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetAssessmentForView")]
        public async Task<CommentDto> GetCommentForView(int Id)
        {
            return await _unitOfWork.Commments.GetCommentForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditComment")]
        public async Task CreateOrEditComment(CommentDto input)
        {
            await _unitOfWork.Commments.CreateOrEditComment(input);
        }

        [HttpGet]
        [Route("GetCommentForEdit")]
        public async Task GetCommentForEdit(CommentDto input)
        {
            await _unitOfWork.Commments.GetCommentForEdit(input);
        }

        [HttpPost]
        [Route("DeleteComment")]
        public async Task DeleteComment(int Id)
        {
            await _unitOfWork.Commments.DeleteComment(Id);
        }

        [HttpGet]
        [Route("GetAllComment")]
        public List<CommentDto> GetAllComment(CommentDto input)
        {
            return _unitOfWork.Commments.GetAllComment(input);
        }
    }
}
