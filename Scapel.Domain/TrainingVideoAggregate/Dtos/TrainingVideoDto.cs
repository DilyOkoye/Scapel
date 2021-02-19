using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.TrainingVideoAggregate.Dtos
{
    public class TrainingVideoDto
    {
        public int? Id { get; set; }
        public int? TrainingCategory { get; set; }
        public int? VideoCategory { get; set; }
        public string ImagePath { get; set; }
        public string CloudKey { get; set; }
        public string CloudFolder { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
        public string VideoCategoryName { get; set; }
        public string TrainingCatgeoryName { get; set; }

    }
}
