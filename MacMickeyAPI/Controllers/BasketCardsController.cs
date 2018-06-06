using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MacMickey.Dal;
using MacMickey.DomainModel;

namespace MacMickeyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BasketCards")]
    public class BasketCardsController : Controller
    {
        private readonly MacContext _context;

        public BasketCardsController(MacContext context)
        {
            _context = context;
        }

        // GET: api/BasketCards
        [HttpGet]
        public IEnumerable<BasketCard> GetBasketCards()
        {
            return _context.BasketCards;
        }

        // GET: api/BasketCards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketCard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketCard = await _context.BasketCards.SingleOrDefaultAsync(m => m.BasketCardId == id);

            if (basketCard == null)
            {
                return NotFound();
            }

            return Ok(basketCard);
        }

        // PUT: api/BasketCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketCard([FromRoute] string id, [FromBody] BasketCard basketCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basketCard.BasketCardId)
            {
                return BadRequest();
            }

            _context.Entry(basketCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BasketCards
        [HttpPost]
        public async Task<IActionResult> PostBasketCard([FromBody] BasketCard basketCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BasketCards.Add(basketCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketCard", new { id = basketCard.BasketCardId }, basketCard);
        }

        // DELETE: api/BasketCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketCard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketCard = await _context.BasketCards.SingleOrDefaultAsync(m => m.BasketCardId == id);
            if (basketCard == null)
            {
                return NotFound();
            }

            _context.BasketCards.Remove(basketCard);
            await _context.SaveChangesAsync();

            return Ok(basketCard);
        }

        private bool BasketCardExists(string id)
        {
            return _context.BasketCards.Any(e => e.BasketCardId == id);
        }
    }
}