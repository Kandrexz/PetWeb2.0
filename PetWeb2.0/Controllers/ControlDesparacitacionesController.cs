using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetWeb2._0.Models;

namespace PetWeb2._0.Controllers
{
    public class ControlDesparacitacionesController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: ControlDesparacitaciones
        public ActionResult Index()
        {
            var controlDesparacitaciones = db.ControlDesparacitaciones.Include(c => c.Mascota);
            return PartialView(controlDesparacitaciones.ToList());
        }

        // GET: ControlDesparacitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDesparacitaciones controlDesparacitaciones = db.ControlDesparacitaciones.Find(id);
            if (controlDesparacitaciones == null)
            {
                return HttpNotFound();
            }
            return View(controlDesparacitaciones);
        }

        // GET: ControlDesparacitaciones/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre");
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip");





            return PartialView();
        }

        // POST: ControlDesparacitaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Peso,Fecha,ProximaFecha,Hora,Dosis,ViaAdministracion,Desparacitador,IdMascota,Microchip")] ControlDesparacitaciones controlDesparacitaciones)
        {
            if (ModelState.IsValid)
            {
                db.ControlDesparacitaciones.Add(controlDesparacitaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlDesparacitaciones.IdMascota);
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip", controlDesparacitaciones.Microchip);
            return PartialView(controlDesparacitaciones);
        }

        // GET: ControlDesparacitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDesparacitaciones controlDesparacitaciones = db.ControlDesparacitaciones.Find(id);
            if (controlDesparacitaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlDesparacitaciones.IdMascota);
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip", controlDesparacitaciones.Microchip);
            return PartialView(controlDesparacitaciones);
        }

        // POST: ControlDesparacitaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Peso,Fecha,ProximaFecha,Hora,Dosis,ViaAdministracion,Desparacitador,IdMascota,Microchip")] ControlDesparacitaciones controlDesparacitaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlDesparacitaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlDesparacitaciones.IdMascota);
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip", controlDesparacitaciones.Microchip);
            return PartialView(controlDesparacitaciones);
        }

        // GET: ControlDesparacitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDesparacitaciones controlDesparacitaciones = db.ControlDesparacitaciones.Find(id);
            if (controlDesparacitaciones == null)
            {
                return HttpNotFound();
            }
            return View(controlDesparacitaciones);
        }

        // POST: ControlDesparacitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlDesparacitaciones controlDesparacitaciones = db.ControlDesparacitaciones.Find(id);
            db.ControlDesparacitaciones.Remove(controlDesparacitaciones);
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
