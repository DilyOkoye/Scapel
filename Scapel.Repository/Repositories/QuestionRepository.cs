using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.QuestionAggregate;
using Scapel.Domain.QuestionAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    

    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Question> GetQuestionById(int Id)
        {
            return _context.Question.Where(x => x.Id == Id);
        }

    }
}
