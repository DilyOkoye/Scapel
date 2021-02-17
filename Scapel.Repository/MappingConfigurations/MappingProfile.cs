using System;
using System.Collections.Generic;
using AutoMapper;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Domain.RoleAggregate.Dtos;
using Scapel.Domain.TagAggregate.Dtos;
using Scapel.Domain.TopicAggregate.Dtos;
using Scapel.Domain.TopicCategoryAggregate.Dtos;
using Scapel.Domain.TrainingCategoryAggregate.Dtos;
using Scapel.Domain.TrainingVideoAggregate.Dtos;
using Scapel.Domain.UserProfileAggregate.Dtos;
using Scapel.Domain.VideoAnalysisAggregate.Dtos;

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

            });

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
