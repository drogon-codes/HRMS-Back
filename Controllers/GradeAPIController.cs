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
    public class GradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public GradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/GradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeMaster>>> GetGradeMaster()
        {
            return await _context.GradeMaster.ToListAsync();
        }

        // GET: api/GradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeMaster>> GetGradeMaster(int id)
        {
            var gradeMaster = await _context.GradeMaster.FindAsync(id);

            if (gradeMaster == null)
            {
                return NotFound();
            }

            return gradeMaster;
        }

        // PUT: api/GradeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeMaster(int id, GradeMaster gradeMaster)
        {
            if (id != gradeMaster.GradeId)
            {
                return BadRequest();
            }

            _context.Entry(gradeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeMasterExists(id))
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

        // POST: api/GradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GradeMaster>> PostGradeMaster(GradeMaster gradeMaster)
        {
            _context.GradeMaster.Add(gradeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradeMaster", new { id = gradeMaster.GradeId }, gradeMaster);
        }

        // DELETE: api/GradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradeMaster>> DeleteGradeMaster(int id)
        {
            var gradeMaster = await _context.GradeMaster.FindAsync(id);
            if (gradeMaster == null)
            {
                return NotFound();
            }

            _context.GradeMaster.Remove(gradeMaster);
            await _context.SaveChangesAsync();

            return gradeMaster;
        }

        private bool GradeMasterExists(int id)
        {
            return _context.GradeMaster.Any(e => e.GradeId == id);
        }
    }
}
