using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actividad2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]//Aqui se llama siempre que se pulse un submit
        public ActionResult Index(String nombre)
        {
            ViewBag.Nombre = nombre;

            return View("Saludo");
        }

    }   
}