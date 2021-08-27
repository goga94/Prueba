using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba;

namespace Prueba.Controllers
{
    public class tbCategoriasController : Controller
    {
        private BaseScisaEntities1 db = new BaseScisaEntities1();

        // GET: tbCategorias
        public ActionResult Index()
        {
            return View(db.tbCategoria.ToList());
        }

        // GET: tbCategorias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategoria tbCategoria = db.tbCategoria.Find(id);
            if (tbCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tbCategoria);
        }

        // GET: tbCategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbCategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Descripcion")] tbCategoria tbCategoria)
        {
            if (ModelState.IsValid)
            {
                db.tbCategoria.Add(tbCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbCategoria);
        }

        // GET: tbCategorias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategoria tbCategoria = db.tbCategoria.Find(id);
            if (tbCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tbCategoria);
        }

        // POST: tbCategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Descripcion")] tbCategoria tbCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbCategoria);
        }

        // GET: tbCategorias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategoria tbCategoria = db.tbCategoria.Find(id);
            if (tbCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tbCategoria);
        }

        // POST: tbCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbCategoria tbCategoria = db.tbCategoria.Find(id);
            db.tbCategoria.Remove(tbCategoria);
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
