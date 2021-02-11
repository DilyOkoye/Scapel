using System;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Domain.AssessmentAggregate.Dtos;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.LeaderboardAggregate.Dtos;
using Scapel.Domain.OptionAggregate.Dtos;
using Scapel.Domain.QuestionAggregate.Dtos;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Domain.RoleAggregate.Dtos;
using Scapel.Domain.TagAggregate.Dtos;
using Scapel.Domain.TopicAggregate.Dtos;
using Scapel.Domain.TopicCategoryAggregate.Dtos;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;
using Scapel.Domain.TrainingVideoAggregate.Dtos;
using Scapel.Domain.UserProfileAggregate.Dtos;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;
using Scapel.Domain.VideoCategoryAggregate.Dtos;
using Scapel.Domain.VoteAggregate.Dtos;

namespace Scapel.Repository.DatabaseContext
{
    public class ScapelContext : DbContext
    {
        public ScapelContext(DbContextOptions<ScapelContext> options) : base(options)
        { }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Assessment> Assessment { get; }
        public DbSet<Comment> Comment { get; }
        public DbSet<Leaderboard> Leaderboard { get; }
        public DbSet<Option> Option { get; }
        public DbSet<Question> Question { get; }
        public DbSet<QuestionCategory> QuestionCategory { get; }
        public DbSet<Rating> Rating { get; }
        public DbSet<Role> Role { get; }
        public DbSet<Tag> Tag { get; }
        public DbSet<Topic> Topic { get; }
        public DbSet<TopicCategory> TopicCategory { get; }
        public DbSet<TrainingCategory> TrainingCategory { get; }
        public DbSet<TrainingVideo> TrainingVideo { get; }
        public DbSet<VideoAnalysis> VideoAnalysis { get; }
        public DbSet<VideoCategory> VideoCategory { get; }
        public DbSet<Vote>Vote { get; }

    }
}
