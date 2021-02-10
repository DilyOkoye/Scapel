using System;
namespace Scapel.Domain.VideoCategoryAggregate.Dtos
{
    public class VideoCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
