using RepositoryPattern.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DataAccess.Interfaces.Entities
{
    public interface IAuthorRepository : IGenericRepository<Author, int>
    {
    }
}
