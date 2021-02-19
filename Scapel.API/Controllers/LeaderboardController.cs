using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.LeaderboardAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaderboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetAssessmentForView")]
        public async Task<LeaderboardDto> GetLeaderboardForView(int Id)
        {
            return await _unitOfWork.Leaderboards.GetLeaderboardForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditLeaderboard")]
        public async Task CreateOrEditLeaderboard(LeaderboardDto input)
        {
            await _unitOfWork.Leaderboards.CreateOrEditLeaderboard(input);
        }

        [HttpGet]
        [Route("GetLeaderboardForEdit")]
        public async Task GetLeaderboardForEdit(LeaderboardDto input)
        {
            await _unitOfWork.Leaderboards.GetLeaderboardForEdit(input);
        }

        [HttpPost]
        [Route("DeleteLeaderboard")]
        public async Task DeleteLeaderboard(int Id)
        {
            await _unitOfWork.Leaderboards.DeleteLeaderboard(Id);
        }

        [HttpGet]
        [Route("GetAllLeaderboard")]
        public List<LeaderboardDto> GetAllLeaderboard(LeaderboardDto input)
        {
            return _unitOfWork.Leaderboards.GetAllLeaderboard(input);
        }
    }
}
