using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.AssessmentAggregate;
using Scapel.Domain.AssessmentAggregate.Dtos;

namespace Scapel.Repository.Repositories
{
  

    public class AssessmentRepository : GenericRepository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Assessment> GetAssessmentById(int Id)
        {
            return _context.Assessment.Where(x => x.Id == Id);
        }

    }
}
