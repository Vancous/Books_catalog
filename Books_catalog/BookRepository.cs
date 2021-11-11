using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;

namespace Books_catalog
{
    public class BookRepository
    {
        public ApplicationContext ApplicationContext;
        private static List<Book> _books;
        public BookRepository(ApplicationContext ap)
        {
            _books = new List<Book>();

            this.ApplicationContext = ap;
        }

        public async Task<List<Book>> GetBooks()
        {
    
            _books =  ApplicationContext.Books.ToList();
            return await Task.Run(() => _books);
        }

        public async Task<Book> GetBook (int id)
        {
            _books = ApplicationContext.Books.ToList();
            return await Task.Run(() => _books.FirstOrDefault(f => f.Id == id));
        }

        public async Task<Book> AddBook (Book book, int autor_id)
        {
            ApplicationContext.Books.Add(book);
            ApplicationContext.SaveChanges();
            
            if (autor_id != 0)
            {
                return book;
            }
            book = null;
            return book;

           
        }
        public async Task<BookAutor> AddAutorForBook(BookAutor bookAutor)
        {
            
            ApplicationContext.BA.Add(bookAutor);
            ApplicationContext.SaveChanges();
            return bookAutor;
        }
        public async Task<Book> DeleteBook (int id)
        {
            var DelitsBook = ApplicationContext.Books.FirstOrDefault(f => f.Id == id);
            ApplicationContext.Books.Remove(DelitsBook);
            ApplicationContext.SaveChanges();

            return DelitsBook;
        }
        
    }
}
