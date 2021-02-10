using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VoteAggregate.Dtos;

namespace Scapel.Domain.VoteAggregate
{
  
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        IEnumerable<Vote> GetVoteById(int Id);
    }
}
