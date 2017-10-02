using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestParcial.Entities;
using TestParcial.UI.Process;

namespace TestParcial.UI.Web.Areas.Students.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Students/Student/
        public ActionResult Index()
        {
            var sp = new StudentProcess();
            var lista = sp.SelectList();
            return View(lista);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            var cp = new StudentProcess();
            var lista = cp.SelectList();
            ViewData["Country"] = lista;
            return View();
        }

        [HttpPost]
        // POST: Students/Create
        public ActionResult Create(Student std)
        {
            var sp = new StudentProcess();
            sp.Insert(std);
            return RedirectToAction("Index");
        }
    }
}