using E_LEARNING.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_LEARNING.Controllers
{
    public class AdminCursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public AdminCursosController()
        {
        }

        public AdminCursosController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
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
            private set
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

        // Página para añadir Profesores a cursos
        // GET
        public async Task<ActionResult> AñadirProfe(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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


            ViewBag.IdCurso = id;
            ViewBag.Profes = users;

            return View();
        }

        // GET: AdminCursos
        public ActionResult Index()
        {
            //Añade Profes Curso Probado 100%
            //var cursoProfe = new CursoProfe();
            //cursoProfe.idCurso = 1;
            //cursoProfe.idProfe = "73e7929f-50e3-4c1c-b298-c8459074dcd4";

            //var usuario = db.Users.Find("73e7929f-50e3-4c1c-b298-c8459074dcd4");
            //var curso = db.Cursoes.Find(1);

            //cursoProfe.Curso = curso;
            //cursoProfe.Profe = usuario;

            //db.CursoProfes.Add(cursoProfe);
            //db.SaveChanges();


            //Añadiendo Grupos  
            var grupo = new Grupos();
            var CursoProfe = db.CursoProfes.Find(1);

            grupo.CursoProfe = CursoProfe;
            grupo.horario = "J | 6:00pm a 9:00pm";

            db.Grupos.Add(grupo);
            db.SaveChanges();



            return View();
        }
    }
}