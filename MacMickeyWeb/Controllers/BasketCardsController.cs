using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MacMickey.Dal;
using MacMickey.DomainModel;
using Microsoft.AspNetCore.Identity;
using MacMickeyWeb.ViewModels;
using MacMickeyWeb.Services;

namespace MacMickeyWeb.Controllers
{
    public class BasketCardsController : Controller
    {
        private readonly MacContext _context;
        //private readonly IBasketCardsService _cartService;

        //public BasketCardsController(UserManager<ApplicationUser> userManager, IBasketCardsService cartService, MacContext context)
        //{
        //    _cartService = cartService;
        //    _context = context;
        //}

        public BasketCardsController(MacContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddToCart([FromBody] AddToBasketCardModel model)
        //{
        //    //var currentUser = await _context.GetCurrentUser();
        //    //await _cartService.AddToCart(currentUser.Id, model.ProductId, model.Quantity);

        //    //return RedirectToAction("AddToCartResult", new { productId = model.ProductId });
        //}

        //[HttpGet]
        //public async Task<IActionResult> AddToBasketCardResult(long productId)
        //{
        //    //var currentUser = await _context.GetCurrentUser();
        //    //var cart = await _cartService.GetCart(currentUser.Id);

        //    //var model = new AddToBasketCardResult
        //    //{
        //    //    CartItemCount = cart.Items.Count,
        //    //    CartAmount = cart.SubTotal
        //    //};

        //    //var addedProduct = cart.Items.First(x => x.ProductId == productId);
        //    //model.ProductName = addedProduct.ProductName;
        //    //model.ProductPrice = addedProduct.ProductPrice;
        //    //model.Quantity = addedProduct.Quantity;

        //    //return PartialView(model);
        //}

        // GET: BasketCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasketCards.ToListAsync());
        }

        // GET: BasketCards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketCard = await _context.BasketCards
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
            return View();
        }

        // POST: BasketCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasketCardId,CreatedOn,IsActive,ShippingAmount")] BasketCard basketCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basketCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(basketCard);
        }

        // POST: BasketCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BasketCardId,CreatedOn,IsActive,ShippingAmount")] BasketCard basketCard)
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
