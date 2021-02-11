using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.TagAggregate;
using Scapel.Domain.TagAggregate.Dtos;

namespace Scapel.Repository.Repositories
{
    

    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Tag> GetTagById(int Id)
        {
            return _context.Tag.Where(x => x.Id == Id);
        }

    }
}
