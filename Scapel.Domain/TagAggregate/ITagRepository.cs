using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TagAggregate.Dtos;

namespace Scapel.Domain.TagAggregate
{
    
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<TagDto> GetTagForView(int Id);
        Task CreateOrEditTag(TagDto input);
        Task<TagDto> GetTagForEdit(TagDto input);
        Task<int> DeleteTag(int Id);
        List<TagDto> GetAllTag(TagDto input);
    }
}
