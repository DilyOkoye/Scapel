using System;
namespace Scapel.Domain.VoteAggregate.Dtos
{
    public partial class Vote
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public int? UpVoteCount { get; set; }
        public int? DownVoteCount { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
