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
        public ActionResult Index() {
            return View();
        }
        // GET: Home
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString = "server=servidoralexbasedatos.database.windows.net;" +
                    "database=SistemaGestion;uid=saboresdelatierra;pwd=#Mitesoro;";
                miConexion.Open();
                ViewBag.EstadoConexion = miConexion.State;
                miConexion.Close();
                ViewBag.EstadoConexion2 = miConexion.State;
            }
            catch (SqlException e)
            {
                ViewBag.EstadoConexion = e.Message;
            }

            return View();
        }
    }
}