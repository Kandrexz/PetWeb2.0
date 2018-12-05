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
    public class VW_NuevaFichaController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: VW_NuevaFicha
        public ActionResult Index()
        {
            return PartialView(db.VW_NuevaFicha.ToList());
        }

        // GET: VW_NuevaFicha/Details/5
        public ActionResult HomeMascota (int? Microchip)
        {
            if (Microchip == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_NuevaFicha vW_NuevaFicha = db.VW_NuevaFicha.Find(Microchip);
            if (vW_NuevaFicha == null)
            {
                return HttpNotFound();
            }
            return PartialView(vW_NuevaFicha);
        }

        public ActionResult FichaClinica(int? Microchip) {

         
            if (Microchip == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_NuevaFicha vW_NuevaFicha = db.VW_NuevaFicha.Find(Microchip);
            if (vW_NuevaFicha == null)
            {
                return HttpNotFound();
            }
            return PartialView(vW_NuevaFicha);
        }

        // GET: VW_NuevaFicha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_NuevaFicha/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Rut,Fono_Contacto,Region,Ciudad,Calle,Numero,Nombre_Mascota,Microchip,FechaNacimiento,Peso,Sexo,Tipo,Raza")] VW_NuevaFicha vW_NuevaFicha)
        {
            if (ModelState.IsValid)
            {
                db.VW_NuevaFicha.Add(vW_NuevaFicha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_NuevaFicha);
        }

        // GET: VW_NuevaFicha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_NuevaFicha vW_NuevaFicha = db.VW_NuevaFicha.Find(id);
            if (vW_NuevaFicha == null)
            {
                return HttpNotFound();
            }
            return View(vW_NuevaFicha);
        }

        // POST: VW_NuevaFicha/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Apellido,Rut,Fono_Contacto,Region,Ciudad,Calle,Numero,Nombre_Mascota,Microchip,FechaNacimiento,Peso,Sexo,Tipo,Raza")] VW_NuevaFicha vW_NuevaFicha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_NuevaFicha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_NuevaFicha);
        }

        // GET: VW_NuevaFicha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_NuevaFicha vW_NuevaFicha = db.VW_NuevaFicha.Find(id);
            if (vW_NuevaFicha == null)
            {
                return HttpNotFound();
            }
            return View(vW_NuevaFicha);
        }

        // POST: VW_NuevaFicha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VW_NuevaFicha vW_NuevaFicha = db.VW_NuevaFicha.Find(id);
            db.VW_NuevaFicha.Remove(vW_NuevaFicha);
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
