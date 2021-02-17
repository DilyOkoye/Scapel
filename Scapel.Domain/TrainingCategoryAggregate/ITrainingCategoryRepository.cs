using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;

namespace Scapel.Domain.TrainingCategoryAggregate
{
   
    public interface ITrainingCategoryRepository : IGenericRepository<TrainingCategory>
    {

        Task<TrainingCategoryDto> GetTrainingCategoryForView(int Id);
        Task CreateOrEditTrainingCategory(TrainingCategoryDto input);
        Task<TrainingCategoryDto> GetTrainingCategoryForEdit(TrainingCategoryDto input);
        Task<int> DeleteTrainingCategory(int Id);
        List<TrainingCategoryDto> GetAllTrainingCategory(TrainingCategoryDto input);
    }
}
