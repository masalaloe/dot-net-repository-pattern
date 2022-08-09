using RepositoryPattern.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Interfaces.Entities
{
    public interface IBookRepository : IGenericRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
    }
}
