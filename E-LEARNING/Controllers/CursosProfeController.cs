using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LEARNING.Controllers
{
    public class CursosProfeController : Controller
    {
        // GET: CursosProfe
        public ActionResult Index()
        {
            return View();
        }

        // GET: CursosProfe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CursosProfe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursosProfe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosProfe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursosProfe/Edit/5
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

        // GET: CursosProfe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursosProfe/Delete/5
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
