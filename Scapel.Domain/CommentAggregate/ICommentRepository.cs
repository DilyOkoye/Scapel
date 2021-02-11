using System;
using System.Collections.Generic;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.CommentAggregate
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IEnumerable<Comment> GetCommentById(int Id);
    }
}
