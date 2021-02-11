using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TagAggregate.Dtos;

namespace Scapel.Domain.TagAggregate
{
    
    public interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<Tag> GetTagById(int Id);
    }
}
