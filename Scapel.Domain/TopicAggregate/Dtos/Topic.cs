using System;
namespace Scapel.Domain.TopicAggregate.Dtos
{
    public class Topic
    {
        public int Id { get; set; }
        public int? TopicCategoryId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string CloudKey { get; set; }
        public string CloudFolder { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
