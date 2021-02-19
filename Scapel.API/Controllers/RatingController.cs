using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RatingAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RatingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetRatingForView")]
        public async Task<RatingDto> GetRatingForView(int Id)
        {
            return await _unitOfWork.Ratings.GetRatingForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditRating")]
        public async Task CreateOrEditRating(RatingDto input)
        {
            await _unitOfWork.Ratings.CreateOrEditRating(input);
        }

        [HttpGet]
        [Route("GetRatingForEdit")]
        public async Task GetRatingForEdit(RatingDto input)
        {
            await _unitOfWork.Ratings.GetRatingForEdit(input);
        }

        [HttpPost]
        [Route("DeleteRating")]
        public async Task DeleteRating(int Id)
        {
            await _unitOfWork.Ratings.DeleteRating(Id);
        }

        [HttpGet]
        [Route("GetAllRating")]
        public List<RatingDto> GetAllRating(RatingDto input)
        {
            return _unitOfWork.Ratings.GetAllRating(input);
        }
    }
}
