using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entity.Models
{
    public class Book
    {
        public int BookId { get; set; }
        
        public string Name { get; set; }

        public virtual Author Author { get; set; }
    }
}
