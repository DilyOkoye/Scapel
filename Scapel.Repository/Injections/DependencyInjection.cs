using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.Repositories;

namespace Scapel.Repository.Injections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

           
            return services;

        }
    }
}
