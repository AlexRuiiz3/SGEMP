using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actividad1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpPost]
        public ActionResult Index()
        {
            bool estadoConexionBBDD = obtenerEstadoConexionBBDD();
            ViewBag.EstadoConexion = estadoConexionBBDD;
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        public bool obtenerEstadoConexionBBDD()
        { //Es de prueba, va en el capa Dal
            bool establecida = false;
            SqlConnection miConexion = new SqlConnection();

            try
            {

                miConexion.ConnectionString = "server=servidoralexbasedatos.database.windows.net;" +
                    "database=SistemaGestion;uid=saboresdelatierra;pwd=#Mitesoro;";
                miConexion.Open();
                establecida = true;
                
            }
            catch (SqlException e)
            {
            }
            return establecida;
        }
    }
}