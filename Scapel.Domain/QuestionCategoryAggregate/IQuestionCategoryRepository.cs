using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;

namespace Scapel.Domain.QuestionCategoryAggregate
{

    public interface IQuestionCategoryRepository : IGenericRepository<QuestionCategory>
    {

        Task<QuestionCategoryDto> GetQuestionCategoryForView(int Id);
        Task CreateOrEditQuestionCategory(QuestionCategoryDto input);
        Task<QuestionCategoryDto> GetQuestionCategoryForEdit(QuestionCategoryDto input);
        Task<int> DeleteQuestionCategory(int Id);
        List<QuestionCategoryDto> GetAllQuestionCategory(QuestionCategoryDto input);
    }

}
