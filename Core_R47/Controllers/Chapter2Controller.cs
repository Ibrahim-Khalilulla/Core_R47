using Core_R47.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Controllers
{
    public class Chapter2Controller : Controller
    {
        public ITeachers tr;
        public Chapter2Controller()
        {

        }
        [ActivatorUtilitiesConstructor]
        public Chapter2Controller(ITeachers trep)
        {
            tr = trep;
        }
        public IActionResult Index()
        {
            var data = tr.GetAll();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = tr.Get(id);
            return View(data);
        }

    }
}
