using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.AssessmentAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.AssessmentAggregate
{
    public interface IAssessmentRepository : IGenericRepository<Assessment>
    {
        Task<AssessmentDto> GetAssessmentForView(int Id);
        Task CreateOrEditAssessment(AssessmentDto input);
        Task<AssessmentDto> GetAssessmentForEdit(AssessmentDto input);
        Task<int> DeleteAssessment(int Id);
        List<AssessmentDto> GetAllAssessment(AssessmentDto input);
        
        
    }
}
