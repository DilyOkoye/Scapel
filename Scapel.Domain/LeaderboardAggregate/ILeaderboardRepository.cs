using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.LeaderboardAggregate.Dtos;

namespace Scapel.Domain.LeaderboardAggregate
{
  
    public interface ILeaderboardRepository : IGenericRepository<Leaderboard>
    {
       
        Task<LeaderboardDto> GetLeaderboardForView(int Id);
        Task CreateOrEditLeaderboard(LeaderboardDto input);
        Task<LeaderboardDto> GetLeaderboardForEdit(LeaderboardDto input);
        Task<int> DeleteLeaderboard(int Id);
        List<LeaderboardDto> GetAllLeaderboard(LeaderboardDto input);
    }
}
