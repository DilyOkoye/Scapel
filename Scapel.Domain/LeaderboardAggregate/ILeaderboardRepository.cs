using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.LeaderboardAggregate.Dtos;

namespace Scapel.Domain.LeaderboardAggregate
{
  
    public interface ILeaderboardRepository : IGenericRepository<Leaderboard>
    {
        IEnumerable<Leaderboard> GetAnswerById(int Id);
    }
}
