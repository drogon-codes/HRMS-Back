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
    public class CityAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public CityAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/CityAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityMaster>>> GetCityMaster()
        {
            return await _context.CityMaster.ToListAsync();
        }

        // GET: api/CityAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityMaster>> GetCityMaster(int id)
        {
            var cityMaster = await _context.CityMaster.FindAsync(id);

            if (cityMaster == null)
            {
                return NotFound();
            }

            return cityMaster;
        }

        // PUT: api/CityAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityMaster(int id, CityMaster cityMaster)
        {
            if (id != cityMaster.CityId)
            {
                return BadRequest();
            }

            _context.Entry(cityMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityMasterExists(id))
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

        // POST: api/CityAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CityMaster>> PostCityMaster(CityMaster cityMaster)
        {
            _context.CityMaster.Add(cityMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityMaster", new { id = cityMaster.CityId }, cityMaster);
        }

        // DELETE: api/CityAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CityMaster>> DeleteCityMaster(int id)
        {
            var cityMaster = await _context.CityMaster.FindAsync(id);
            if (cityMaster == null)
            {
                return NotFound();
            }

            _context.CityMaster.Remove(cityMaster);
            await _context.SaveChangesAsync();

            return cityMaster;
        }

        private bool CityMasterExists(int id)
        {
            return _context.CityMaster.Any(e => e.CityId == id);
        }
    }
}
