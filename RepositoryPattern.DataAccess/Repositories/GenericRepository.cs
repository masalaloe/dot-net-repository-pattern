using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DataAccess.InMemory;
using RepositoryPattern.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();

        public async Task<IQueryable<T>> GetAllAsync() => await Task.Run(() => _context.Set<T>().AsNoTracking());
        
        public IQueryable<T> GetAll() => _context.Set<T>().AsNoTracking();
        
        public async Task CreateAsync(T entity) => await Task.Run(() => _context.Set<T>().Add(entity));
        
        public void Create(T entity) => _context.Set<T>().Add(entity);
        
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Delete(TKey id)
        {
            var entity = this.GetById(id);
            if(entity is not null) _context.Set<T>().Remove(entity);
        }
        
        public async Task<T?> GetByIdAsync(TKey id) => await _context.Set<T>().FindAsync(id);
        
        public T? GetById(TKey id) => _context.Set<T>().Find(id);

        public async Task UpdateAsync(T entity) => await Task.Run(() => _context.Set<T>().Update(entity));
        
        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
