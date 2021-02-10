using System;
namespace Scapel.Domain.TrainingVideoAggregate.Dtos
{
    public class TrainingVideo
    {
        public int Id { get; set; }
        public int? TrainingCategory { get; set; }
        public int? VideoCategory { get; set; }
        public string ImagePath { get; set; }
        public string CloudKey { get; set; }
        public string CloudFolder { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
