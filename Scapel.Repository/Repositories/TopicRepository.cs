using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TopicAggregate;
using Scapel.Domain.TopicAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
   
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Topic> GetTopicById(int Id)
        {
            return _context.Topic.Where(x => x.Id == Id);
        }

    }
}
