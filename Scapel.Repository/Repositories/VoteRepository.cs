using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.VoteAggregate;
using Scapel.Domain.VoteAggregate.Dtos;

namespace Scapel.Repository.Repositories
{
   

    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Vote> GetVoteById(int Id)
        {
            return _context.Vote.Where(x => x.Id == Id);
        }

    }
}
