using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eEvento.Models;

namespace eEvento.Controllers
{
    public class OrganizadoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organizadores
        public ActionResult Index()
        {
            return View(db.Organizadores.ToList());
        }

        // GET: Organizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // GET: Organizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizadores/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizadorId,Nome,Contato")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Organizadores.Add(organizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizador);
        }

        // GET: Organizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizadores/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizadorId,Nome,Contato")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizador);
        }

        // GET: Organizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizador organizador = db.Organizadores.Find(id);
            if (organizador == null)
            {
                return HttpNotFound();
            }
            return View(organizador);
        }

        // POST: Organizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizador organizador = db.Organizadores.Find(id);
            db.Organizadores.Remove(organizador);
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
