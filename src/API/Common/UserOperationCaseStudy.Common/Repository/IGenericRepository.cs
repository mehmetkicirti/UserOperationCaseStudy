using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Common.Domain.Abstract;

namespace UserOperationCaseStudy.Common.Repository
{
    public interface IGenericRepository<T>
        where T: BaseEntity
    {
        #region Async Ops.
        Task<int> AddAsync(T entity);
        Task<IList<T>> GetAllAsync(bool isTracking = true);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool isTracking = true);
        Task<T> GetByIdAsync(string id, bool isTracking = true);
        #endregion


        #region Sync Ops.
        int Update(T entity);
        int Delete(T entity);
        IQueryable<T> AsQueryable();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool isTracking = true);
        #endregion
    }
}
