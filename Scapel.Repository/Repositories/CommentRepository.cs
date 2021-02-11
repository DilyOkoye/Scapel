using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;

namespace Scapel.Repository.Repositories
{
    

    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ScapelContext context) : base(context)
        {

        }

        public IEnumerable<Comment> GetCommentById(int Id)
        {
            return _context.Comment.Where(x => x.Id == Id);
        }

    }
}
