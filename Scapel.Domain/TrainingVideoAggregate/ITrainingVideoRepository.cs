using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingVideoAggregate.Dtos;

namespace Scapel.Domain.TrainingVideoAggregate
{

    public interface ITrainingVideoRepository : IGenericRepository<TrainingVideo>
    {
        Task<TrainingVideoDto> GetTrainingVideoForView(int Id);
        Task CreateOrEditTrainingVideo(TrainingVideoDto input);
        Task<TrainingVideoDto> GetTrainingVideoForEdit(TrainingVideoDto input);
        Task<int> DeleteTrainingVideo(int Id);
        List<TrainingVideoDto> GetAllTrainingVideo(TrainingVideoDto input);
    }
}
