using Microsoft.AspNetCore.Mvc;
using ExamenSistemaGestion_Entidades;
using ExamenSistemaGestion_BL;

namespace ExamenSistemaGestion_UI.Controllers
{
    public class HomeController : Controller
    {
        /*
         * CREATE LOGIN sa WITH password = 'mitesoro',
            DEFAULT_DATABASE = NombreBaseDatos
            USE NombreBaseDatos
            CREATE USER sa FOR LOGIN sa
            GRANT EXECUTE, INSERT, UPDATE, DELETE, 
            SELECT TO sa
         */
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
