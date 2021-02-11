using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Domain.RoleAggregate;
using Scapel.Domain.RoleAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Role> GetRoleById(int Id)
        {
            return _context.Role.Where(x => x.Id == Id);
        }

    }


}
