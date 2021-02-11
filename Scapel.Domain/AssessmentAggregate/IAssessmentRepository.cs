using System;
using System.Collections.Generic;
using Scapel.Domain.AssessmentAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.AssessmentAggregate
{  

    public interface IAssessmentRepository : IGenericRepository<Assessment>
    {
        IEnumerable<Assessment> GetAssessmentById(int Id);
    }
}
