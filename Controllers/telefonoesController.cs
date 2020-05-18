using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaloPrueba.Data;
using LaloPrueba.Models;

namespace LaloPrueba.Controllers
{
    public class telefonoesController : Controller
    {
        private LaloPruebaContext db = new LaloPruebaContext();

        // GET: telefonoes
        public ActionResult Index()
        {
            return View(db.telefonoes.ToList());
        }

        // GET: telefonoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: telefonoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: telefonoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,tel,telcasa")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.telefonoes.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefono);
        }

        // GET: telefonoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: telefonoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,tel,telcasa")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefono);
        }

        // GET: telefonoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefono telefono = db.telefonoes.Find(id);
            db.telefonoes.Remove(telefono);
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
