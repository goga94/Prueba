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
    public class tbProductosController : Controller
    {
        private BaseScisaEntities db = new BaseScisaEntities();

        // GET: tbProductos
        public ActionResult Index()
        {
            return View(db.tbProductos.ToList());
        }

        // GET: tbProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProductos tbProductos = db.tbProductos.Find(id);
            if (tbProductos == null)
            {
                return HttpNotFound();
            }
            return View(tbProductos);
        }

        // GET: tbProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Descripcion")] tbProductos tbProductos)
        {
            if (ModelState.IsValid)
            {
                db.tbProductos.Add(tbProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbProductos);
        }

        // GET: tbProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProductos tbProductos = db.tbProductos.Find(id);
            if (tbProductos == null)
            {
                return HttpNotFound();
            }
            return View(tbProductos);
        }

        // POST: tbProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Descripcion")] tbProductos tbProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbProductos);
        }

        // GET: tbProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProductos tbProductos = db.tbProductos.Find(id);
            if (tbProductos == null)
            {
                return HttpNotFound();
            }
            return View(tbProductos);
        }

        // POST: tbProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProductos tbProductos = db.tbProductos.Find(id);
            db.tbProductos.Remove(tbProductos);
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
