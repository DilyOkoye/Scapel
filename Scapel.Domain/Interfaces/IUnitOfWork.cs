using System;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AssessmentAggregate;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.LeaderboardAggregate;
using Scapel.Domain.OptionAggregate;
using Scapel.Domain.QuestionAggregate;
using Scapel.Domain.QuestionCategoryAggregate;
using Scapel.Domain.RatingAggregate;
using Scapel.Domain.RoleAggregate;
using Scapel.Domain.TagAggregate;
using Scapel.Domain.TopicAggregate;
using Scapel.Domain.TopicCategoryAggregate;
using Scapel.Domain.TrainingCategoryAggregate;
using Scapel.Domain.TrainingVideoAggregate;
using Scapel.Domain.UserProfileAggregate;
using Scapel.Domain.VideoAnalysisAggregate;
using Scapel.Domain.VideoCategoryAggregate;
using Scapel.Domain.VoteAggregate;

namespace Scapel.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IAnswerRepository Answers { get; }
         IAssessmentRepository Assessments { get; }
         ICommentRepository Commments { get; }
         ILeaderboardRepository Leaderboards { get; }
         IOptionRepository Options { get; }
         IQuestionRepository Questions { get; }
         IQuestionCategoryRepository QuestionCategorys{ get; }
         IRatingRepository Ratings { get; }
         IRoleRepository Roles { get; }
         ITagRepository Tags { get; }
         ITopicRepository Topics { get; }
         ITopicCategoryRepository TopicCategorys { get; }
         ITrainingCategoryRepository TrainingCategorys { get; }
         ITrainingVideoRepository TrainingVideos { get; }
         IUserProfileRepository UserProfiles { get; }
         IVideoAnalysisRepository VideoAnalysis { get; }
         IVideoCategoryRepository VideoCategory{ get; }
         IVoteRepository Votes { get; }
        int Complete();
    }
}
