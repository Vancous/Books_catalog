using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_catalog.Models;
namespace Books_catalog.Controllers
{
    public class AutorController : Controller
    {
        ApplicationContext ApplicationContext;
        public readonly AutorRepositotory _autor;


        public AutorController(ApplicationContext context)
        {
            ApplicationContext = context;
            _autor = new AutorRepositotory(ApplicationContext);
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var autor = await _autor.GetAutors();
            return View(autor);
        }


        /*[HttpPost]*/
        public ActionResult AddAutor(string surname)
        {
            if (surname == null)
            {
                return View();
            }
            Autor autor = new Autor();
            autor.suname = surname;
            var result = _autor.AddAutor(autor);
            return RedirectToAction("Index", "Autor");
        }

        [HttpPost]
        public ActionResult EditAutor()
        {
            return View();
        }

        public ActionResult BooksSomeAutor(int id_autor)
        {
            if (id_autor == 0)
            {
                List<Autor> autors = ApplicationContext.Autors.ToList();
                return View(autors);
            }
            return RedirectToAction("BookResult","Autor", new { id = id_autor });
        }
        public async Task<ActionResult> BookResult(int id)
        {
           var autor = await _autor.GetAutorBook(id);
            return View(autor);
        }
       /* [HttpDelete]*/
        public ActionResult DeleteAutor(int id)
        {
            if (id == 0)
            {
                return View();
            }
            _autor.DeleteAutor(id);
            return RedirectToAction("Index", "Autor");
        }
    }
}
