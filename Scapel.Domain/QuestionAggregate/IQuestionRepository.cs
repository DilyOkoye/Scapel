using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionAggregate.Dtos;

namespace Scapel.Domain.QuestionAggregate
{

    public interface IQuestionRepository : IGenericRepository<Question>
    {
        IEnumerable<Question> GetQuestionById(int Id);
    }
}
