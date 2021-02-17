using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.VideoAnalysisAggregate;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;
using System.Threading.Tasks;
using Scapel.Domain.TrainingVideoAggregate.Dtos;
using Microsoft.EntityFrameworkCore;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    
    public class VideoAnalysisRepository : GenericRepository<VideoAnalysis>, IVideoAnalysisRepository
    {
        public VideoAnalysisRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<VideoAnalysisDto> GetVideoAnalysisForView(int Id)
        {
            var ratings = await _context.VideoAnalysis.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<VideoAnalysisDto>(ratings);
            }
            return new VideoAnalysisDto();
        }

        public async Task<VideoAnalysisDto> GetVideoAnalysisForEdit(VideoAnalysisDto input)
        {
            var users = await _context.Role.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                TrainingVideo trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<TrainingVideo>(input);
                _context.TrainingVideo.Update(trainingVideoDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<VideoAnalysisDto>(trainingVideoDto);
            }
            return new VideoAnalysisDto();
        }

        public async Task<int> DeleteVideoAnalysis(int Id)
        {
            var roles = await _context.Role.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (roles != null)
            {
                _context.Role.Remove(roles);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditVideoAnalysis(VideoAnalysisDto input)
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

        protected virtual async Task Create(VideoAnalysisDto input)
        {
            VideoAnalysis videoAnalysisDto = MappingProfile.MappingConfigurationSetups().Map<VideoAnalysis>(input);
            _context.VideoAnalysis.Add(videoAnalysisDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(VideoAnalysisDto input)
        {
            var videoAnalysis = await _context.VideoAnalysis.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (videoAnalysis != null)
            {
                VideoAnalysis videoAnalysisDto = MappingProfile.MappingConfigurationSetups().Map<VideoAnalysis>(input);
                _context.VideoAnalysis.Update(videoAnalysisDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<VideoAnalysisDto> GetAllVideoAnalysis(VideoAnalysisDto input)
        {
            var query = (from videoAnalysis in _context.TrainingVideo.ToList()
                         join videoCategory in _context.VideoCategory.ToList()
                         on videoAnalysis.Id equals videoCategory.Id
                         select new VideoAnalysisDto
                         {
                             CloudFolder = videoAnalysis.CloudFolder,
                             CloudKey = videoAnalysis.CloudKey,
                             ImagePath = videoAnalysis.ImagePath,
                             DateCreated = videoAnalysis.DateCreated,
                             Status = videoAnalysis.Status,
                             UserId = videoAnalysis.UserId,
                             VideoCategoryName = videoCategory.Name,

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<VideoAnalysisDto> trainingVideoDto = MappingProfile.MappingConfigurationSetups().Map<List<VideoAnalysisDto>>(query);

            //Apply Sort
            trainingVideoDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, trainingVideoDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                trainingVideoDto = trainingVideoDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.VideoCategoryName != null && p.VideoCategoryName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.ImagePath != null && p.ImagePath.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudFolder != null && p.CloudFolder.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.CloudKey != null && p.CloudKey.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();
            }
            return trainingVideoDto;

        }





        public List<VideoAnalysisDto> Sort(string order, string orderDir, List<VideoAnalysisDto> data)
        {
            // Initialization.
            List<VideoAnalysisDto> lst = new List<VideoAnalysisDto>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VideoCategoryName).ToList()
                                                                                                 : data.OrderBy(p => p.VideoCategoryName).ToList();
                        break;

                  

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VideoCategoryName).ToList()
                                                                                                 : data.OrderBy(p => p.VideoCategoryName).ToList();
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
