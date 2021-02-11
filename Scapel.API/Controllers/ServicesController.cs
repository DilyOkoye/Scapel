using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        //GET: /<controller>/
        [HttpGet]
        //[SwaggerResponse(HttpStatusCode.OK, "OK", typeof(User))]
        //[SwaggerResponse(HttpStatusCode.BadRequest, "Error", typeof(string))]
        //[SwaggerResponse(HttpStatusCode.NotFound, "Notfound", typeof(string))]
        [Route("GetUsersView")]
        public async Task<UserProfile> GetUsersView(int Id)
        {
            return await _unitOfWork.UserProfiles.GetUserForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditUsers")]
        public async Task CreateOrEditUsers(UserProfileDto input)
        {
             await _unitOfWork.UserProfiles.CreateOrEditUsers(input);
        }
        #endregion

    }
}
