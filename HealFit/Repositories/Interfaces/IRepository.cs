using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HealFit.Repositories.Interfaces; 
public interface IRepository<T> {

    Task<IEnumerable<T>> GetAllAsync(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);
    Task<IQueryable<T>> GetAllQueryableAsync();
    // Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}
