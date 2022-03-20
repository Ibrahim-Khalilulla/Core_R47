using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    public class Chapter5 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
