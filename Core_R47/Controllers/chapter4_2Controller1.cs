using Core_R47.Data;
using Core_R47.Filters;
using Core_R47.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    [Header(Name = "ActionName", Value = "About")]
    [Culture(Name = "en-US")]
    public class chapter4_2Controller1 : Controller
    {
        private readonly DBContextContext _context;
        public chapter4_2Controller1(DBContextContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return Ok("Its Ok. Check Header > duration");
        }

        public ActionResult About()
        {
            return Ok();
        }
        
        public ActionResult Details(int? id)
        {
            var teachers = _context.teachers.FirstOrDefault(m => m.ID == id);
            return PartialView(teachers);
        }
        public ActionResult Repeat(RepeatText input)
        {
            //https://localhost:44399/chapter4_2controller1/repeat?Text=Jamal&Number=21
            return Ok(input);
        }
        protected DateTime StartTime;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor.RouteValues["action"];
            if (string.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                StartTime = DateTime.Now;
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.ActionDescriptor.RouteValues["action"];
            if (string.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                var timeSpan = DateTime.Now - StartTime;
                filterContext.HttpContext.Response.Headers.Add("duration", timeSpan.TotalMilliseconds.ToString());
            }
            base.OnActionExecuted(filterContext);
        }

    }
}
