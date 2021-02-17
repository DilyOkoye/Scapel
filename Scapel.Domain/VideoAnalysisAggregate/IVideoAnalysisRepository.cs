using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;

namespace Scapel.Domain.VideoAnalysisAggregate
{
   
    public interface IVideoAnalysisRepository : IGenericRepository<VideoAnalysis>
    {
        Task<VideoAnalysisDto> GetVideoAnalysisForView(int Id);
        Task CreateOrEditVideoAnalysis(VideoAnalysisDto input);
        Task<VideoAnalysisDto> GetVideoAnalysisForEdit(VideoAnalysisDto input);
        Task<int> DeleteVideoAnalysis(int Id);
        List<VideoAnalysisDto> GetAllVideoAnalysis(VideoAnalysisDto input);
    }
}
