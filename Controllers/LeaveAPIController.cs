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
    public class LeaveAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public LeaveAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/LeaveAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveMaster>>> GetLeaveMaster()
        {
            return await _context.LeaveMaster.ToListAsync();
        }

        // GET: api/LeaveAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveMaster>> GetLeaveMaster(int id)
        {
            var leaveMaster = await _context.LeaveMaster.FindAsync(id);

            if (leaveMaster == null)
            {
                return NotFound();
            }

            return leaveMaster;
        }

        // PUT: api/LeaveAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveMaster(int id, LeaveMaster leaveMaster)
        {
            if (id != leaveMaster.LeaveId)
            {
                return BadRequest();
            }

            _context.Entry(leaveMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveMasterExists(id))
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

        // POST: api/LeaveAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeaveMaster>> PostLeaveMaster(LeaveMaster leaveMaster)
        {
            _context.LeaveMaster.Add(leaveMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveMaster", new { id = leaveMaster.LeaveId }, leaveMaster);
        }

        // DELETE: api/LeaveAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveMaster>> DeleteLeaveMaster(int id)
        {
            var leaveMaster = await _context.LeaveMaster.FindAsync(id);
            if (leaveMaster == null)
            {
                return NotFound();
            }

            _context.LeaveMaster.Remove(leaveMaster);
            await _context.SaveChangesAsync();

            return leaveMaster;
        }

        private bool LeaveMasterExists(int id)
        {
            return _context.LeaveMaster.Any(e => e.LeaveId == id);
        }
    }
}
