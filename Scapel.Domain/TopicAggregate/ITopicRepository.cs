using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TopicAggregate.Dtos;

namespace Scapel.Domain.TopicAggregate
{
   

    public interface ITopicRepository : IGenericRepository<Topic>
    {

        Task<TopicDto> GetTopicForView(int Id);
        Task CreateOrEditTopic(TopicDto input);
        Task<TopicDto> GetTopicForEdit(TopicDto input);
        Task<int> DeleteTopic(int Id);
        List<TopicDto> GetAllTopic(TopicDto input);

    }
}
