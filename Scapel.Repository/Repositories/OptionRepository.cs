using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.OptionAggregate;
using Scapel.Domain.OptionAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        public OptionRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Option> GetOptionById(int Id)
        {
            return _context.Option.Where(x => x.Id == Id);
        }

    }
}
