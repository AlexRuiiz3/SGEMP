using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actividad1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saludo(String nombre,String apellido)
        {
            ViewBag.nombre = nombre;
            ViewBag.apellido = apellido;
            return View();
        }
    }
}