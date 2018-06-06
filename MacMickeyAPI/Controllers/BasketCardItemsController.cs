using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MacMickey.Dal;
using MacMickey.DomainModel.ModelOrder;

namespace MacMickeyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BasketCardItems")]
    public class BasketCardItemsController : Controller
    {
        private readonly MacContext _context;

        public BasketCardItemsController(MacContext context)
        {
            _context = context;
        }

        // GET: api/BasketCardItems
        [HttpGet]
        public IEnumerable<BasketCardItem> GetBasketCardsItem()
        {
            return _context.BasketCardsItem;
        }

        // GET: api/BasketCardItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketCardItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketCardItem = await _context.BasketCardsItem.SingleOrDefaultAsync(m => m.BasketCardItemID == id);

            if (basketCardItem == null)
            {
                return NotFound();
            }

            return Ok(basketCardItem);
        }

        // PUT: api/BasketCardItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketCardItem([FromRoute] int id, [FromBody] BasketCardItem basketCardItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basketCardItem.BasketCardItemID)
            {
                return BadRequest();
            }

            _context.Entry(basketCardItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketCardItemExists(id))
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

        // POST: api/BasketCardItems
        [HttpPost]
        public async Task<IActionResult> PostBasketCardItem([FromBody] BasketCardItem basketCardItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BasketCardsItem.Add(basketCardItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketCardItem", new { id = basketCardItem.BasketCardItemID }, basketCardItem);
        }

        // DELETE: api/BasketCardItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketCardItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basketCardItem = await _context.BasketCardsItem.SingleOrDefaultAsync(m => m.BasketCardItemID == id);
            if (basketCardItem == null)
            {
                return NotFound();
            }

            _context.BasketCardsItem.Remove(basketCardItem);
            await _context.SaveChangesAsync();

            return Ok(basketCardItem);
        }

        private bool BasketCardItemExists(int id)
        {
            return _context.BasketCardsItem.Any(e => e.BasketCardItemID == id);
        }
    }
}