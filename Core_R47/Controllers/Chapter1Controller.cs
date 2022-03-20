using Core_R47.Data;
using Core_R47.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    public class Chapter1Controller : Controller
    {
        private DBContextContext db;
        public Chapter1Controller(DBContextContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.teachers.ToList());
        }

        public ActionResult ShowName()
        {
            List<teachers> item = null;
            item = (from c in db.teachers select c).ToList();
            ViewBag.DDLProducts = new SelectList(item, "ID", "FirstMidName");
            return View();
        }
        [HttpPost]
        public ActionResult ShowName(teachers st)
        {
            List<teachers> item = null;
            item = (from c in db.teachers select c).ToList();
            ViewBag.DDLProducts = new SelectList(item, "ID", "FirstMidName");
            ViewBag.StId = st.ID;
            teachers t = (from c in db.teachers where c.ID == st.ID select c).FirstOrDefault();
            ViewData["FullName"] = t.FirstMidName + " " + t.LastName;
            return View(st);
        }



        public ActionResult ShowLastNamewithMultipleRecords()
        {
            var item = (from c in db.teachers select new { LastName = c.LastName }).Distinct().ToList();
            ViewBag.DDLProducts = new SelectList(item, "LastName", "LastName");
            return View();
        }
        [HttpPost]
        public ActionResult ShowLastNamewithMultipleRecords(teachers st)
        {
            var item = (from c in db.teachers select new { LastName = c.LastName }).Distinct().ToList();
            ViewBag.DDLProducts = new SelectList(item, "LastName", "LastName");
            ViewBag.StLastName = st.LastName;
            List<teachers> lst = (from c in db.teachers where c.LastName == st.LastName select c).ToList();
            ViewBag.allstudents = lst;
            return View(st);
        }


    }
}
