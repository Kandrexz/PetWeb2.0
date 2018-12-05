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
    public class MascotasController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascota = db.Mascota.Include(m => m.DueñoMascota).Include(m => m.Especie1).Include(m => m.Raza1);
            return View(mascota.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.Rut = new SelectList(db.DueñoMascota, "Rut", "Rut");
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo");
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Microchip,Nombre,Sexo,Peso,Color,FechaNacimiento,ObservacionDefuncion,Rut,CausaDefuncion,FechaDefuncion,Foto,Raza,Especie,Estilizado,Defuncion")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index","VW_NuevaFicha");
            }

            ViewBag.Rut = new SelectList(db.DueñoMascota, "Rut", "Rut", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return PartialView(mascota);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rut = new SelectList(db.DueñoMascota, "Rut", "Correo", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Microchip,Nombre,Sexo,Peso,Color,FechaNacimiento,ObservacionDefuncion,Rut,CausaDefuncion,FechaDefuncion,Foto,Raza,Especie,Estilizado,Defuncion")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rut = new SelectList(db.DueñoMascota, "Rut", "Correo", mascota.Rut);
            ViewBag.Especie = new SelectList(db.Especie, "Id", "Tipo", mascota.Especie);
            ViewBag.Raza = new SelectList(db.Raza, "Id", "Nombre", mascota.Raza);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascota.Find(id);
            db.Mascota.Remove(mascota);
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
