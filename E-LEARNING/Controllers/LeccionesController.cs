using E_LEARNING.Models;
using IdentitySample.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_LEARNING.Controllers
{
    public class LeccionesController : Controller
    {
        // GET: Lecciones
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Lecciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lecciones/Create
        public ActionResult Create(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.idCursoP = id;
            Lecciones lec = new Lecciones();
            lec.CursoProfe = db.CursoProfes.Find(id);

            return View(lec);
        }

        // POST: Lecciones/Create
        [HttpPost]

        public ActionResult Create(Lecciones leccion, int? Grupo)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var grupo = db.CursoProfes.Include(x => x.Profe).Include(x => x.Curso).SingleOrDefault(x => x.IdCursoProfe == Grupo);
                leccion.CursoProfe = grupo;

                db.Lecciones.Add(leccion);
                db.SaveChanges();

                return RedirectToAction("Details","GruposAdmin", new { id=grupo.IdCursoProfe});
            }
            catch
            {
                return View();
            }
        }

        // GET: Lecciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lecciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lecciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lecciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
