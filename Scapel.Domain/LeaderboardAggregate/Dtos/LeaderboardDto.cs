using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.LeaderboardAggregate.Dtos
{
    public class LeaderboardDto
    {
        public int? Id { get; set; }
        public decimal? Score { get; set; }
        public int? TopicId { get; set; }
        public int? QuestionCategoryId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string TopicName { get; set; }
        public string QuestionCategoryName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
