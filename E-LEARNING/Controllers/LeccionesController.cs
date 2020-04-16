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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecciones lec = db.Lecciones.Include(x=>x.CursoProfe).SingleOrDefault(x=>x.IdLeccion==id);
            var Docente = db.CursoProfes.Include(x => x.Profe).SingleOrDefault(x => x.IdCursoProfe == lec.CursoProfe.IdCursoProfe).Profe;
            ViewBag.docente = ""+Docente.nombre +" "+ Docente.apellidos;
            if (lec == null)
            {
                return HttpNotFound();
            }

            return View(lec);
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
            Lecciones leccion = db.Lecciones.Include(x => x.CursoProfe).SingleOrDefault(x => x.IdLeccion == id);
            return View(leccion);
        }

        // POST: Lecciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLeccion,Titulo,Contenido")] Lecciones lec, int id)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var leccion = db.Lecciones.Include(x=>x.CursoProfe).SingleOrDefault(x=>x.IdLeccion == id);

                leccion.Contenido = lec.Contenido;
                leccion.Titulo = lec.Titulo;

                db.Entry(leccion).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details","GruposAdmin",new { id = leccion.CursoProfe.IdCursoProfe});
            }
            catch
            {
                return View();
            }
        }

        // GET: Lecciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecciones lec = db.Lecciones.Find(id);
            if (lec == null) {
                return HttpNotFound();
            }
            return View(lec);
        }

        // POST: Lecciones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Lecciones lec = db.Lecciones.Include(x=>x.CursoProfe).SingleOrDefault(x=>x.IdLeccion==id);
                int idGrupo = lec.CursoProfe.IdCursoProfe;
                db.Lecciones.Remove(lec);
                db.SaveChanges();
                return RedirectToAction("Details","GruposAdmin",new { id=idGrupo} );
            }
            catch
            {
                Lecciones lec = db.Lecciones.Find(id);
                return View(lec);
            }
        }
    }
}
