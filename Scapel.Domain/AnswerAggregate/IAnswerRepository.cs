using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.AnswerAggregate
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<AnswerDto> GetAnswerForView(int Id);
        Task CreateOrEditAnswer(AnswerDto input);
        Task<AnswerDto> GetAnswerForEdit(AnswerDto input);
        Task<int> DeleteAnswer(int Id);
        List<AnswerDto> GetAllAnswer(AnswerDto input);

    }
}
