using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.Interfaces;

namespace Scapel.Domain.CommentAggregate
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

        Task<CommentDto> GetCommentForView(int Id);
        Task CreateOrEditComment(CommentDto input);
        Task<CommentDto> GetCommentForEdit(CommentDto input);
        Task<int> DeleteComment(int Id);
        List<CommentDto> GetAllComment(CommentDto input);

    }
}
