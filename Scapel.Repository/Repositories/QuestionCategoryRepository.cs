using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.QuestionCategoryAggregate;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    

    public class QuestionCategoryRepository : GenericRepository<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<QuestionCategory> GetQuestionCategoryById(int Id)
        {
            return _context.QuestionCategory.Where(x => x.Id == Id);
        }

    }
}
