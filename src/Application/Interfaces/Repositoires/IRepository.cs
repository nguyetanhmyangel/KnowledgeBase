using System.Linq.Expressions;

namespace Application.Interfaces.Repositoires
{
    public interface IAppCommandFunctionRepository<T, K> where T : class
    {
        Task<T> FindByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAllAsync(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task RemoveAsync(K id);

        Task RemoveMultipleAsync(List<T> entities);
    }
}
