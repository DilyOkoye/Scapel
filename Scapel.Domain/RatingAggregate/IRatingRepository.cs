using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.RatingAggregate.Dtos;

namespace Scapel.Domain.RatingAggregate
{
   
    public interface IRatingRepository : IGenericRepository<Rating>
    {

        Task<RatingDto> GetRatingForView(int Id);
        Task CreateOrEditRating(RatingDto input);
        Task<RatingDto> GetRatingForEdit(RatingDto input);
        Task<int> DeleteRating(int Id);
        List<RatingDto> GetAllRating(RatingDto input);
    }

}
