using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
  

    public class AssessmentRepository : GenericRepository<Answer>, IAssessmentRepository
    {
        public IAssessmentRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Answer> GetAnswerById(int Id)
        {
            return _context.Answers.Where(x => x.Id == Id);
        }

    }
}
