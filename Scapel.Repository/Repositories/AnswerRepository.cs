using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
   
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Answer> GetAnswerById(int Id)
        {
            return _context.Answers.Where(x => x.Id == Id);
        }

    }
}
