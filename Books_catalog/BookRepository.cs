using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;

namespace Books_catalog
{
    public class BookRepository
    {
        private static List<Book> _books;
        public BookRepository()
        {
            _books = new List<Book>();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await Task.Run(() => _books);
        }

        public async Task<Book> GetBook (int id)
        {
            return await Task.Run(() => _books.FirstOrDefault(f => f.Id == id));
        }

        public async Task<Book> AddBook (Book book)
        {
           _books.Add(book);
            return book;
        }
    }
}
