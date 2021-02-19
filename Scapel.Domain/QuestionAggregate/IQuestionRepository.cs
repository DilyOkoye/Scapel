using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionAggregate.Dtos;

namespace Scapel.Domain.QuestionAggregate
{

    public interface IQuestionRepository : IGenericRepository<Question>
    {
       
        Task<QuestionDto> GetQuestionForView(int Id);
        Task CreateOrEditQuestion(QuestionDto input);
        Task<QuestionDto> GetQuestionForEdit(QuestionDto input);
        Task<int> DeleteQuestion(int Id);
        List<QuestionDto> GetAllQuestion(QuestionDto input);
    }
}
