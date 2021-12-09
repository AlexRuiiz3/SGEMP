using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenSistemaGestion_Entidades;
using ExamenSistemaGestion_BL.Listados;
using ExamenSistemaGestion_BL.Gestora;

namespace ExamenSistemaGestion_UI.Controllers
{
    public class PlantasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }      
        /// <summary>
        /// Action que prepara una ClsPlanta concreta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Actualizar(int id)
        {
            IActionResult action;
            try {
                ClsPlanta planta = ListadosBL.obtenerPlanta(id);
                action = View(planta);
            }
            catch (Exception) {
                action = View("ViewNotFoundPlantas");
            }

            return action;
        }        

        /// <summary>
        /// Action cuando se pulse un boton de tipo sumit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Actualizar")]
        public IActionResult ActualizarPost(int id, float precio)
        {
            IActionResult action = RedirectToAction("Actualizar", id);
            if (ModelState.IsValid)
            {
                try
                {
                    GestoraPlantasBL.actualizarPrecioPlanta(id, precio);
                    action = RedirectToAction("Actualizar", id);
                }
                catch (Exception)
                {
                    action = View("ViewNotFoundPlantas");
                }
            }
            return action;
        }
    }
}
