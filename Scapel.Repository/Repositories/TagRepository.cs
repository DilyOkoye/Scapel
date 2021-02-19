using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.TagAggregate;
using Scapel.Domain.TagAggregate.Dtos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    

    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<TagDto> GetTagForView(int Id)
        {
            var tags = await _context.Tag.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (tags != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<TagDto>(tags);
            }
            return new TagDto();
        }

        public async Task<TagDto> GetTagForEdit(TagDto input)
        {
            var users = await _context.Rating.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Tag tagDto = MappingProfile.MappingConfigurationSetups().Map<Tag>(input);
                _context.Tag.Update(tagDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<TagDto>(tagDto);
            }
            return new TagDto();
        }

        public async Task<int> DeleteTag(int Id)
        {
            var tags = await _context.Tag.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (tags != null)
            {
                _context.Tag.Remove(tags);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }


        public async Task CreateOrEditTag(TagDto input)
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

        protected virtual async Task Create(TagDto input)
        {
            Tag tagDto = MappingProfile.MappingConfigurationSetups().Map<Tag>(input);
            _context.Tag.Add(tagDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(TagDto input)
        {
            var tags = await _context.Tag.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (tags != null)
            {
                Tag tagDto = MappingProfile.MappingConfigurationSetups().Map<Tag>(input);
                _context.Tag.Update(tagDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<TagDto> GetAllTag(TagDto input)
        {
           
            var query = (from tags in _context.Tag.ToList()
                         join topic in _context.Topic.ToList()
                              on tags.TopicId equals topic.Id
                         select new TagDto
                         {
                             TopicName = topic.Name,
                             TopicId = topic.Id,
                             Name = tags.Name,
                             Id = tags.Id,
                             DateCreated = tags.DateCreated,
                             Status = tags.Status,
                             UserId = tags.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<TagDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<TagDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TopicName != null && p.TopicName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }


        public List<TagDto> Sort(string order, string orderDir, List<TagDto> data)
        {
            // Initialization.
            List<TagDto> lst = new List<TagDto>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;


                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
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
