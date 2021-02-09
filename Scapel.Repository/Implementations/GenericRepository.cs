using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.Interfaces;
using Scapel.Repository.DatabaseContext;

namespace Scapel.Repository.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ScapelContext _context;

        protected GenericRepository(ScapelContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
