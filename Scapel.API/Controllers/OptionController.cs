using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.OptionAggregate.Dtos;

namespace Scapel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET: /<controller>/
        [HttpGet]
        [Route("GetOptionForView")]
        public async Task<OptionDto> GetOptionForView(int Id)
        {
            return await _unitOfWork.Options.GetOptionForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditOption")]
        public async Task CreateOrEditOption(OptionDto input)
        {
            await _unitOfWork.Options.CreateOrEditOption(input);
        }

        [HttpGet]
        [Route("GetOptionForEdit")]
        public async Task GetOptionForEdit(OptionDto input)
        {
            await _unitOfWork.Options.GetOptionForEdit(input);
        }

        [HttpPost]
        [Route("DeleteOption")]
        public async Task DeleteOption(int Id)
        {
            await _unitOfWork.Options.DeleteOption(Id);
        }

        [HttpGet]
        [Route("GetAllOption")]
        public List<OptionDto> GetAllOption(OptionDto input)
        {
            return _unitOfWork.Options.GetAllOption(input);
        }
    }
}
