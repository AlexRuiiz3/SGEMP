using Actividad1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewData["MensajeSaludo"] = Utilidad.obtenerMensaje();
            ViewBag.fechaActual = DateTime.Now.ToString();

            return View();
        }

    }
}
