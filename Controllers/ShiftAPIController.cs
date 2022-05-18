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
    public class ShiftAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public ShiftAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/ShiftAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftMaster>>> GetShiftMaster()
        {
            return await _context.ShiftMaster.ToListAsync();
        }

        // GET: api/ShiftAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftMaster>> GetShiftMaster(int id)
        {
            var shiftMaster = await _context.ShiftMaster.FindAsync(id);

            if (shiftMaster == null)
            {
                return NotFound();
            }

            return shiftMaster;
        }

        // PUT: api/ShiftAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftMaster(int id, ShiftMaster shiftMaster)
        {
            if (id != shiftMaster.ShiftId)
            {
                return BadRequest();
            }

            _context.Entry(shiftMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftMasterExists(id))
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

        // POST: api/ShiftAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShiftMaster>> PostShiftMaster(ShiftMaster shiftMaster)
        {
            _context.ShiftMaster.Add(shiftMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShiftMaster", new { id = shiftMaster.ShiftId }, shiftMaster);
        }

        // DELETE: api/ShiftAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftMaster>> DeleteShiftMaster(int id)
        {
            var shiftMaster = await _context.ShiftMaster.FindAsync(id);
            if (shiftMaster == null)
            {
                return NotFound();
            }

            _context.ShiftMaster.Remove(shiftMaster);
            await _context.SaveChangesAsync();

            return shiftMaster;
        }

        private bool ShiftMasterExists(int id)
        {
            return _context.ShiftMaster.Any(e => e.ShiftId == id);
        }
    }
}
