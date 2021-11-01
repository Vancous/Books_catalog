using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;

namespace Books_catalog
{
    public class AutorRepositotory
    {
        private static List<Autor> _autors;
        public AutorRepositotory()
        {
            _autors = new List<Autor>();
        }

        public async Task<List<Autor>> GetBooks()
        {
            return await Task.Run(() => _autors);
        }

        public async Task<Autor> GetBook(int id)
        {
            return await Task.Run(() => _autors.FirstOrDefault(f => f.Id == id));
        }


        public async void DeleteAutor(int id)
        {
           await Task.Run(() => _autors.RemoveAll(f => f.Id == id));
        }
        public async Task<Autor> AddBook(Autor autor)
        {
            _autors.Add(autor);
            return autor;
        }
    }
}
