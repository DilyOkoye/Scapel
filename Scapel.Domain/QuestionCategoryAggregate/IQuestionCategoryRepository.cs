using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;

namespace Scapel.Domain.QuestionCategoryAggregate
{
   
    public interface IQuestionCategoryRepository : IGenericRepository<QuestionCategory>
    {
        IEnumerable<QuestionCategory> GetQuestionCategoryById(int Id);
    }

}
