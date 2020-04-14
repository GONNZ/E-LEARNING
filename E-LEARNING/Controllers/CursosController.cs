using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using E_LEARNING.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;

namespace E_LEARNING.Controllers
{
    public class CursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public CursosController()
        {
        }

        public CursosController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Cursos
        public ActionResult Index()
        {
            return View(db.Cursoes.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCurso,CodigoCurso,NombreCurso,DescripcionCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurso,CodigoCurso,NombreCurso,DescripcionCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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


        //Acción para generar curso
        //Get Cursos/Grupo

        public async Task<ActionResult> Grupo(int? id, string SearchString)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursoes.Find(id);
            
            if (curso == null)
            {
                return HttpNotFound();
            }

            //Lista de profesores
            var role = await RoleManager.FindByNameAsync("Profe");
                
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                users = users.Where(x => x.nombre.Contains(SearchString)).ToList();

            }

            ViewBag.profes = users;
            ViewBag.curso = curso;

            return View(curso);
        }

        //Acción para generar curso
        //Get Cursos/GeneraGrupo
        public ActionResult GeneraGrupo(string idProfe, int? idCurso) 
        {
            if (String.IsNullOrEmpty(idProfe) || idCurso == null) {
                return HttpNotFound();
            }

            var profe = db.Users.Find(idProfe);
            var curso = db.Cursoes.Find(idCurso);

            if (profe == null || curso == null)
            {
                return HttpNotFound();
            }

            CursoProfe grupo = new CursoProfe();
            grupo.Curso = curso;
            grupo.Profe = profe;

            db.CursoProfes.Add(grupo);
            db.SaveChanges();

            

            return RedirectToAction("Index", "GruposAdmin");
        }

        //Acción para matricula en curso a un estudiante
        // GET

        public async Task<ActionResult> Matricula(int? id, string SearchString) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursoes.Find(id);

            if (curso == null)
            {
                return HttpNotFound();
            }

            //Lista de profesores
            var role = await RoleManager.FindByNameAsync("Alumno");

            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                users = users.Where(x => x.nombre.Contains(SearchString)).ToList();

            }

            ViewBag.profes = users;
            ViewBag.curso = curso;

            return View(curso);
        }

        //Acción para matricula en curso a un estudiante
        // Get

        public ActionResult GeneraMatricula(string idAlum, int? idCurso, string SearchString)
        {
            if (String.IsNullOrEmpty(idAlum) || idCurso == null)
            {
                return HttpNotFound();
            }

            var alum = db.Users.Find(idAlum);
            var curso = db.Cursoes.Find(idCurso);

            if (alum == null || curso == null)
            {
                return HttpNotFound();
            }

            
            ViewBag.alumno = alum;
            ViewBag.curso = curso;

            var grupos = db.CursoProfes.Include(x => x.Curso).Include(x => x.Profe).Where(x => x.Curso.IdCurso == idCurso).ToList();

            if (!String.IsNullOrEmpty(SearchString)) {
                grupos = grupos.Where(g => g.Profe.nombre.Contains(SearchString)).ToList();
            }

            ViewBag.grupos = grupos;

            return View();
        }

        public ActionResult FinalizaMatricula(int? idGrupo, int? idCurso, string idAlumno) {

            if (String.IsNullOrEmpty(idAlumno) || idCurso == null || idGrupo == null)
            {
                return HttpNotFound();
            }

            var alumno = db.Users.Find(idAlumno);
            var curso = db.Cursoes.Find(idCurso);
            var grupo = db.CursoProfes.Include(x=>x.Profe).Include(x=>x.Curso).SingleOrDefault(x=> x.IdCursoProfe == idGrupo);

            if (alumno == null || curso == null || grupo == null)
            {
                return HttpNotFound();
            }

            Matricula mat = new Matricula();
            mat.CursoProfe = grupo;
            mat.Alumno = alumno;

            db.Matriculas.Add(mat);
            db.SaveChanges();

            return RedirectToAction("Index", "GruposAdmin");
        }

    }
}
