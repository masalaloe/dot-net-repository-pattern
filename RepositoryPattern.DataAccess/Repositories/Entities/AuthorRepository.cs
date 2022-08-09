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
    public class AuthorRepository : GenericRepository<Author, int>, IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
