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
    public class HolidayAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public HolidayAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/HolidayAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayMaster>>> GetHolidayMaster()
        {
            return await _context.HolidayMaster.ToListAsync();
        }

        // GET: api/HolidayAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayMaster>> GetHolidayMaster(int id)
        {
            var holidayMaster = await _context.HolidayMaster.FindAsync(id);

            if (holidayMaster == null)
            {
                return NotFound();
            }

            return holidayMaster;
        }

        // PUT: api/HolidayAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayMaster(int id, HolidayMaster holidayMaster)
        {
            if (id != holidayMaster.HolidayId)
            {
                return BadRequest();
            }

            _context.Entry(holidayMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayMasterExists(id))
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

        // POST: api/HolidayAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HolidayMaster>> PostHolidayMaster(HolidayMaster holidayMaster)
        {
            _context.HolidayMaster.Add(holidayMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolidayMaster", new { id = holidayMaster.HolidayId }, holidayMaster);
        }

        // DELETE: api/HolidayAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HolidayMaster>> DeleteHolidayMaster(int id)
        {
            var holidayMaster = await _context.HolidayMaster.FindAsync(id);
            if (holidayMaster == null)
            {
                return NotFound();
            }

            _context.HolidayMaster.Remove(holidayMaster);
            await _context.SaveChangesAsync();

            return holidayMaster;
        }

        private bool HolidayMasterExists(int id)
        {
            return _context.HolidayMaster.Any(e => e.HolidayId == id);
        }
    }
}
