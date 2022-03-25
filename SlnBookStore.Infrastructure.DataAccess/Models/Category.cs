using System;
using System.Collections.Generic;

namespace SlnBookStore.Infrastructure.DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public string Id { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
