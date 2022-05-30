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
    public class DesignationGradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public DesignationGradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/DesignationGradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationGrade>>> GetDesignationGrade()
        {
            return await _context.DesignationGrade.ToListAsync();
        }

        // GET: api/DesignationGradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationGrade>> GetDesignationGrade(int id)
        {
            var designationGrade = await _context.DesignationGrade.FindAsync(id);

            if (designationGrade == null)
            {
                return NotFound();
            }

            return designationGrade;
        }

        // PUT: api/DesignationGradeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignationGrade(int id, DesignationGrade designationGrade)
        {
            if (id != designationGrade.DesignationGradeId)
            {
                return BadRequest();
            }

            _context.Entry(designationGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationGradeExists(id))
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

        // POST: api/DesignationGradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DesignationGrade>> PostDesignationGrade(DesignationGrade designationGrade)
        {
            _context.DesignationGrade.Add(designationGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignationGrade", new { id = designationGrade.DesignationGradeId }, designationGrade);
        }

        // DELETE: api/DesignationGradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DesignationGrade>> DeleteDesignationGrade(int id)
        {
            var designationGrade = await _context.DesignationGrade.FindAsync(id);
            if (designationGrade == null)
            {
                return NotFound();
            }

            _context.DesignationGrade.Remove(designationGrade);
            await _context.SaveChangesAsync();

            return designationGrade;
        }

        private bool DesignationGradeExists(int id)
        {
            return _context.DesignationGrade.Any(e => e.DesignationGradeId == id);
        }
    }
}
