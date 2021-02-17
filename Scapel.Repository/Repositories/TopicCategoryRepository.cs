using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TopicCategoryAggregate;
using Scapel.Domain.TopicCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    

    public class TopicCategoryRepository : GenericRepository<TopicCategory>, ITopicCategoryRepository
    {
        public TopicCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<TopicCategoryDto> GetTopicCategoryForView(int Id)
        {
            var topicCategory = await _context.TopicCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (topicCategory != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<TopicCategoryDto>(topicCategory);
            }
            return new TopicCategoryDto();
        }

        public async Task<TopicCategoryDto> GetTopicCategoryForEdit(TopicCategoryDto input)
        {
            var topics = await _context.TopicCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (topics != null)
            {
                TopicCategory topicCategoryDto = MappingProfile.MappingConfigurationSetups().Map<TopicCategory>(input);
                _context.TopicCategory.Update(topicCategoryDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<TopicCategoryDto>(topicCategoryDto);
            }
            return new TopicCategoryDto();
        }

        public async Task<int> DeleteTopicCategory(int Id)
        {
            var topicCategory = await _context.TopicCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (topicCategory != null)
            {
                _context.TopicCategory.Remove(topicCategory);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }


        public async Task CreateOrEditTopicCategory(TopicCategoryDto input)
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

        protected virtual async Task Create(TopicCategoryDto input)
        {
            TopicCategory topicCategoryDto = MappingProfile.MappingConfigurationSetups().Map<TopicCategory>(input);
            _context.TopicCategory.Add(topicCategoryDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(TopicCategoryDto input)
        {
            var users = await _context.TopicCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                TopicCategory topicCategoryDto = MappingProfile.MappingConfigurationSetups().Map<TopicCategory>(input);
                _context.TopicCategory.Update(topicCategoryDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<TopicCategoryDto> GetAllTopicCategory(TopicCategoryDto input)
        {
            //  var allRatings = _context.Topic.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            var query = (from topic in _context.TopicCategory.ToList()
                         select new TopicCategoryDto
                         {

                             Id = topic.Id,
                             DateCreated = topic.DateCreated,
                             Status = topic.Status,
                             UserId = topic.UserId,
                             CloudFolder = topic.CloudFolder,
                             CloudKey = topic.CloudKey,
                             ImagePath = topic.ImagePath,
                             Name = topic.Name,

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<TopicCategoryDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<TopicCategoryDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudKey != null && p.CloudKey.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudFolder != null && p.CloudFolder.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.ImagePath != null && p.ImagePath.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }


        public List<TopicCategoryDto> Sort(string order, string orderDir, List<TopicCategoryDto> data)
        {
            // Initialization.
            List<TopicCategoryDto> lst = new List<TopicCategoryDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Name).ToList()
                                                                                                 : data.OrderBy(p => p.Name).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CloudFolder).ToList()
                                                                                                 : data.OrderBy(p => p.CloudFolder).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CloudKey).ToList()
                                                                                                 : data.OrderBy(p => p.CloudKey).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                  

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Name).ToList()
                                                                                                 : data.OrderBy(p => p.Name).ToList();
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
