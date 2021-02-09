using System;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Domain.UserProfileAggregate.Dtos;

namespace Scapel.Repository.DatabaseContext
{
    public class ScapelContext : DbContext
    {
        public ScapelContext(DbContextOptions<ScapelContext> options) : base(options)
        { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}
