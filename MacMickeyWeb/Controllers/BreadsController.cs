using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MacMickey.Dal;
using MacMickey.DomainModel;

namespace MacMickeyWeb.Controllers
{
    public class BreadsController : Controller
    {
        private readonly MacContext _context;

        public BreadsController(MacContext context)
        {
            _context = context;
        }

        // GET: Breads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Breads.ToListAsync());
        }

        // GET: Breads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bread = await _context.Breads
                .SingleOrDefaultAsync(m => m.BreadId == id);
            if (bread == null)
            {
                return NotFound();
            }

            return View(bread);
        }

        // GET: Breads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreadId,Name,HasSesameSeed")] Bread bread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bread);
        }

        // GET: Breads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bread = await _context.Breads.SingleOrDefaultAsync(m => m.BreadId == id);
            if (bread == null)
            {
                return NotFound();
            }
            return View(bread);
        }

        // POST: Breads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreadId,Name,HasSesameSeed")] Bread bread)
        {
            if (id != bread.BreadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreadExists(bread.BreadId))
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
            return View(bread);
        }

        // GET: Breads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bread = await _context.Breads
                .SingleOrDefaultAsync(m => m.BreadId == id);
            if (bread == null)
            {
                return NotFound();
            }

            return View(bread);
        }

        // POST: Breads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bread = await _context.Breads.SingleOrDefaultAsync(m => m.BreadId == id);
            _context.Breads.Remove(bread);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreadExists(int id)
        {
            return _context.Breads.Any(e => e.BreadId == id);
        }
    }
}
