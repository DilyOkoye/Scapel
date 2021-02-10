using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TopicCategoryAggregate.Dtos;

namespace Scapel.Domain.TopicCategoryAggregate
{

    public interface ITopicCategoryRepository : IGenericRepository<TopicCategory>
    {
        IEnumerable<TopicCategory> GetTopicCategoryById(int Id);
    }
}
