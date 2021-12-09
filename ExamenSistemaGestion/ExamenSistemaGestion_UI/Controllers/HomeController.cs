using Microsoft.AspNetCore.Mvc;
using ExamenSistemaGestion_Entidades;
//using ExamenSistemaGestion_BL;
using ExamenSistemaGestion_UI.Controllers;
using ExamenSistemaGestion_Dal.Conexion;

namespace ExamenSistemaGestion_UI.Controllers
{
    public class HomeController : Controller
    {
        #region Actions
        /// <summary>
        /// Action Index    
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Index()
        {
 
            return View();
        }
        #endregion
    }
}
