using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_R47.Data;
using Core_R47.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core_R47.Pages
{
    public class myrazorModel : PageModel
    {
        private DBContextContext _context;
       public List<teachers> AllTeachers = new List<teachers>();
        public string Message { get; set; }
        public myrazorModel(DBContextContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Message="Hello World";
           AllTeachers= _context.teachers.ToList();
        }
    }
}
