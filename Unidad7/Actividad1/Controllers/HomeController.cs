using Actividad1.Gestion;
using Actividad1.Models;
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
            ViewData["MensajeSaludo"] = Utilidad.obtenerMensaje();
            ViewBag.fechaActual = DateTime.Now.ToString();

            ClsPersona persona = new ClsPersona("Alejandro", "Ruiz");

            return View(persona);
        }
    }
}