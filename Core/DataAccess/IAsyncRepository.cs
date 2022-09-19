using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IAsyncRepository <T> : IQuery<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int Id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
       // IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        T Get(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync();

        List<T> GetAll(Expression<Func<T, bool>> filter = null);



    }
}
