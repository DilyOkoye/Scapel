using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoCategoryAggregate.Dtos;

namespace Scapel.Domain.VideoCategoryAggregate
{
    
    public interface IVideoCategoryRepository : IGenericRepository<VideoCategory>
    {
        IEnumerable<VideoCategory> GetVideoCategoryById(int Id);
    }
}
