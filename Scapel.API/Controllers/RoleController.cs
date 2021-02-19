using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RoleAggregate.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scapel.API.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: /<controller>/
        [HttpGet]
        [Route("GetRoleForView")]
        public async Task<RoleDto> GetRoleForView(int Id)
        {
            return await _unitOfWork.Roles.GetRoleForView(Id);
        }

        [HttpPost]
        [Route("CreateOrEditRole")]
        public async Task CreateOrEditRole(RoleDto input)
        {
            await _unitOfWork.Roles.CreateOrEditRole(input);
        }

        [HttpGet]
        [Route("GetRoleForEdit")]
        public async Task GetRoleForEdit(RoleDto input)
        {
            await _unitOfWork.Roles.GetRoleForEdit(input);
        }

        [HttpPost]
        [Route("DeleteRole")]
        public async Task DeleteRole(int Id)
        {
            await _unitOfWork.Roles.DeleteRole(Id);
        }

        [HttpGet]
        [Route("GetAllRole")]
        public List<RoleDto> GetAllRole(RoleDto input)
        {
            return _unitOfWork.Roles.GetAllRole(input);
        }
    }
}
