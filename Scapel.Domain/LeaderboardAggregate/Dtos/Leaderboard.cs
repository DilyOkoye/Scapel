using System;
namespace Scapel.Domain.LeaderboardAggregate.Dtos
{
    public partial class Leaderboard
    {
        public int Id { get; set; }
        public decimal? Score { get; set; }
        public int? TopicId { get; set; }
        public int? QuestionCategoryId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
