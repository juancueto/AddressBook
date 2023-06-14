using System;
using System.Linq.Expressions;
using AddressBook.Domain.Common;

namespace AddressBook.Application.Contracts
{
	public interface IAsyncRepository<T> where T: EntityBase
	{
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null);        
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

