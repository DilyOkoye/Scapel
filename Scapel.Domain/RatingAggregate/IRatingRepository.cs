using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RatingAggregate.Dtos;

namespace Scapel.Domain.RatingAggregate
{
   
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        IEnumerable<Rating> GetRatingById(int Id);
    }

}
