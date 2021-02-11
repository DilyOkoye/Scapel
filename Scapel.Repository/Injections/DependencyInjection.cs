using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;
using Scapel.Repository.Repositories;

namespace Scapel.Repository.Injections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IAssessmentRepository, AssessmentRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ILeaderboardRepository, LeaderboardRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionCategoryRepository, QuestionCategoryRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ITopicCategoryRepository, TopicCategoryRepository>();
            services.AddTransient<ITrainingCategoryRepository, TrainingCategoryRepository>();
            services.AddTransient<ITrainingVideoRepository, TrainingVideoRepository>();
            services.AddTransient<IVideoAnalysisRepository, VideoAnalysisRepository>();
            services.AddTransient<IVideoCategoryRepository, VideoCategoryRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Auto Mapper Configurations
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            return services;

        }
    }
}
