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
    public class BakersController : Controller
    {
        private readonly MacContext _context;

        public BakersController(MacContext context)
        {
            _context = context;
        }

        // GET: Bakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bakers.ToListAsync());
        }

        // GET: Bakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baker = await _context.Bakers
                .SingleOrDefaultAsync(m => m.BakerId == id);
            if (baker == null)
            {
                return NotFound();
            }

            return View(baker);
        }

        // GET: Bakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BakerId,Name")] Baker baker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baker);
        }

        // GET: Bakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baker = await _context.Bakers.SingleOrDefaultAsync(m => m.BakerId == id);
            if (baker == null)
            {
                return NotFound();
            }
            return View(baker);
        }

        // POST: Bakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BakerId,Name")] Baker baker)
        {
            if (id != baker.BakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakerExists(baker.BakerId))
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
            return View(baker);
        }

        // GET: Bakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baker = await _context.Bakers
                .SingleOrDefaultAsync(m => m.BakerId == id);
            if (baker == null)
            {
                return NotFound();
            }

            return View(baker);
        }

        // POST: Bakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baker = await _context.Bakers.SingleOrDefaultAsync(m => m.BakerId == id);
            _context.Bakers.Remove(baker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BakerExists(int id)
        {
            return _context.Bakers.Any(e => e.BakerId == id);
        }
    }
}
