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
    public class VeterinariasController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: Veterinarias
        public ActionResult Index()
        {
            return View(db.Veterinaria.ToList());
        }

        // GET: Veterinarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinaria.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rut,Nombre,Correo,Fono")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
                db.Veterinaria.Add(veterinaria);
                db.SaveChanges();
                return RedirectToAction("Create","Sucursals");
            }
            else
            {
                return RedirectToAction("Create", "Sucursals");
            }

            return View(veterinaria);
        }

        // GET: Veterinarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinaria.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rut,Nombre,Correo,Fono")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinaria.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinaria veterinaria = db.Veterinaria.Find(id);
            db.Veterinaria.Remove(veterinaria);
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
