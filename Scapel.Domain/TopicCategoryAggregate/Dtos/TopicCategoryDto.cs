using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.TopicCategoryAggregate.Dtos
{
    public class TopicCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string CloudKey { get; set; }
        public string CloudFolder { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
