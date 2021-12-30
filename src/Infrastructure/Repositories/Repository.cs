using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Abstractions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T,K> : IRepository<T,K> , IDisposable where T : BaseEntity<K>
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<ICollection<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> FindSingleAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<T?> FindSingleAsync(K id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            var queryable = GetAll();
            //foreach (var includeProperty in includeProperties)
            //{
            //    queryable = queryable.Include<T, object>(includeProperty);
            //}
            //return queryable;
            return includeProperties.
                Aggregate(queryable, (current, includeProperty) =>
                    current.Include(includeProperty));
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T?> UpdateAsync(T? entity, K id)
        {
            var existEntity = await _context.Set<T>().FindAsync(id);
            if (existEntity != null)
            {
                if (entity != null) _context.Entry(existEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existEntity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}