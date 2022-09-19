using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
       where TEntity : BaseEntity
        where TContext : DbContext
       
    {
        
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        // #region Fields

        protected TContext Context { get; }

        #region Public Methods

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetById(int id) =>
            await Context.Set<TEntity>().FindAsync(id);

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
           await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<TEntity>().CountAsync();

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().CountAsync(predicate);

        public async Task<int> SaveAsync() 
        {
            return await Context.SaveChangesAsync(); 
        }

        public  TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return  Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? Context.Set<TEntity>().ToList()
                    : Context.Set<TEntity>().Where(filter).ToList();
        }








        #endregion

    }
}
