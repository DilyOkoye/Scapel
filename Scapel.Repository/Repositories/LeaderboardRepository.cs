using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.LeaderboardAggregate;
using Scapel.Domain.LeaderboardAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{

    public class LeaderboardRepository : GenericRepository<Leaderboard>, ILeaderboardRepository
    {
        public LeaderboardRepository(ScapelContext context) : base(context)
        {

        }


        public async Task<LeaderboardDto> GetLeaderboardForView(int Id)
        {
            var leaderboard= await _context.Leaderboard.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<LeaderboardDto>(leaderboard);
            }
            return new LeaderboardDto();
        }

        public async Task CreateOrEditLeaderboard(LeaderboardDto input)
        {
            if (input.Id == 0)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        public async Task<LeaderboardDto> GetLeaderboardForEdit(LeaderboardDto input)
        {
            var leaderboard= await _context.Leaderboard.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                Leaderboard leaderboardDto = MappingProfile.MappingConfigurationSetups().Map<Leaderboard>(input);
                _context.Leaderboard.Update(leaderboardDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<LeaderboardDto>(leaderboardDto);
            }
            return new LeaderboardDto();
        }

        protected virtual async Task Create(LeaderboardDto input)
        {
            Leaderboard comment = MappingProfile.MappingConfigurationSetups().Map<Leaderboard>(input);

            _context.Leaderboard.Add(comment);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(LeaderboardDto input)
        {
            var leaderboard = await _context.Leaderboard.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                Leaderboard leaderboardDto = MappingProfile.MappingConfigurationSetups().Map<Leaderboard>(input);
                _context.Leaderboard.Update(leaderboardDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteLeaderboard(int Id)
        {
            var leaderboard = await _context.Leaderboard.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                _context.Leaderboard.Remove(leaderboard);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

      
        public List<LeaderboardDto> GetAllLeaderboard(LeaderboardDto input)
        {

            var query = (from leaderboard in _context.Leaderboard.ToList()
                         join topic in _context.Topic.ToList()
                              on leaderboard.TopicId equals topic.Id

                         join questionCategory in _context.QuestionCategory.ToList()
                         on leaderboard.QuestionCategoryId equals questionCategory.Id

                         select new LeaderboardDto
                         {
                             TopicName = topic.Name,
                             QuestionCategoryName = questionCategory.Name,
                             Id = leaderboard.Id,
                             DateCreated = leaderboard.DateCreated,
                             Status = leaderboard.Status,
                             UserId = leaderboard.UserId,
                             Score = leaderboard.Score

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<LeaderboardDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<LeaderboardDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TopicName != null && p.TopicName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.QuestionCategoryName != null && p.QuestionCategoryName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.Score != null && p.Score.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<LeaderboardDto> Sort(string order, string orderDir, List<LeaderboardDto> data)
        {
            // Initialization.
            List<LeaderboardDto> lst = new List<LeaderboardDto>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Score).ToList()
                                                                                                 : data.OrderBy(p => p.Score).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                    case "5":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.QuestionCategoryName).ToList()
                                                                                                 : data.OrderBy(p => p.QuestionCategoryName).ToList();
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
