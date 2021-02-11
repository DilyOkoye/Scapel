using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.LeaderboardAggregate;
using Scapel.Domain.LeaderboardAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    
    public class LeaderboardRepository : GenericRepository<Leaderboard>, ILeaderboardRepository
    {
        public LeaderboardRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Leaderboard> GetLeaderboardById(int Id)
        {
            return _context.Leaderboard.Where(x => x.Id == Id);
        }

    }
}
