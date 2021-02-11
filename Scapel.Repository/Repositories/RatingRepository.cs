using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.RatingAggregate;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
   

    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Rating> GetRatingById(int Id)
        {
            return _context.Rating.Where(x => x.Id == Id);
        }

    }
}
