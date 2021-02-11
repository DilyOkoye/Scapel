using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.VideoAnalysisAggregate;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;

namespace Scapel.Repository.Repositories
{
    
    public class VideoAnalysisRepository : GenericRepository<VideoAnalysis>, IVideoAnalysisRepository
    {
        public VideoAnalysisRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<VideoAnalysis> GetVideoAnalysisById(int Id)
        {
            return _context.VideoAnalysis.Where(x => x.Id == Id);
        }

    }
}
