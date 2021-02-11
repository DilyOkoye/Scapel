using System;
namespace Scapel.Domain.RatingAggregate.Dtos
{
    public class Rating
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public int? RatingCount { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
