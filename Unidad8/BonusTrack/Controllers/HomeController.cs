using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusTrack.Models;
using Dal;

namespace BonusTrack.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Plantas()
        {
            return View(new PlantasVM());
        }

        [HttpPost]
        public ActionResult Plantas(String selectPlantas)
        {
            GestoraPlantas gestoraPlantas = new GestoraPlantas();
            return View(new PlantasVM(gestoraPlantas.obtenerDetallesPlanta(selectPlantas)));
        }
    }
}