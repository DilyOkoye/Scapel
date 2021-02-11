using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RoleAggregate.Dtos;

namespace Scapel.Domain.RoleAggregate
{
   
    public interface IRoleRepository : IGenericRepository<Role>
    {
        IEnumerable<Role> GetRoleById(int Id);
    }

}
