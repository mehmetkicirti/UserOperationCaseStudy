using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Domain.Abstract;

namespace UserOperationCaseStudy.Common.Repository
{
    public class BaseGenericRepository<T, TContext> : IGenericRepository<T>
        where T : BaseEntity
        where TContext: DbContext, new()
    {
        protected DbSet<T> Entity { get; }
        private TContext Context { get; }
        public BaseGenericRepository(TContext context)
        {
            Context = context;
            Entity = context.Set<T>();
        }

        #region Sync Ops.
        public IQueryable<T> AsQueryable() => Entity.AsQueryable();

        public int Delete(T entity)
        {
            Context.Remove(entity);
            return Context.SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool isTracking = true) => GetQuery(isTracking).Where(predicate);
        
        public int Update(T entity)
        {
            Context.Update(entity);
            return Context.SaveChanges();
        }
        #endregion

        #region Async Ops.
        public async Task<IList<T>> GetAllAsync(bool isTracking = true) => await GetQuery(isTracking).ToListAsync();
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool isTracking = true) => await GetQuery(isTracking).Where(predicate).ToListAsync();
        public async Task<T> GetByIdAsync(string id, bool isTracking = true) => await GetQuery(isTracking).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        public async Task<int> AddAsync(T entity)
        {
            await Context.AddAsync(entity);
            return await Context.SaveChangesAsync();
        }
        #endregion

        #region Logics
        private IQueryable<T> GetQuery(bool isTracking)
        {
            var query = AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        #endregion
    }
}
