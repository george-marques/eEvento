﻿using System;
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
    [Authorize]
    public class InscricoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index(string searchTerm)
        {
            var inscricoes = db.Inscricoes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                inscricoes = inscricoes.Where(e => e.Participante.Nome.Contains(searchTerm));
            }

            return View(inscricoes.ToList());
        }

        // GET: Inscricoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // GET: Inscricoes/Create
        public ActionResult Create()
        {
            ViewBag.Eventos = db.Eventos.ToList();
            ViewBag.Participantes = db.Participantes.ToList();
            return View();
        }

        // POST: Inscricoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscricaoId,DataInscricao,EventoId,ParticipanteId")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Inscricoes.Add(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Eventos = db.Eventos.ToList();
            ViewBag.Participantes = db.Participantes.ToList();
            return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Eventos = db.Eventos.ToList();
            ViewBag.Participantes = db.Participantes.ToList();
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscricaoId,DataInscricao,EventoId,ParticipanteId")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Eventos = db.Eventos.ToList();
            ViewBag.Participantes = db.Participantes.ToList();
            return View(inscricao);
        }

        // GET: Inscricoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricoes.Find(id);
            db.Inscricoes.Remove(inscricao);
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
