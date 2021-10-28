using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Books_catalog.Models
{
    public class ApplicationContext : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Autor> Autors { get; set; }
        DbSet<BookAutor> BA { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
