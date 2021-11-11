using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Books_catalog.Models
{
    public class ApplicationContext : DbContext
    {
      
        public DbSet<Book> Books { get; set; }
      public  DbSet<Autor> Autors { get; set; }
       public DbSet<BookAutor> BA { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            /*Database.EnsureCreated();*/
        }

       
    }
}
