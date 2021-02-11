using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TrainingVideoAggregate;
using Scapel.Domain.TrainingVideoAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    
    

    public class TrainingVideoRepository : GenericRepository<TrainingVideo>, ITrainingVideoRepository
    {
        public TrainingVideoRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<TrainingVideo> GetTrainingVideoById(int Id)
        {
            return _context.TrainingVideo.Where(x => x.Id == Id);
        }

    }


}
