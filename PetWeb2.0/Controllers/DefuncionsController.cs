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
    public class DefuncionsController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: Defuncions
        public ActionResult Index()
        {
            var defuncion = db.Defuncion.Include(d => d.Mascota);
            return View(defuncion.ToList());
        }

        // GET: Defuncions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defuncion defuncion = db.Defuncion.Find(id);
            if (defuncion == null)
            {
                return HttpNotFound();
            }
            return View(defuncion);
        }

        // GET: Defuncions/Create
        public ActionResult Create()
        {
            ViewBag.MascotaId = new SelectList(db.Mascota, "Id", "Nombre");
           
            ViewBag.MascotaMicrochip = new SelectList(db.Mascota, "Microchip", "Nombre");
            return View();
        }

        // POST: Defuncions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ObservacionDefuncion,CausaDefuncion,FechaDefuncion,Defuncion1,MascotaId,MascotaMicrochip")] Defuncion defuncion)
        {
            if (ModelState.IsValid)
            {
                db.Defuncion.Add(defuncion);
                db.SaveChanges();
                return RedirectToAction("Index","VW_Defunciones");
            }

            ViewBag.MascotaId = new SelectList(db.Mascota, "Id", "Nombre", defuncion.MascotaId);
            ViewBag.MascotaMicrochip = new SelectList(db.Mascota, "Microchip", "Nombre", defuncion.MascotaId);
            return PartialView(defuncion);
        }

        // GET: Defuncions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defuncion defuncion = db.Defuncion.Find(id);
            if (defuncion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MascotaId = new SelectList(db.Mascota, "Id", "Nombre", defuncion.MascotaId);

            return View(defuncion);
        }

        // POST: Defuncions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ObservacionDefuncion,CausaDefuncion,FechaDefuncion,Defuncion1,MascotaId,MascotaMicrochip")] Defuncion defuncion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defuncion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MascotaId = new SelectList(db.Mascota, "Id", "Nombre", defuncion.MascotaId);

            return View(defuncion);
        }

        // GET: Defuncions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defuncion defuncion = db.Defuncion.Find(id);
            if (defuncion == null)
            {
                return HttpNotFound();
            }
            return View(defuncion);
        }

        // POST: Defuncions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Defuncion defuncion = db.Defuncion.Find(id);
            db.Defuncion.Remove(defuncion);
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
