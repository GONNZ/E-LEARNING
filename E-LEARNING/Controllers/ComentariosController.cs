using E_LEARNING.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LEARNING.Controllers
{
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // POST: Comentarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                String idUsu = collection["usuario"];
                int idLec = Int32.Parse(collection["leccion"]);
                String Contenido = collection["contenido"];

                ApplicationUser usuario = db.Users.Find(idUsu);
                Lecciones lec = db.Lecciones.Find(idLec);

                Comentarios coment = new Comentarios();
                coment.Comentario = Contenido;
                coment.Usuario = usuario;
                coment.Leccion = lec;

                db.Comentarios.Add(coment);
                db.SaveChanges();


                return RedirectToAction("Details","Lecciones",new { id=idLec});
            }
            catch
            {
                return View();
            }
        }

        
        // POST: Comentarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int lec)
        {
            try
            {
                Comentarios coment = db.Comentarios.Find(id);
                db.Comentarios.Remove(coment);
                db.SaveChanges();

                return RedirectToAction("Details", "Lecciones", new { id = lec });
            }
            catch
            {
                return View();
            }
        }
    }
}
