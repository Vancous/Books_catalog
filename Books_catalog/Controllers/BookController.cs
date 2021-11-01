using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_catalog.Controllers
{
    public class BookController : Controller
    {
        public readonly BookRepository _book;
        public BookController()
        {
            _book = new BookRepository();
        }

        [HttpGet]
        public async Task< ActionResult> Index()
        {
           var book = await _book.GetBooks();
            return View(book);
        }

        [HttpPost]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutorForBook()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteBook()
        {
            return RedirectToAction("Index");
        }
    }
}
