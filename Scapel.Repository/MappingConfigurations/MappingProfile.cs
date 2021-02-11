using System;
using System.Collections.Generic;
using AutoMapper;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Domain.UserProfileAggregate.Dtos;

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
            });

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
