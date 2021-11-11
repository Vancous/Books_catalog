using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;

namespace Books_catalog.Controllers
{
    public class BookController : Controller
    {
        ApplicationContext ApplicationContext;   
        public readonly BookRepository _book;
        public BookController(ApplicationContext context)
        {
            ApplicationContext = context;
            _book = new BookRepository(ApplicationContext);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
           var book = await _book.GetBooks();
            return View(book);
        }

        /*[HttpPost]*/
        public ActionResult AddBook(string title, string yer, int id_autor)
        {

            if (title == null)
            {
                List<Autor> autors = ApplicationContext.Autors.ToList();
                return View(autors);
            }
            Book book = new Book();
            book.title = title;
            book.yer = yer;
            var result = _book.AddBook(book, id_autor);
            if(result != null)
            {
                BookAutor bookAutor = new BookAutor();
                bookAutor.autor_id = id_autor;
                bookAutor.book_id = result.Result.Id;
                    
              var t = _book.AddAutorForBook(bookAutor);
            }
            
            return RedirectToAction("Index", "Book");
            
        }

        /*[HttpPost]*/
        public ActionResult AddAutorForBook(int autor_id, int book_id)
        {
            if (autor_id == 0 || book_id == 0)
            {
                return View();
            }
            BookAutor bookAutor = new BookAutor();
            bookAutor.autor_id = autor_id;
            bookAutor.book_id = book_id;
           var result = _book.AddAutorForBook(bookAutor);
            return RedirectToAction("Index", "Book");
        }

        public ActionResult InfomOfBook(int book_id)
        {
            if (book_id == 0)
            {
                List<Book> books = ApplicationContext.Books.ToList();
                return View(books);
            }
            return RedirectToAction("IformResult","Book", new {id = book_id });
        }
        public ActionResult IformResult(int id)
        {
            var book = _book.GetBook(id);
            List<BookAutor> autors = ApplicationContext.BA.Where(f => f.book_id == id).ToList();
            List<Autor> autors1 = new List<Autor>();
            string ListOfAutors = "";
            for (int i = 0; i < autors.Count; i++)
            {
                var autorsbook = ApplicationContext.Autors.Where(f => f.Id == autors[i].autor_id).FirstOrDefault();
                autors1.Add(autorsbook);
                ListOfAutors += autorsbook.suname + " ";
            }

            List<string> info = new List<string>();
            info.Add(id.ToString());
            info.Add(book.Result.title.ToString());
            info.Add(ListOfAutors);
            return View(info);
        }
       /* [HttpDelete]*/
        public ActionResult DeleteBook(int id)
        {
           
            var result = _book.DeleteBook(id);
            
                return View();
            
           
            
        }
    }
}
