using System;
using System.Collections.Generic;
using AutoMapper;
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

namespace Scapel.Repository.MappingConfigurations
{
    public  class MappingProfile 
    {
        public static Mapper MappingConfigurationSetups()
        {
          
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfileDto, UserProfile>();
                cfg.CreateMap<UserProfile, UserProfileDto>();
                cfg.CreateMap<List<UserProfile>, List<UserProfileDto>>();
                //Rating
                cfg.CreateMap<RatingDto, Rating>();
                cfg.CreateMap<Rating, RatingDto>();
                cfg.CreateMap<List<Rating>, List<RatingDto>>();

                //Role
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<List<Role>, List<RoleDto>>();

                //Tag
                cfg.CreateMap<TagDto, Tag>();
                cfg.CreateMap<Tag, TagDto>();
                cfg.CreateMap<List<Tag>, List<TagDto>>();

                //Topic
                cfg.CreateMap<TopicDto, Topic>();
                cfg.CreateMap<Topic, TopicDto>();
                cfg.CreateMap<List<Topic>, List<TopicDto>>();

                //TopicCategory
                cfg.CreateMap<TopicCategoryDto, TopicCategory>();
                cfg.CreateMap<TopicCategory, TopicCategoryDto>();
                cfg.CreateMap<List<TopicCategory>, List<TopicCategoryDto>>();

                //TrainingCategory
                cfg.CreateMap<TrainingCategoryDto, TrainingCategory>();
                cfg.CreateMap<TrainingCategory, TrainingCategoryDto>();
                cfg.CreateMap<List<TrainingCategory>, List<TrainingCategoryDto>>();


                //TrainingVideo
                cfg.CreateMap<TrainingVideoDto, TrainingVideo>();
                cfg.CreateMap<TrainingVideo, TrainingVideoDto>();
                cfg.CreateMap<List<TrainingVideo>, List<TrainingVideoDto>>();

                //VideoAnalysis
                cfg.CreateMap<VideoAnalysisDto, VideoAnalysis>();
                cfg.CreateMap<VideoAnalysis, VideoAnalysisDto>();
                cfg.CreateMap<List<VideoAnalysis>, List<VideoAnalysisDto>>();

                //VideoCategory
                cfg.CreateMap<VideoCategoryDto, VideoCategory>();
                cfg.CreateMap<VideoCategory, VideoCategoryDto>();
                cfg.CreateMap<List<VideoCategory>, List<VideoCategoryDto>>();

                //Vote
                cfg.CreateMap<VoteDto, Vote>();
                cfg.CreateMap<Vote, VoteDto>();
                cfg.CreateMap<List<Vote>, List<VoteDto>>();


                //Answer
                cfg.CreateMap<AnswerDto, Answer>();
                cfg.CreateMap<Answer, AnswerDto>();
                cfg.CreateMap<List<Answer>, List<AnswerDto>>();


                //Assessment
                cfg.CreateMap<AssessmentDto, Assessment>();
                cfg.CreateMap<Assessment, AssessmentDto>();
                cfg.CreateMap<List<Assessment>, List<AssessmentDto>>();


                //Comment
                cfg.CreateMap<CommentDto, Comment>();
                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<List<Comment>, List<CommentDto>>();


                //Leaderboard
                cfg.CreateMap<LeaderboardDto, Leaderboard>();
                cfg.CreateMap<Leaderboard, LeaderboardDto>();
                cfg.CreateMap<List<Leaderboard>, List<LeaderboardDto>>();


                //Option
                cfg.CreateMap<OptionDto, Option>();
                cfg.CreateMap<Option, OptionDto>();
                cfg.CreateMap<List<Option>, List<OptionDto>>();


                //QuestionCategory
                cfg.CreateMap<QuestionCategoryDto, QuestionCategory>();
                cfg.CreateMap<QuestionCategory, QuestionCategoryDto>();
                cfg.CreateMap<List<QuestionCategory>, List<QuestionCategoryDto>>();


                //Question
                cfg.CreateMap<QuestionDto, Question>();
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<List<Question>, List<QuestionDto>>();


            });

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
