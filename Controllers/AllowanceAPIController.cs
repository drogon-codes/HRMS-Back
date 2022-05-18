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
    public class AllowanceAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public AllowanceAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/AllowanceAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllowanceMaster>>> GetAllowanceMaster()
        {
            return await _context.AllowanceMaster.ToListAsync();
        }

        // GET: api/AllowanceAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllowanceMaster>> GetAllowanceMaster(int id)
        {
            var allowanceMaster = await _context.AllowanceMaster.FindAsync(id);

            if (allowanceMaster == null)
            {
                return NotFound();
            }

            return allowanceMaster;
        }

        // PUT: api/AllowanceAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowanceMaster(int id, AllowanceMaster allowanceMaster)
        {
            if (id != allowanceMaster.AllowanceId)
            {
                return BadRequest();
            }

            _context.Entry(allowanceMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowanceMasterExists(id))
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

        // POST: api/AllowanceAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AllowanceMaster>> PostAllowanceMaster(AllowanceMaster allowanceMaster)
        {
            _context.AllowanceMaster.Add(allowanceMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllowanceMaster", new { id = allowanceMaster.AllowanceId }, allowanceMaster);
        }

        // DELETE: api/AllowanceAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllowanceMaster>> DeleteAllowanceMaster(int id)
        {
            var allowanceMaster = await _context.AllowanceMaster.FindAsync(id);
            if (allowanceMaster == null)
            {
                return NotFound();
            }

            _context.AllowanceMaster.Remove(allowanceMaster);
            await _context.SaveChangesAsync();

            return allowanceMaster;
        }

        private bool AllowanceMasterExists(int id)
        {
            return _context.AllowanceMaster.Any(e => e.AllowanceId == id);
        }
    }
}
