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
    public class BasketCardsController : Controller
    {
        private readonly MacContext _context;

        public BasketCardsController(MacContext context)
        {
            _context = context;
        }

        // GET: BasketCards
        public async Task<IActionResult> Index()
        {
            var macContext = _context.BasketCards.Include(b => b.Product);
            return View(await macContext.ToListAsync());
        }

        // GET: BasketCards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketCard = await _context.BasketCards
                .Include(b => b.Product)
                .SingleOrDefaultAsync(m => m.BasketCardId == id);
            if (basketCard == null)
            {
                return NotFound();
            }

            return View(basketCard);
        }

        // GET: BasketCards/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Discriminator");
            return View();
        }

        // POST: BasketCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasketCardId,CardId,Quantity,DateCreated,ProductId")] BasketCards basketCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basketCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Discriminator", basketCard.ProductId);
            return View(basketCard);
        }

        // GET: BasketCards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketCard = await _context.BasketCards.SingleOrDefaultAsync(m => m.BasketCardId == id);
            if (basketCard == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Discriminator", basketCard.ProductId);
            return View(basketCard);
        }

        // POST: BasketCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BasketCardId,CardId,Quantity,DateCreated,ProductId")] BasketCards basketCard)
        {
            if (id != basketCard.BasketCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basketCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketCardExists(basketCard.BasketCardId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductID", "Discriminator", basketCard.ProductId);
            return View(basketCard);
        }

        // GET: BasketCards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketCard = await _context.BasketCards
                .Include(b => b.Product)
                .SingleOrDefaultAsync(m => m.BasketCardId == id);
            if (basketCard == null)
            {
                return NotFound();
            }

            return View(basketCard);
        }

        // POST: BasketCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var basketCard = await _context.BasketCards.SingleOrDefaultAsync(m => m.BasketCardId == id);
            _context.BasketCards.Remove(basketCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketCardExists(string id)
        {
            return _context.BasketCards.Any(e => e.BasketCardId == id);
        }
    }
}
