using System;
namespace Scapel.Domain.TagAggregate.Dtos
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TopicId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
