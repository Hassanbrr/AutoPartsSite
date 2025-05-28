using System.Linq.Expressions;

namespace AutoPartsSite.Repository.Modules.Base.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
