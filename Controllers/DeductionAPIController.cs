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
    public class DeductionAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public DeductionAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/DeductionAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeductionMaster>>> GetDeductionMaster()
        {
            return await _context.DeductionMaster.ToListAsync();
        }

        // GET: api/DeductionAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionMaster>> GetDeductionMaster(int id)
        {
            var deductionMaster = await _context.DeductionMaster.FindAsync(id);

            if (deductionMaster == null)
            {
                return NotFound();
            }

            return deductionMaster;
        }

        // PUT: api/DeductionAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeductionMaster(int id, DeductionMaster deductionMaster)
        {
            if (id != deductionMaster.DeductionId)
            {
                return BadRequest();
            }

            _context.Entry(deductionMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeductionMasterExists(id))
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

        // POST: api/DeductionAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeductionMaster>> PostDeductionMaster(DeductionMaster deductionMaster)
        {
            _context.DeductionMaster.Add(deductionMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeductionMaster", new { id = deductionMaster.DeductionId }, deductionMaster);
        }

        // DELETE: api/DeductionAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeductionMaster>> DeleteDeductionMaster(int id)
        {
            var deductionMaster = await _context.DeductionMaster.FindAsync(id);
            if (deductionMaster == null)
            {
                return NotFound();
            }

            _context.DeductionMaster.Remove(deductionMaster);
            await _context.SaveChangesAsync();

            return deductionMaster;
        }

        private bool DeductionMasterExists(int id)
        {
            return _context.DeductionMaster.Any(e => e.DeductionId == id);
        }
    }
}
