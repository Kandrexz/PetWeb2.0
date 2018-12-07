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
    public class VW_ControlDesparacitacionController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: VW_ControlDesparacitacion
        public ActionResult Index()
        {
            return PartialView(db.VW_ControlDesparacitacion.ToList());
        }

        // GET: VW_ControlDesparacitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlDesparacitacion vW_ControlDesparacitacion = db.VW_ControlDesparacitacion.Find(id);
            if (vW_ControlDesparacitacion == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlDesparacitacion);
        }

        // GET: VW_ControlDesparacitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_ControlDesparacitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha_Modificación,Hora_Modificación,Nombre,Descripción,Via_Administracion,Dosis,Fecha,ProximaFecha")] VW_ControlDesparacitacion vW_ControlDesparacitacion)
        {
            if (ModelState.IsValid)
            {
                db.VW_ControlDesparacitacion.Add(vW_ControlDesparacitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_ControlDesparacitacion);
        }

        // GET: VW_ControlDesparacitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlDesparacitacion vW_ControlDesparacitacion = db.VW_ControlDesparacitacion.Find(id);
            if (vW_ControlDesparacitacion == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlDesparacitacion);
        }

        // POST: VW_ControlDesparacitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha_Modificación,Hora_Modificación,Nombre,Descripción,Via_Administracion,Dosis,Fecha,ProximaFecha")] VW_ControlDesparacitacion vW_ControlDesparacitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_ControlDesparacitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_ControlDesparacitacion);
        }

        // GET: VW_ControlDesparacitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_ControlDesparacitacion vW_ControlDesparacitacion = db.VW_ControlDesparacitacion.Find(id);
            if (vW_ControlDesparacitacion == null)
            {
                return HttpNotFound();
            }
            return View(vW_ControlDesparacitacion);
        }

        // POST: VW_ControlDesparacitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VW_ControlDesparacitacion vW_ControlDesparacitacion = db.VW_ControlDesparacitacion.Find(id);
            db.VW_ControlDesparacitacion.Remove(vW_ControlDesparacitacion);
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
