using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_catalog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index_Start()
        {
            return View();
        }
    }
}
