using RepositoryPattern.DataAccess.InMemory;
using RepositoryPattern.DataAccess.Interfaces.Entities;
using RepositoryPattern.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Repositories.Entities
{
    public class BookRepository : GenericRepository<Book, int>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await Task.Run(() => _context.Set<Book>().Where(b => b.AuthorId == authorId));
        }
    }
}
