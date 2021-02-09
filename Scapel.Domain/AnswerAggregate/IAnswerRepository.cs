using System;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.AnswerAggregate
{   
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        IEnumerable<Answer> GetAnswerById(int Id);
    }
}
