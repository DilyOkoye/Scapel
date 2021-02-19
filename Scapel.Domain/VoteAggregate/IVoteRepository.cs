using System;
using System.Collections.Generic;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VoteAggregate.Dtos;
using System.Threading.Tasks;


namespace Scapel.Domain.VoteAggregate
{
  
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        Task<VoteDto> GetVoteForView(int Id);
        Task CreateOrEditVote(VoteDto input);
        Task<VoteDto> GetVoteForEdit(VoteDto input);
        Task<int> DeleteVote(int Id);
        List<VoteDto> GetAllVote(VoteDto input);
    }
}
