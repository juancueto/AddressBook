using System;
using System.Linq.Expressions;
using AddressBook.Application.Contracts;
using AddressBook.Domain.Common;
using AddressBook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly AddressBookContext _dbContext;

        public BaseRepository(AddressBookContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

