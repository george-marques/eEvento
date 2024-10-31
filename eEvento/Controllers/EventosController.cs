using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eEvento.Models;

namespace eEvento.Controllers
{
    [RequireHttps]
    [Authorize]
    public class EventosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]

        public ActionResult Index(string searchTerm)
        {
            var eventos = db.Eventos.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                eventos = eventos.Where(e => e.Nome.Contains(searchTerm));
            }

            return View(eventos.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.Locais = db.Locais.ToList();
            ViewBag.Organizadores = db.Organizadores.ToList();
            ViewBag.Patrocinadores = db.Patrocinadores.ToList(); // Carrega os patrocinadores e armazena no ViewBag

            return View();
        }

        // POST: Eventos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventoId,Nome,Descricao,Data,LocalId,Capacidade,OrganizadorId")] Evento evento, int[] SelectedPatrocinadores)
        {
            if (ModelState.IsValid)
            {
                // Adicionar patrocinadores selecionados ao evento
                evento.Patrocinadores = new List<Patrocinador>();
                if (SelectedPatrocinadores != null)
                {
                    foreach (var patrocinadorId in SelectedPatrocinadores)
                    {
                        var patrocinador = db.Patrocinadores.Find(patrocinadorId);
                        if (patrocinador != null)
                        {
                            evento.Patrocinadores.Add(patrocinador);
                        }
                    }

                }

                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locais = db.Locais.ToList();
            ViewBag.Organizadores = db.Organizadores.ToList();
            ViewBag.Patrocinadores = db.Patrocinadores.ToList(); // Caso haja erro de validação

            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            ViewBag.Locais = db.Locais.ToList();
            ViewBag.Organizadores = db.Organizadores.ToList();

            return View(evento);
        }

        // POST: Eventos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventoId,Nome,Descricao,Data,LocalId,Capacidade,OrganizadorId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locais = db.Locais.ToList();
            ViewBag.Organizadores = db.Organizadores.ToList();

            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
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
