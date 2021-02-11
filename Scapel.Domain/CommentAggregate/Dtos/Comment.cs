using System;
namespace Scapel.Domain.CommentAggregate.Dtos
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int? TopicId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
