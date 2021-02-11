using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.RatingAggregate.Dtos
{
    public class RatingDto
    {
        public int? Id { get; set; }
        public int? TopicId { get; set; }
        public string TopicName { get; set; }
        public int? RatingCount { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
