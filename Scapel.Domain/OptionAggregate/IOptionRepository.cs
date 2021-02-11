using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.OptionAggregate.Dtos;

namespace Scapel.Domain.OptionAggregate
{
    
    public interface IOptionRepository : IGenericRepository<Option>
    {
        IEnumerable<Option> GetOptionById(int Id);
    }
}
