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
            ClsPlantasVM clsPlantasVM = new ClsPlantasVM(GestoraPlantas.obtenerNombresPlantas(),"");

            return View(clsPlantasVM);
        }

        [HttpPost]
        public ActionResult Plantas(String nombre)
        {
            ClsPlantasVM clsPlantasVM = new ClsPlantasVM(GestoraPlantas.obtenerNombresPlantas(),
                                                         GestoraPlantas.obtenerDetallesPlanta(nombre));

            return View(clsPlantasVM);
        }
    }
}