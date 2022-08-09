using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();

        IQueryable<T> GetAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        
        Task<T?> GetByIdAsync(TKey id);

        T? GetById(TKey id);
        
        Task CreateAsync(T entity);

        void Create(T entity);

        Task UpdateAsync(T entity);
        
        void Update(T entity);

        void Delete(T entity);

        void Delete(TKey id);
    }   
}
