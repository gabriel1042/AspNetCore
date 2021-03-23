using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetByIdAsNoTracking(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task Remove(int id);
        Task<List<TEntity>> FindAsNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
