using System.Linq.Expressions;

namespace AutoPartsSite.Repository.Modules.Base.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    // در صورت نیاز، متد ذخیری مثل SaveChangesAsync را نیز می‌توان اضافه کرد.
}
