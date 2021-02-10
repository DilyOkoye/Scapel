using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;

namespace Scapel.Domain.VideoAnalysisAggregate
{
   
    public interface IVideoAnalysisRepository : IGenericRepository<VideoAnalysis>
    {
        IEnumerable<VideoAnalysis> GetVideoAnalysisById(int Id);
    }
}
