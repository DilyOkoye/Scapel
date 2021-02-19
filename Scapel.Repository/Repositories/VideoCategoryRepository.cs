using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.VideoCategoryAggregate;
using Scapel.Domain.VideoCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    
    public class VideoCategoryRepository : GenericRepository<VideoCategory>, IVideoCategoryRepository
    {
        public VideoCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<VideoCategoryDto> GetVideoCategoryForView(int Id)
        {
            var videoCategories = await _context.VideoCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (videoCategories != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<VideoCategoryDto>(videoCategories);
            }
            return new VideoCategoryDto();
        }

        public async Task<VideoCategoryDto> GetVideoCategoryForEdit(VideoCategoryDto input)
        {
            var categories = await _context.VideoCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (categories != null)
            {
                VideoCategory categoryDto = MappingProfile.MappingConfigurationSetups().Map<VideoCategory>(input);
                _context.VideoCategory.Update(categoryDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<VideoCategoryDto>(categoryDto);
            }
            return new VideoCategoryDto();
        }

        public async Task<int> DeleteVideoCategory(int Id)
        {
            var roles = await _context.Role.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (roles != null)
            {
                _context.Role.Remove(roles);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditVideoCategory(VideoCategoryDto input)
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

        protected virtual async Task Create(VideoCategoryDto input)
        {
            VideoCategory videoDto = MappingProfile.MappingConfigurationSetups().Map<VideoCategory>(input);
            _context.VideoCategory.Add(videoDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(VideoCategoryDto input)
        {
            var category = await _context.VideoCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (category != null)
            {
                VideoCategory categoryDto = MappingProfile.MappingConfigurationSetups().Map<VideoCategory>(input);
                _context.VideoCategory.Update(categoryDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<VideoCategoryDto> GetAllVideoCategory(VideoCategoryDto input)
        {
            var allCategories = _context.VideoCategory.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);


            // Map Records
            List<VideoCategoryDto> categoryDto = MappingProfile.MappingConfigurationSetups().Map<List<VideoCategoryDto>>(allCategories);

            //Apply Sort
            categoryDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, categoryDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                categoryDto = categoryDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return categoryDto;

        }


        public List<VideoCategoryDto> Sort(string order, string orderDir, List<VideoCategoryDto> data)
        {
            // Initialization.
            List<VideoCategoryDto> lst = new List<VideoCategoryDto>();

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
