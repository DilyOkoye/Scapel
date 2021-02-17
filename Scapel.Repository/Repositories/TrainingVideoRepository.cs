using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TrainingVideoAggregate;
using Scapel.Domain.TrainingVideoAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    
    

    public class TrainingVideoRepository : GenericRepository<TrainingVideo>, ITrainingVideoRepository
    {
        public TrainingVideoRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<TrainingVideoDto> GetTrainingVideoForView(int Id)
        {
            var ratings = await _context.TrainingVideo.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<TrainingVideoDto>(ratings);
            }
            return new TrainingVideoDto();
        }

        public async Task<TrainingVideoDto> GetTrainingVideoForEdit(TrainingVideoDto input)
        {
            var users = await _context.Role.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                TrainingVideo trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<TrainingVideo>(input);
                _context.TrainingVideo.Update(trainingVideoDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<TrainingVideoDto>(trainingVideoDto);
            }
            return new TrainingVideoDto();
        }

        public async Task<int> DeleteTrainingVideo(int Id)
        {
            var roles = await _context.Role.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (roles != null)
            {
                _context.Role.Remove(roles);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditTrainingVideo(TrainingVideoDto input)
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

        protected virtual async Task Create(TrainingVideoDto input)
        {
            TrainingVideo trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<TrainingVideo>(input);
            _context.TrainingVideo.Add(trainingVideoDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(TrainingVideoDto input)
        {
            var trainingVideo = await _context.TrainingVideo.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (trainingVideo != null)
            {
                TrainingVideo trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<TrainingVideo>(input);
                _context.TrainingVideo.Update(trainingVideoDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<TrainingVideoDto> GetAllTrainingVideo(TrainingVideoDto input)
        {
            var query = (from trainingVideo in _context.TrainingVideo.ToList()
                         join trainingCatgeory in _context.TrainingCategory.ToList()
                              on trainingVideo.Id equals trainingCatgeory.Id
                         join videoCategory in _context.VideoCategory.ToList()
                         on trainingVideo.Id equals videoCategory.Id
                         select new TrainingVideoDto
                         {
                             CloudFolder = trainingVideo.CloudFolder,
                             CloudKey = trainingVideo.CloudKey,
                             ImagePath = trainingVideo.ImagePath,
                             DateCreated = trainingVideo.DateCreated,
                             Status = trainingVideo.Status,
                             UserId = trainingVideo.UserId,
                             VideoCategoryName = videoCategory.Name,
                             TrainingCatgeoryName = trainingCatgeory.Name

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<TrainingVideoDto> trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<List<TrainingVideoDto>>(query);

            //Apply Sort
            trainingVideoDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, trainingVideoDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                trainingVideoDto = trainingVideoDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TrainingCatgeoryName != null && p.TrainingCatgeoryName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.VideoCategoryName != null && p.VideoCategoryName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.ImagePath != null && p.ImagePath.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudFolder != null && p.CloudFolder.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudKey != null && p.CloudKey.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();
            }
            return trainingVideoDto;

        }



       

        public List<TrainingVideoDto> Sort(string order, string orderDir, List<TrainingVideoDto> data)
        {
            // Initialization.
            List<TrainingVideoDto> lst = new List<TrainingVideoDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CloudFolder).ToList()
                                                                                                 : data.OrderBy(p => p.CloudFolder).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CloudKey).ToList()
                                                                                                 : data.OrderBy(p => p.CloudKey).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ImagePath).ToList()
                                                                                                 : data.OrderBy(p => p.ImagePath).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TrainingCatgeoryName).ToList()
                                                                                                 : data.OrderBy(p => p.TrainingCatgeoryName).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VideoCategoryName).ToList()
                                                                                                 : data.OrderBy(p => p.VideoCategoryName).ToList();
                        break;


                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TrainingCatgeoryName).ToList()
                                                                                                 : data.OrderBy(p => p.TrainingCatgeoryName).ToList();
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
