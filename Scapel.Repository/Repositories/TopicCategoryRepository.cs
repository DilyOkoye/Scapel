using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TopicCategoryAggregate;
using Scapel.Domain.TopicCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    

    public class TopicCategoryRepository : GenericRepository<TopicCategory>, ITopicCategoryRepository
    {
        public TopicCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<TopicCategory> GetTopicCategoryById(int Id)
        {
            return _context.TopicCategory.Where(x => x.Id == Id);
        }

    }
}
