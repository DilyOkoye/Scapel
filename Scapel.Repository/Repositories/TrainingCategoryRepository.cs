using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TrainingCategoryAggregate;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    

    public class TrainingCategoryRepository : GenericRepository<TrainingCategory>, ITrainingCategoryRepository
    {
        public TrainingCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<TrainingCategoryDto> GetTrainingCategoryForView(int Id)
        {
            var ratings = await _context.TrainingCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<TrainingCategoryDto>(ratings);
            }
            return new TrainingCategoryDto();
        }

        public async Task<TrainingCategoryDto> GetTrainingCategoryForEdit(TrainingCategoryDto input)
        {
            var users = await _context.TrainingCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                TrainingCategory roleDto = MappingProfile.MappingConfigurationSetups().Map<TrainingCategory>(input);
                _context.TrainingCategory.Update(roleDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<TrainingCategoryDto>(roleDto);
            }
            return new TrainingCategoryDto();
        }

        public async Task<int> DeleteTrainingCategory(int Id)
        {
            var roles = await _context.TrainingCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (roles != null)
            {
                _context.TrainingCategory.Remove(roles);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditTrainingCategory(TrainingCategoryDto input)
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

        protected virtual async Task Create(TrainingCategoryDto input)
        {
            TrainingCategory roleDto = MappingProfile.MappingConfigurationSetups().Map<TrainingCategory>(input);
            _context.TrainingCategory.Add(roleDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(TrainingCategoryDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                TrainingCategory trainingCategoryDto = MappingProfile.MappingConfigurationSetups().Map<TrainingCategory>(input);
                _context.TrainingCategory.Update(trainingCategoryDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<TrainingCategoryDto> GetAllTrainingCategory(TrainingCategoryDto input)
        {
            var allTrainingCategory = _context.TrainingCategory.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            List<TrainingCategoryDto> trainingCategoryDto = MappingProfile.MappingConfigurationSetups().Map<List<TrainingCategoryDto>>(allTrainingCategory);

            //Apply Sort
            trainingCategoryDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, trainingCategoryDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                trainingCategoryDto = trainingCategoryDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return trainingCategoryDto;

        }


        public List<TrainingCategoryDto> Sort(string order, string orderDir, List<TrainingCategoryDto> data)
        {
            // Initialization.
            List<TrainingCategoryDto> lst = new List<TrainingCategoryDto>();

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
