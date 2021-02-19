using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.OptionAggregate.Dtos;

namespace Scapel.Domain.OptionAggregate
{

    public interface IOptionRepository : IGenericRepository<Option>
    {
        Task<OptionDto> GetOptionForView(int Id);
        Task CreateOrEditOption(OptionDto input);
        Task<OptionDto> GetOptionForEdit(OptionDto input);
        Task<int> DeleteOption(int Id);
        List<OptionDto> GetAllOption(OptionDto input);
    }
}
