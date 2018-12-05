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
    public class VW_AtencionController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: VW_Atencion
        public ActionResult Index()
        {
            return PartialView(db.VW_Atencion.ToList());
        }

        // GET: VW_Atencion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Atencion vW_Atencion = db.VW_Atencion.Find(id);
            if (vW_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(vW_Atencion);
        }

        // GET: VW_Atencion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_Atencion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Microchip,Anamnesis,Diagnostico,Tratamiento,Fecha,Hora")] VW_Atencion vW_Atencion)
        {
            if (ModelState.IsValid)
            {
                db.VW_Atencion.Add(vW_Atencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_Atencion);
        }

        // GET: VW_Atencion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Atencion vW_Atencion = db.VW_Atencion.Find(id);
            if (vW_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(vW_Atencion);
        }

        // POST: VW_Atencion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Microchip,Anamnesis,Diagnostico,Tratamiento,Fecha,Hora")] VW_Atencion vW_Atencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_Atencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_Atencion);
        }

        // GET: VW_Atencion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Atencion vW_Atencion = db.VW_Atencion.Find(id);
            if (vW_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(vW_Atencion);
        }

        // POST: VW_Atencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VW_Atencion vW_Atencion = db.VW_Atencion.Find(id);
            db.VW_Atencion.Remove(vW_Atencion);
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
