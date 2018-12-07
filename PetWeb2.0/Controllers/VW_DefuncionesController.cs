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
    public class VW_DefuncionesController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: VW_Defunciones
        public ActionResult Index()
        {
            return View(db.VW_Defunciones.ToList());
        }

        // GET: VW_Defunciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Defunciones vW_Defunciones = db.VW_Defunciones.Find(id);
            if (vW_Defunciones == null)
            {
                return HttpNotFound();
            }
            return View(vW_Defunciones);
        }

        // GET: VW_Defunciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_Defunciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre_Dueño,Apellido_Dueño,Rut_Dueño,Numero_Microchip,Nombre_Mascota,Observacion_Defuncion,Causa_defuncion,Fecha_Defuncion,Defuncion")] VW_Defunciones vW_Defunciones)
        {
            if (ModelState.IsValid)
            {
                db.VW_Defunciones.Add(vW_Defunciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_Defunciones);
        }

        // GET: VW_Defunciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Defunciones vW_Defunciones = db.VW_Defunciones.Find(id);
            if (vW_Defunciones == null)
            {
                return HttpNotFound();
            }
            return View(vW_Defunciones);
        }

        // POST: VW_Defunciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre_Dueño,Apellido_Dueño,Rut_Dueño,Numero_Microchip,Nombre_Mascota,Observacion_Defuncion,Causa_defuncion,Fecha_Defuncion,Defuncion")] VW_Defunciones vW_Defunciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_Defunciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_Defunciones);
        }

        // GET: VW_Defunciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_Defunciones vW_Defunciones = db.VW_Defunciones.Find(id);
            if (vW_Defunciones == null)
            {
                return HttpNotFound();
            }
            return View(vW_Defunciones);
        }

        // POST: VW_Defunciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VW_Defunciones vW_Defunciones = db.VW_Defunciones.Find(id);
            db.VW_Defunciones.Remove(vW_Defunciones);
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
