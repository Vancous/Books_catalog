using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_catalog.Controllers
{
    public class AutorController : Controller
    {
       

       
        public AutorController()
        {
           
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditAutor()
        {
            return View();
        }

        

        [HttpDelete]
        public ActionResult DeleteAutor()
        {
            return RedirectToAction("Index");
        }
    }
}
