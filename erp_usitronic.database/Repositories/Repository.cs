using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel, new()
    {
        protected readonly ApiDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApiDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<List<TEntity>> FindAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.AsNoTracking().Where(x => x.Id == id).FirstAsync();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(int id)
        {
            var entity = await Find(x => x.Id == id);
            await Remove(entity.First());
        }

        public virtual async Task Remove(TEntity entity)
        {
            var person = Db.Entry(entity);
            await person.ReloadAsync();
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<TEntity> GetByIdAsNoTracking(int id)
        {
            return await DbSet.AsNoTracking().FirstAsync(t => t.Id == id);
        }
    }
}
