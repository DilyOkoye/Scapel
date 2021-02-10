using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TopicAggregate.Dtos;

namespace Scapel.Domain.TopicAggregate
{
   

    public interface ITopicRepository : IGenericRepository<Topic>
    {
        IEnumerable<Topic> GetTopicById(int Id);
    }
}
