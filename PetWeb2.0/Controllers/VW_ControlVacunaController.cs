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
    public class VW_ControlVacunaController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: VW_ControlVacuna
        public ActionResult Index()
        {
            return PartialView(db.VW_ControlVacuna.ToList());
        }

        // GET: VW_ControlVacuna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlVacuna vW_ControlVacuna = db.VW_ControlVacuna.Find(id);
            if (vW_ControlVacuna == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlVacuna);
        }

        // GET: VW_ControlVacuna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_ControlVacuna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha_Modificación,Hora_Modificación,Nombre,Descripción,Via_Administracion,Dosis,Fecha,ProximaFecha")] VW_ControlVacuna vW_ControlVacuna)
        {
            if (ModelState.IsValid)
            {
                db.VW_ControlVacuna.Add(vW_ControlVacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_ControlVacuna);
        }

        // GET: VW_ControlVacuna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlVacuna vW_ControlVacuna = db.VW_ControlVacuna.Find(id);
            if (vW_ControlVacuna == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlVacuna);
        }

        // POST: VW_ControlVacuna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha_Modificación,Hora_Modificación,Nombre,Descripción,Via_Administracion,Dosis,Fecha,ProximaFecha")] VW_ControlVacuna vW_ControlVacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_ControlVacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_ControlVacuna);
        }

        // GET: VW_ControlVacuna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlVacuna vW_ControlVacuna = db.VW_ControlVacuna.Find(id);
            if (vW_ControlVacuna == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlVacuna);
        }

        // POST: VW_ControlVacuna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VW_ControlVacuna vW_ControlVacuna = db.VW_ControlVacuna.Find(id);
            db.VW_ControlVacuna.Remove(vW_ControlVacuna);
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
