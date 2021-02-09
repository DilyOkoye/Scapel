using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.UserProfileAggregate;
using Scapel.Domain.UserProfileAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;


namespace Scapel.Repository.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<UserProfile> GetUserById(int Id)
        {
            return _context.UserProfiles.Where(x => x.Id == Id);
        }

    }
}
