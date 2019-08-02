using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AkhilD_301057929.Data;
using AkhilD_301057929.Models;

namespace AkhilD_301057929.Controllers
{
    public class AssignFacultiesController : Controller
    {
        private readonly SchoolContext _context;

        public AssignFacultiesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: AssignFaculties
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.AssignFaculties.Include(a => a.Course).Include(a => a.Faculty);
            return View(await schoolContext.ToListAsync());
        }

        // GET: AssignFaculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignFaculty = await _context.AssignFaculties
                .Include(a => a.Course)
                .Include(a => a.Faculty)
                .FirstOrDefaultAsync(m => m.classId == id);
            if (assignFaculty == null)
            {
                return NotFound();
            }

            return View(assignFaculty);
        }

        // GET: AssignFaculties/Create
        public IActionResult Create()
        {
            ViewData["courseCode"] = new SelectList(_context.Courses, "courseCode", "courseCode");
            ViewData["facultyId"] = new SelectList(_context.Faculties, "facultyId", "facultyId");
            return View();
        }

        // POST: AssignFaculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("classId,facultyId,courseCode")] AssignFaculty assignFaculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignFaculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["courseCode"] = new SelectList(_context.Courses, "courseCode", "courseCode", assignFaculty.courseCode);
            ViewData["facultyId"] = new SelectList(_context.Faculties, "facultyId", "facultyId", assignFaculty.facultyId);
            return View(assignFaculty);
        }

        // GET: AssignFaculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignFaculty = await _context.AssignFaculties.FindAsync(id);
            if (assignFaculty == null)
            {
                return NotFound();
            }
            ViewData["courseCode"] = new SelectList(_context.Courses, "courseCode", "courseCode", assignFaculty.courseCode);
            ViewData["facultyId"] = new SelectList(_context.Faculties, "facultyId", "facultyId", assignFaculty.facultyId);
            return View(assignFaculty);
        }

        // POST: AssignFaculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("classId,facultyId,courseCode")] AssignFaculty assignFaculty)
        {
            if (id != assignFaculty.classId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignFaculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignFacultyExists(assignFaculty.classId))
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
            ViewData["courseCode"] = new SelectList(_context.Courses, "courseCode", "courseCode", assignFaculty.courseCode);
            ViewData["facultyId"] = new SelectList(_context.Faculties, "facultyId", "facultyId", assignFaculty.facultyId);
            return View(assignFaculty);
        }

        // GET: AssignFaculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignFaculty = await _context.AssignFaculties
                .Include(a => a.Course)
                .Include(a => a.Faculty)
                .FirstOrDefaultAsync(m => m.classId == id);
            if (assignFaculty == null)
            {
                return NotFound();
            }

            return View(assignFaculty);
        }

        // POST: AssignFaculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignFaculty = await _context.AssignFaculties.FindAsync(id);
            _context.AssignFaculties.Remove(assignFaculty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignFacultyExists(int id)
        {
            return _context.AssignFaculties.Any(e => e.classId == id);
        }
    }
}
