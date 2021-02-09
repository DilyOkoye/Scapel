using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate.Dtos;

namespace Scapel.Domain.UserProfileAggregate
{
    
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        IEnumerable<UserProfile> GetUserById(int Id);
    }
}
