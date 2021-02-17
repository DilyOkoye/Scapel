using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TopicAggregate;
using Scapel.Domain.TopicAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
   
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ScapelContext context) : base(context)
        {

        }

       
        public async Task<TopicDto> GetTopicForView(int Id)
        {
            var topics = await _context.Topic.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (topics != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<TopicDto>(topics);
            }
            return new TopicDto();
        }

        public async Task<TopicDto> GetTopicForEdit(TopicDto input)
        {
            var topics = await _context.Topic.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (topics != null)
            {
                Topic topicDto = MappingProfile.MappingConfigurationSetups().Map<Topic>(input);
                _context.Topic.Update(topicDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<TopicDto>(topicDto);
            }
            return new TopicDto();
        }

        public async Task<int> DeleteTopic(int Id)
        {
            var ratings = await _context.Rating.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                _context.Rating.Remove(ratings);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }


        public async Task CreateOrEditTopic(TopicDto input)
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

        protected virtual async Task Create(TopicDto input)
        {
            Topic topicDto = MappingProfile.MappingConfigurationSetups().Map<Topic>(input);
            _context.Topic.Add(topicDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(TopicDto input)
        {
            var users = await _context.Topic.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Topic topicDto = MappingProfile.MappingConfigurationSetups().Map<Topic>(input);
                _context.Topic.Update(topicDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<TopicDto> GetAllTopic(TopicDto input)
        {
          //  var allRatings = _context.Topic.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            var query = (from topic in _context.Topic.ToList()
                         select new TopicDto
                         {

                             Id = topic.Id,
                             DateCreated = topic.DateCreated,
                             Status = topic.Status,
                             UserId = topic.UserId,
                             CloudFolder = topic.CloudFolder,
                             CloudKey = topic.CloudKey,
                             Content = topic.Content,
                             ContentType = topic.ContentType,
                             ImagePath = topic.ImagePath,
                             Name = topic.Name,

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<TopicDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<TopicDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudKey != null && p.CloudKey.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudFolder != null && p.CloudFolder.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.Content != null && p.Content.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.ImagePath != null && p.ImagePath.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }


        public List<TopicDto> Sort(string order, string orderDir, List<TopicDto> data)
        {
            // Initialization.
            List<TopicDto> lst = new List<TopicDto>();

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

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Content).ToList()
                                                                                                 : data.OrderBy(p => p.Content).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                    case "5":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Content).ToList()
                                                                                                 : data.OrderBy(p => p.Content).ToList();
                        break;

                    case "6":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ImagePath).ToList()
                                                                                                 : data.OrderBy(p => p.ImagePath).ToList();
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
