using System;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AssessmentAggregate;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.Interfaces;
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
using Scapel.Repository.DatabaseContext;

namespace Scapel.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScapelContext _context;
        public IUserProfileRepository UserProfiles { get; }
        public IAnswerRepository Answers { get; }
        public IAssessmentRepository Assessments { get; }
        public ICommentRepository Commments { get; }
        public ILeaderboardRepository Leaderboards { get; }
        public IOptionRepository Options { get; }
        public IQuestionRepository Questions { get; }
        public IQuestionCategoryRepository QuestionCategorys { get; }
        public IRatingRepository Ratings { get; }
        public IRoleRepository Roles { get; }
        public ITagRepository Tags { get; }
        public ITopicRepository Topics { get; }
        public ITopicCategoryRepository TopicCategorys { get; }
        public ITrainingCategoryRepository TrainingCategorys { get; }
        public ITrainingVideoRepository TrainingVideos { get; }
        public IVideoAnalysisRepository VideoAnalysis { get; }
        public IVideoCategoryRepository VideoCategory { get; }
        public IVoteRepository Votes { get; }

        public UnitOfWork(ScapelContext scapelContext,
             IUserProfileRepository userProfileRepository
            , IAnswerRepository answerRepository
            , IAssessmentRepository assessmentRepository
            , ICommentRepository commentRepository
            , ILeaderboardRepository leaderboardRepository
            , IOptionRepository optionRepository
            , IQuestionRepository questionRepository
            , IQuestionCategoryRepository questionCategoryRepository
            , IRatingRepository ratingRepository
            , IRoleRepository roleRepository
            , ITagRepository tagRepository
            , ITopicRepository topicRepository
            , ITopicCategoryRepository topicCategoryRepository
            , ITrainingCategoryRepository trainingCategoryRepository
            , ITrainingVideoRepository trainingVideoRepository
            , IVideoAnalysisRepository videoAnalysisRepository
            , IVideoCategoryRepository videoCategoryRepository
            , IVoteRepository voteRepository)
        {
            this._context = scapelContext;

            this.UserProfiles = userProfileRepository;
            this.Answers = answerRepository;
            this.Assessments = assessmentRepository;
            this.Commments = commentRepository;
            this.Leaderboards = leaderboardRepository;
            this.Options = optionRepository;
            this.Questions = questionRepository;
            this.QuestionCategorys = questionCategoryRepository;
            this.Ratings = ratingRepository;
            this.Roles = roleRepository;
            this.Tags = tagRepository;
            this.Topics = topicRepository;
            this.TopicCategorys = topicCategoryRepository;
            this.TrainingCategorys = trainingCategoryRepository;
            this.TrainingVideos = trainingVideoRepository;
            this.VideoAnalysis = videoAnalysisRepository;
            this.VideoCategory = videoCategoryRepository;
            this.Votes = voteRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
