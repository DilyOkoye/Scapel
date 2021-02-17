using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.VideoAnalysisAggregate.Dtos
{
    public class VideoAnalysisDto
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int? VideoCategory { get; set; }
        public string ImagePath { get; set; }
        public string CloudKey { get; set; }
        public string CloudFolder { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string VideoCategoryName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }

    }
}
