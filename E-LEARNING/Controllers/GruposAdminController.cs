﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_LEARNING.Models;
using IdentitySample.Models;

namespace E_LEARNING.Controllers
{
    public class GruposAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GruposAdmin
        public ActionResult Index(string searchProfe, string searchCurso)
        {
            var grupos = db.CursoProfes.Include(x => x.Curso).Include(x => x.Profe).ToList();

            if (!String.IsNullOrEmpty(searchProfe)) 
            {
                grupos = grupos.Where(g => g.Profe.nombre.Contains(searchProfe)).ToList();    
            }

            if (!String.IsNullOrEmpty(searchCurso))
            {
                grupos = grupos.Where(g => g.Curso.NombreCurso.Contains(searchCurso)).ToList();
            }

            return View(grupos);
        }

        // GET: GruposAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoProfe cursoProfe = db.CursoProfes.Include(x=> x.Curso).Include(x=> x.Profe).SingleOrDefault(x => x.IdCursoProfe == id);
            List<Lecciones> lecciones = db.Lecciones.Where(x => x.CursoProfe.IdCursoProfe == cursoProfe.IdCursoProfe).ToList();
            ViewBag.cantlecc = lecciones.Count;
            ViewBag.Lecciones = lecciones;

            if (cursoProfe == null)
            {
                return HttpNotFound();
            }
            return View(cursoProfe);
        }


        // GET: GruposAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoProfe cursoProfe = db.CursoProfes.Find(id);
            if (cursoProfe == null)
            {
                return HttpNotFound();
            }
            return View(cursoProfe);
        }

        // POST: GruposAdmin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCursoProfe")] CursoProfe cursoProfe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoProfe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursoProfe);
        }

        // GET: GruposAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoProfe cursoProfe = db.CursoProfes.Find(id);
            if (cursoProfe == null)
            {
                return HttpNotFound();
            }
            return View(cursoProfe);
        }

        // POST: GruposAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoProfe cursoProfe = db.CursoProfes.Find(id);
            db.CursoProfes.Remove(cursoProfe);
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
