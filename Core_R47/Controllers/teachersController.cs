using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_R47.Data;
using Core_R47.Models;
using Microsoft.AspNetCore.Authorization;

namespace Core_R47.Controllers
{
    //[Authorize]
    public class teachersController : Controller
    {
        private readonly DBContextContext _context;

        public teachersController(DBContextContext context)
        {
            _context = context;
        }

        // GET: teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.teachers.ToListAsync());
        }

        // GET: teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.teachers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName")] teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

        // GET: teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }
            return View(teachers);
        }

        // POST: teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName")] teachers teachers)
        {
            if (id != teachers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!teachersExists(teachers.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

        // GET: teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.teachers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // POST: teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers = await _context.teachers.FindAsync(id);
            _context.teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool teachersExists(int id)
        {
            return _context.teachers.Any(e => e.ID == id);
        }
    }
}
