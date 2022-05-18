using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSCoreWebApp.Models;

namespace HRMSCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public PromotionAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/PromotionAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionMaster>>> GetPromotionMaster()
        {
            return await _context.PromotionMaster.ToListAsync();
        }

        // GET: api/PromotionAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionMaster>> GetPromotionMaster(int id)
        {
            var promotionMaster = await _context.PromotionMaster.FindAsync(id);

            if (promotionMaster == null)
            {
                return NotFound();
            }

            return promotionMaster;
        }

        // PUT: api/PromotionAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionMaster(int id, PromotionMaster promotionMaster)
        {
            if (id != promotionMaster.PromotionId)
            {
                return BadRequest();
            }

            _context.Entry(promotionMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionMasterExists(id))
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

        // POST: api/PromotionAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PromotionMaster>> PostPromotionMaster(PromotionMaster promotionMaster)
        {
            _context.PromotionMaster.Add(promotionMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotionMaster", new { id = promotionMaster.PromotionId }, promotionMaster);
        }

        // DELETE: api/PromotionAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PromotionMaster>> DeletePromotionMaster(int id)
        {
            var promotionMaster = await _context.PromotionMaster.FindAsync(id);
            if (promotionMaster == null)
            {
                return NotFound();
            }

            _context.PromotionMaster.Remove(promotionMaster);
            await _context.SaveChangesAsync();

            return promotionMaster;
        }

        private bool PromotionMasterExists(int id)
        {
            return _context.PromotionMaster.Any(e => e.PromotionId == id);
        }
    }
}
