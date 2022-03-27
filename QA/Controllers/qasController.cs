using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QA.Data;
using QA.Models;

namespace QA.Controllers
{
   
    public class qasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public qasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: qas
        public async Task<IActionResult> Index()
        {
            return View(await _context.qa.ToListAsync());
        }

        // GET: qas/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View("ShowSearchForm");
        }
        // Post: qas/ShowSearchForm
        public async Task<IActionResult> ShowSearchResults(String SearchPharse)
        {
           return View("Index", await _context.qa.Where(q => q.Question.Contains(SearchPharse)).ToListAsync());
        }

        // GET: qas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qa = await _context.qa
                .FirstOrDefaultAsync(m => m.qaId == id);
            if (qa == null)
            {
                return NotFound();
            }

            return View(qa);
        }

        // GET: qas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: qas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("qaId,Question,Answer")] qa qa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qa);
        }

        // GET: qas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qa = await _context.qa.FindAsync(id);
            if (qa == null)
            {
                return NotFound();
            }
            return View(qa);
        }

        // POST: qas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("qaId,Question,Answer")] qa qa)
        {
            if (id != qa.qaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!qaExists(qa.qaId))
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
            return View(qa);
        }
        [Authorize]
        // GET: qas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qa = await _context.qa
                .FirstOrDefaultAsync(m => m.qaId == id);
            if (qa == null)
            {
                return NotFound();
            }

            return View(qa);
        }

        [Authorize]
        // POST: qas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qa = await _context.qa.FindAsync(id);
            _context.qa.Remove(qa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool qaExists(int id)
        {
            return _context.qa.Any(e => e.qaId == id);
        }
    }
}
