using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingVideoAggregate.Dtos;

namespace Scapel.Domain.TrainingVideoAggregate
{

    public interface ITrainingVideoRepository : IGenericRepository<TrainingVideo>
    {
        IEnumerable<TrainingVideo> GetTrainingVideoById(int Id);
    }
}
