using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.VoteAggregate.Dtos
{
    public class VoteDto
    {
        public int? Id { get; set; }
        public int? TopicId { get; set; }
        public int? UpVoteCount { get; set; }
        public int? DownVoteCount { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string TopicName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
