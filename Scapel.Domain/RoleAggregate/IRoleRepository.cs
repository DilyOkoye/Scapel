using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RoleAggregate.Dtos;

namespace Scapel.Domain.RoleAggregate
{
   
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<RoleDto> GetRoleForView(int Id);
        Task CreateOrEditRole(RoleDto input);
        Task<RoleDto> GetRoleForEdit(RoleDto input);
        Task<int> DeleteRole(int Id);
        List<RoleDto> GetAllRole(RoleDto input);
    }

}
