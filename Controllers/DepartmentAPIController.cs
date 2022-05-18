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
    public class DepartmentAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public DepartmentAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentMaster>>> GetDepartmentMaster()
        {
            return await _context.DepartmentMaster.ToListAsync();
        }

        // GET: api/DepartmentAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentMaster>> GetDepartmentMaster(int id)
        {
            var departmentMaster = await _context.DepartmentMaster.FindAsync(id);

            if (departmentMaster == null)
            {
                return NotFound();
            }

            return departmentMaster;
        }

        // PUT: api/DepartmentAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentMaster(int id, DepartmentMaster departmentMaster)
        {
            if (id != departmentMaster.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(departmentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentMasterExists(id))
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

        // POST: api/DepartmentAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DepartmentMaster>> PostDepartmentMaster(DepartmentMaster departmentMaster)
        {
            _context.DepartmentMaster.Add(departmentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentMaster", new { id = departmentMaster.DepartmentId }, departmentMaster);
        }

        // DELETE: api/DepartmentAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentMaster>> DeleteDepartmentMaster(int id)
        {
            var departmentMaster = await _context.DepartmentMaster.FindAsync(id);
            if (departmentMaster == null)
            {
                return NotFound();
            }

            _context.DepartmentMaster.Remove(departmentMaster);
            await _context.SaveChangesAsync();

            return departmentMaster;
        }

        private bool DepartmentMasterExists(int id)
        {
            return _context.DepartmentMaster.Any(e => e.DepartmentId == id);
        }
    }
}
