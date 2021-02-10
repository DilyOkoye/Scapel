using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;

namespace Scapel.Domain.TrainingCategoryAggregate
{
   
    public interface ITrainingCategoryRepository : IGenericRepository<TrainingCategory>
    {
        IEnumerable<TrainingCategory> GetTrainingCategoryById(int Id);
    }
}
