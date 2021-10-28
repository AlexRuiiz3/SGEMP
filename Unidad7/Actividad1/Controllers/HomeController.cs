﻿using Actividad1.Gestion;
using Actividad1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;


namespace Actividad1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["MensajeSaludo"] = Utilidad.obtenerMensaje();
            ViewBag.fechaActual = DateTime.Now.ToString();

            PersonaModel persona = new PersonaModel("Alejandro", "Ruiz");

            return View(persona);
        }

        public ActionResult Index2()
        {

            return View();
        }
    }
}