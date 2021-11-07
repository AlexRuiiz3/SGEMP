using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace Actividad3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Editar()
        {
            ClsPersona persona = new ClsPersona("Alejandro","Ruiz",20);
            return View(persona);
        }
        [HttpPost]
        public ActionResult Editar(ClsPersona persona)
        {
            return View("PersonaModificada",persona);
        }
    }
}