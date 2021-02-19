using System;
using Scapel.Domain.Utilities;
namespace Scapel.Domain.TagAggregate.Dtos
{
    public class TagDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? TopicId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string TopicName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
