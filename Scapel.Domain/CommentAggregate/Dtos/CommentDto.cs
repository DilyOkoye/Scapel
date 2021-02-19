using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.CommentAggregate.Dtos
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int? TopicId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
        public string TopicName { get; set; }
    }
}
