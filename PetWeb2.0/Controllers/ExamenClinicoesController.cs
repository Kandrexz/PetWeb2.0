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
    public class ExamenClinicoesController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: ExamenClinicoes
        public ActionResult Index()
        {
            var examenClinico = db.ExamenClinico.Include(e => e.Mascota);
            return PartialView(examenClinico.ToList());
        }
        
        

        // GET: ExamenClinicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenClinico examenClinico = db.ExamenClinico.Find(id);
            if (examenClinico == null)
            {
                return HttpNotFound();
            }
            return View(examenClinico);
        }

        // GET: ExamenClinicoes/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre");
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip");
            return View();
        }

        // POST: ExamenClinicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,MotivoConsulta,FrecuenciaCardiaca,TemperaturaPaciente,Anamnesis,Diagnostico,Tratamiento,Tipo,IdMascota,Microchip")] ExamenClinico examenClinico)
        {
            if (ModelState.IsValid)
            {
                db.ExamenClinico.Add(examenClinico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", examenClinico.IdMascota);
            ViewBag.Microchip = new SelectList(db.Mascota, "Microchip", "Microchip", examenClinico.Microchip);
            return PartialView(examenClinico);
        }

        // GET: ExamenClinicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenClinico examenClinico = db.ExamenClinico.Find(id);
            if (examenClinico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", examenClinico.IdMascota);
            return View(examenClinico);
        }

        // POST: ExamenClinicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,MotivoConsulta,FrecuenciaCardiaca,TemperaturaPaciente,Anamnesis,Diagnostico,Tratamiento,Tipo,IdMascota,Microchip")] ExamenClinico examenClinico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenClinico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", examenClinico.IdMascota);
            return View(examenClinico);
        }

        // GET: ExamenClinicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenClinico examenClinico = db.ExamenClinico.Find(id);
            if (examenClinico == null)
            {
                return HttpNotFound();
            }
            return View(examenClinico);
        }

        // POST: ExamenClinicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamenClinico examenClinico = db.ExamenClinico.Find(id);
            db.ExamenClinico.Remove(examenClinico);
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
