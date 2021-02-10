using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region
        // GET: /<controller>/
        //[HttpGet]
        //public async Task<UserProfile> GetUsersView(int Id)
        //{
        //    return await _unitOfWork.UserProfiles.GetUserByForView(Id);
        //}

        [HttpPost]
        public async Task<int> CreateOrEditUsers(UserProfileDto input)
        {
            return await _unitOfWork.UserProfiles.CreateOrEditUsers(input);
        }
        #endregion

    }
}
