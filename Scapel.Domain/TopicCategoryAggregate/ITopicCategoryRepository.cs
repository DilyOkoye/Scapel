using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TopicCategoryAggregate.Dtos;

namespace Scapel.Domain.TopicCategoryAggregate
{

    public interface ITopicCategoryRepository : IGenericRepository<TopicCategory>
    {
        Task<TopicCategoryDto> GetTopicCategoryForView(int Id);
        Task CreateOrEditTopicCategory(TopicCategoryDto input);
        Task<TopicCategoryDto> GetTopicCategoryForEdit(TopicCategoryDto input);
        Task<int> DeleteTopicCategory(int Id);
        List<TopicCategoryDto> GetAllTopicCategory(TopicCategoryDto input);
    }
}
