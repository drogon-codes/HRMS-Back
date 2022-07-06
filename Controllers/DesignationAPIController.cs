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
    public class DesignationAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public DesignationAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/DesignationAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationDepartment>>> GetDesignationMaster()
        {
            List<DesignationDepartment> des = null;
            des = await (from ds in _context.DesignationMaster
                         join dp in _context.DepartmentMaster
                         on ds.DepartmentId equals dp.DepartmentId
                         select new DesignationDepartment 
                         {
                             DesignationId = ds.DesignationId,
                             DesignationName = ds.DesignationName,
                             DepartmentId = ds.DepartmentId,
                             DepartmentName = dp.DepartmentName
                         }
                         ).ToListAsync<DesignationDepartment>();
            return des;
        }

        // GET: api/DesignationAPI
        [HttpGet]
        [Route("{GetDesignationByDepartment}/{DeptId}")]
        public async Task<ActionResult<IEnumerable<DesignationDepartment>>> GetDesignationByDepartment(int deptId)
        {
            List<DesignationDepartment> des = null;
            des = await (from ds in _context.DesignationMaster
                         join dp in _context.DepartmentMaster
                         on ds.DepartmentId equals dp.DepartmentId
                         where ds.DepartmentId == deptId
                         select new DesignationDepartment
                         {
                             DesignationId = ds.DesignationId,
                             DesignationName = ds.DesignationName,
                             DepartmentId = ds.DepartmentId,
                             DepartmentName = dp.DepartmentName
                         }
                         ).ToListAsync<DesignationDepartment>();
            return des;
        }

        // GET: api/DesignationAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationMaster>> GetDesignationMaster(int id)
        {
            var designationMaster = await _context.DesignationMaster.FindAsync(id);

            if (designationMaster == null)
            {
                return NotFound();
            }

            return designationMaster;
        }

        // PUT: api/DesignationAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignationMaster(int id, DesignationMaster designationMaster)
        {
            if (id != designationMaster.DesignationId)
            {
                return BadRequest();
            }

            _context.Entry(designationMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationMasterExists(id))
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

        // POST: api/DesignationAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DesignationMaster>> PostDesignationMaster(DesignationMaster designationMaster)
        {
            _context.DesignationMaster.Add(designationMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignationMaster", new { id = designationMaster.DesignationId }, designationMaster);
        }

        // DELETE: api/DesignationAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DesignationMaster>> DeleteDesignationMaster(int id)
        {
            var designationMaster = await _context.DesignationMaster.FindAsync(id);
            if (designationMaster == null)
            {
                return NotFound();
            }

            _context.DesignationMaster.Remove(designationMaster);
            await _context.SaveChangesAsync();

            return designationMaster;
        }

        private bool DesignationMasterExists(int id)
        {
            return _context.DesignationMaster.Any(e => e.DesignationId == id);
        }
    }
}
