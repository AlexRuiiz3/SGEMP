using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Actividad2.Data;
using Actividad2.Models.Entidades;

namespace Actividad2.Controllers
{
    public class PersonaController : Controller
    {
        private Actividad2Context db = new Actividad2Context();

        // GET: Persona
        public ActionResult Index()
        {
            return View(db.ClsPersonas.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsPersona clsPersona = db.ClsPersonas.Find(id);
            if (clsPersona == null)
            {
                return HttpNotFound();
            }
            return View(clsPersona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] ClsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                db.ClsPersonas.Add(clsPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clsPersona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsPersona clsPersona = db.ClsPersonas.Find(id);
            if (clsPersona == null)
            {
                return HttpNotFound();
            }
            return View(clsPersona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] ClsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clsPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clsPersona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClsPersona clsPersona = db.ClsPersonas.Find(id);
            if (clsPersona == null)
            {
                return HttpNotFound();
            }
            return View(clsPersona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClsPersona clsPersona = db.ClsPersonas.Find(id);
            db.ClsPersonas.Remove(clsPersona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
