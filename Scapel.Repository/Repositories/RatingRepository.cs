using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.RatingAggregate;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
   

    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<RatingDto> GetRatingForView(int Id)
        {
            var ratings = await _context.Rating.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<RatingDto>(ratings);
            }
            return new RatingDto();
        }

        public async Task<RatingDto> GetRatingForEdit(RatingDto input)
        {
            var users = await _context.Rating.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Rating ratingDto = MappingProfile.MappingConfigurationSetups().Map<Rating>(input);
                _context.Rating.Update(ratingDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<RatingDto>(ratingDto);
            }
            return new RatingDto();
        }


        public async Task<int> DeleteRating(int Id)
        {
            var ratings = await _context.Rating.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                _context.Rating.Remove(ratings);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }


        public async Task CreateOrEditRating(RatingDto input)
        {
            if (input.Id == null || input.Id == 0)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }

        }

        protected virtual async Task Create(RatingDto input)
        {
            Rating ratingDto = MappingProfile.MappingConfigurationSetups().Map<Rating>(input);
            _context.Rating.Add(ratingDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(RatingDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Rating ratingDto = MappingProfile.MappingConfigurationSetups().Map<Rating>(input);
                _context.Rating.Update(ratingDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<RatingDto> GetAllRating(RatingDto input)
        {
            var allRatings = _context.Rating.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            var query = (from rating in _context.Rating.ToList()
                        join topic in _context.Topic.ToList()
                             on rating.TopicId equals topic.Id
                        select new RatingDto
                        {
                            RatingCount = rating.RatingCount,
                            TopicId =topic.Id,
                            TopicName =topic.Name,
                            Id =rating.Id,
                            DateCreated =rating.DateCreated,
                            Status =rating.Status,
                            UserId =rating.UserId

                        }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<RatingDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<RatingDto>>(allRatings);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TopicName != null && p.TopicName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.RatingCount != null && p.RatingCount.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }


        public List<RatingDto> Sort(string order, string orderDir, List<RatingDto> data)
        {
            // Initialization.
            List<RatingDto> lst = new List<RatingDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.RatingCount).ToList()
                                                                                                 : data.OrderBy(p => p.RatingCount).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicId).ToList()
                                                                                                 : data.OrderBy(p => p.TopicId).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;



                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {


            }

            // info.
            return lst;
        }

    }
}
