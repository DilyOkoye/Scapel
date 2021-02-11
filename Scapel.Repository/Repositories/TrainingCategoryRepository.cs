using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.TrainingCategoryAggregate;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    

    public class TrainingCategoryRepository : GenericRepository<TrainingCategory>, ITrainingCategoryRepository
    {
        public TrainingCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<TrainingCategory> GetTrainingCategoryById(int Id)
        {
            return _context.TrainingCategory.Where(x => x.Id == Id);
        }

    }
}
