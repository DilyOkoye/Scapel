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
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetUsersView")]
        public async Task<UserProfileDto> GetUserForView(int Id)
        {
            return await _unitOfWork.UserProfiles.GetUserForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditUsers")]
        public async Task CreateOrEditUsers(UserProfileDto input)
        {
            await _unitOfWork.UserProfiles.CreateOrEditUsers(input);
        }

        [HttpGet]
        [Route("GetUserForEdit")]
        public async Task GetUserForEdit(UserProfileDto input)
        {
            await _unitOfWork.UserProfiles.GetUserForEdit(input);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task DeleteUser(int Id)
        {
            await _unitOfWork.UserProfiles.DeleteUser(Id);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public List<UserProfileDto> GetAllUsers(UserProfileDto input)
        {
          return _unitOfWork.UserProfiles.GetAllUsers(input);
        }

        [HttpGet]
        [Route("AutheticateUser")]
        public async Task<LoginResponseDto> AutheticateUser(LoginRequestDto input)
        {
          return  await _unitOfWork.UserProfiles.AutheticateUser(input);
        }


        //[ApiController]
        //[Route("[controller]")]
        //public class WeatherForecastController : ControllerBase
        //{
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet]
        //    public IEnumerable<WeatherForecast> Get()
        //    {
        //        var rng = new Random();
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = rng.Next(-20, 55),
        //            Summary = Summaries[rng.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
        //}
    }
}
