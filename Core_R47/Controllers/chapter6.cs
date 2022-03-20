using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    public class chapter6 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Html()
        {
            return new ContentResult()
            {
                Content = "<h1> Hello </h1>",
                ContentType = "text/html",
                StatusCode = 200
            };
        }
        public IActionResult Html2()
        {
            return View();
        }
       
    }
}
