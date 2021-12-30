using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T, K> where T : class
    {
        Task<T> AddAsync(T t);
        Task<int> CountAsync();
        Task<int> DeleteAsync(T entity);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match);
        Task<T?> FindSingleAsync(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> FindAllAsync();
        Task<T?> FindSingleAsync(K id);
        Task<int> SaveAsync();
        Task<T?> UpdateAsync(T? t, K id);
        void Dispose();
    }
}
