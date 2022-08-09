using RepositoryPattern.DataAccess.InMemory;
using RepositoryPattern.DataAccess.Interfaces;
using RepositoryPattern.DataAccess.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }

        public UnitOfWork(AppDbContext context,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository)
        {
            _context = context;
            Authors = authorRepository;
            Books = bookRepository;
        }
        
        public int SaveChanges() => _context.SaveChanges();
        
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
