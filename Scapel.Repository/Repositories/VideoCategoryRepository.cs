using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.VideoCategoryAggregate;
using Scapel.Domain.VideoCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    
    public class VideoCategoryRepository : GenericRepository<VideoCategory>, IVideoCategoryRepository
    {
        public VideoCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<VideoCategory> GetVideoCategoryById(int Id)
        {
            return _context.VideoCategory.Where(x => x.Id == Id);
        }

    }
}
