﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entity.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; } = "";

        public virtual ICollection<Book> Books { get; set; }
    }
}
