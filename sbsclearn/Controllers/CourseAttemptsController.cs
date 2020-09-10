using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sbsclearn.Data;
using sbsclearn.Models.Entities;

namespace sbsclearn.Controllers
{
    public class CourseAttemptsController : Controller
    {
        private readonly sbsclearnDbContext _context;

        public CourseAttemptsController(sbsclearnDbContext context)
        {
            _context = context;
        }

        // GET: CourseAttempts
        public async Task<IActionResult> Index()
        {
            var sbsclearnDbContext = _context.CourseAttempt.Include(c => c.Course).Include(c => c.User);
            return View(await sbsclearnDbContext.ToListAsync());
        }

        // GET: CourseAttempts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAttempt = await _context.CourseAttempt
                .Include(c => c.Course)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CourseAttemptId == id);
            if (courseAttempt == null)
            {
                return NotFound();
            }

            return View(courseAttempt);
        }

        // GET: CourseAttempts/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserID");
            return View();
        }

        // POST: CourseAttempts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseAttemptId,UserId,CourseId")] CourseAttempt courseAttempt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseAttempt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", courseAttempt.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserID", courseAttempt.UserId);
            return View(courseAttempt);
        }

        // GET: CourseAttempts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAttempt = await _context.CourseAttempt.FindAsync(id);
            if (courseAttempt == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", courseAttempt.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserID", courseAttempt.UserId);
            return View(courseAttempt);
        }

        // POST: CourseAttempts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseAttemptId,UserId,CourseId")] CourseAttempt courseAttempt)
        {
            if (id != courseAttempt.CourseAttemptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseAttempt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseAttemptExists(courseAttempt.CourseAttemptId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", courseAttempt.CourseId);
            ViewData["UserId"] = new SelectList(_context.User, "UserID", "UserID", courseAttempt.UserId);
            return View(courseAttempt);
        }

        // GET: CourseAttempts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAttempt = await _context.CourseAttempt
                .Include(c => c.Course)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CourseAttemptId == id);
            if (courseAttempt == null)
            {
                return NotFound();
            }

            return View(courseAttempt);
        }

        // POST: CourseAttempts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseAttempt = await _context.CourseAttempt.FindAsync(id);
            _context.CourseAttempt.Remove(courseAttempt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseAttemptExists(int id)
        {
            return _context.CourseAttempt.Any(e => e.CourseAttemptId == id);
        }
    }
}
