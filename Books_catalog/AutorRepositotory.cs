using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;

namespace Books_catalog
{
    public class AutorRepositotory
    {
        ApplicationContext ApplicationContext;
        private static List<Autor> _autors;
        public AutorRepositotory(ApplicationContext context)
        {
            ApplicationContext = context;
            _autors = new List<Autor>();
        }

        public async Task<List<Autor>> GetAutors()
        {
            _autors = ApplicationContext.Autors.ToList();
            return await Task.Run(() => _autors);
        }

        public async Task<Autor> GetAutor(int id)
        {
            return await Task.Run(() => _autors.FirstOrDefault(f => f.Id == id));
        }
        public async Task<List<Book>> GetAutorBook(int id)
        {
          List<BookAutor> autor =  ApplicationContext.BA.Where(f => f.autor_id == id).ToList();
            List<Book> book = new List<Book>();
            for (int i = 0; i < autor.Count; i++)
            {
                var someBook = ApplicationContext.Books.Where(f => f.Id == autor[i].book_id).FirstOrDefault();
                book.Add(someBook);
            }
            return book;
        }

        public async void DeleteAutor(int id)
        {
            var DelitsAutor =  ApplicationContext.Autors.FirstOrDefault(f => f.Id == id);
            ApplicationContext.Autors.Remove(DelitsAutor);
            ApplicationContext.SaveChanges();
           
        }
        public async Task<Autor> AddAutor(Autor autor)
        {
            
           ApplicationContext.Autors.Add(autor);
            ApplicationContext.SaveChanges();
            return autor;
        }
    }
}
