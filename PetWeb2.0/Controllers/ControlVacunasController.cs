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
    public class ControlVacunasController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: ControlVacunas
        public ActionResult Index()
        {
            var controlVacuna = db.ControlVacuna.Include(c => c.Mascota);
            return PartialView(controlVacuna.ToList());
        }

        // GET: ControlVacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlVacuna controlVacuna = db.ControlVacuna.Find(id);
            if (controlVacuna == null)
            {
                return HttpNotFound();
            }
            return View(controlVacuna);
        }

        // GET: ControlVacunas/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre");
            return View();
        }

        // POST: ControlVacunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Temperatura,Fecha,ProximaFecha,Hora,Dosis,ViaAdministracion,Vacuna,IdMascota,Microchip")] ControlVacuna controlVacuna)
        {
            if (ModelState.IsValid)
            {
                db.ControlVacuna.Add(controlVacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlVacuna.IdMascota);
            return View(controlVacuna);
        }

        // GET: ControlVacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlVacuna controlVacuna = db.ControlVacuna.Find(id);
            if (controlVacuna == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlVacuna.IdMascota);
            return View(controlVacuna);
        }

        // POST: ControlVacunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Temperatura,Fecha,ProximaFecha,Hora,Dosis,ViaAdministracion,Vacuna,IdMascota,Microchip")] ControlVacuna controlVacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlVacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", controlVacuna.IdMascota);
            return View(controlVacuna);
        }

        // GET: ControlVacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlVacuna controlVacuna = db.ControlVacuna.Find(id);
            if (controlVacuna == null)
            {
                return HttpNotFound();
            }
            return View(controlVacuna);
        }

        // POST: ControlVacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlVacuna controlVacuna = db.ControlVacuna.Find(id);
            db.ControlVacuna.Remove(controlVacuna);
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
