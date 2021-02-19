using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VoteAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class VoteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetVoteForView")]
        public async Task<VoteDto> GetVoteForView(int Id)
        {
            return await _unitOfWork.Votes.GetVoteForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditVote")]
        public async Task CreateOrEditVote(VoteDto input)
        {
            await _unitOfWork.Votes.CreateOrEditVote(input);
        }

        [HttpGet]
        [Route("GetVoteForEdit")]
        public async Task GetVoteForEdit(VoteDto input)
        {
            await _unitOfWork.Votes.GetVoteForEdit(input);
        }

        [HttpPost]
        [Route("DeleteVote")]
        public async Task DeleteVote(int Id)
        {
            await _unitOfWork.Votes.DeleteVote(Id);
        }

        [HttpGet]
        [Route("GetAllVote")]
        public List<VoteDto> GetAllVote(VoteDto input)
        {
            return _unitOfWork.Votes.GetAllVote(input);
        }
    }
}
