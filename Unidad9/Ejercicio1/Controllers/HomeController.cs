using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio1.Models;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Editar()
        {
            ClsEditarVM oClsEditarVM = new ClsEditarVM(1,"Alejandro","Ruiz",new DateTime(2000,12,29),"Esto es la direccion","+34 657102379");
            
            return View(oClsEditarVM);
        }
        [HttpPost]
        public ActionResult Editar(ClsEditarVM oClsEditarVM)
        {
            if (ModelState.IsValid)
            {
                return View("PersonaModificada", oClsEditarVM);
            }
            else {
                return View(oClsEditarVM);
            }
        }
    }
}