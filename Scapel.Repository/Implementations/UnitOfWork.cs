using System;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate;
using Scapel.Repository.DatabaseContext;

namespace Scapel.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScapelContext _context;
        public IUserProfileRepository UserProfile { get; }
        public IAnswerRepository Answer { get; }

        public UnitOfWork(ScapelContext scapelContext,
            IUserProfileRepository userProfileRepository)
        {
            this._context = scapelContext;

            this.UserProfile = userProfileRepository;
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
