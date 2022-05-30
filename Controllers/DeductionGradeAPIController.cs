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
    public class DeductionGradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public DeductionGradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/DeductionGradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeductionGrade>>> GetDeductionGrade()
        {
            return await _context.DeductionGrade.ToListAsync();
        }

        // GET: api/DeductionGradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionGrade>> GetDeductionGrade(int id)
        {
            var deductionGrade = await _context.DeductionGrade.FindAsync(id);

            if (deductionGrade == null)
            {
                return NotFound();
            }

            return deductionGrade;
        }

        // PUT: api/DeductionGradeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeductionGrade(int id, DeductionGrade deductionGrade)
        {
            if (id != deductionGrade.DeductionGradeId)
            {
                return BadRequest();
            }

            _context.Entry(deductionGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeductionGradeExists(id))
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

        // POST: api/DeductionGradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeductionGrade>> PostDeductionGrade(DeductionGrade deductionGrade)
        {
            _context.DeductionGrade.Add(deductionGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeductionGrade", new { id = deductionGrade.DeductionGradeId }, deductionGrade);
        }

        // DELETE: api/DeductionGradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeductionGrade>> DeleteDeductionGrade(int id)
        {
            var deductionGrade = await _context.DeductionGrade.FindAsync(id);
            if (deductionGrade == null)
            {
                return NotFound();
            }

            _context.DeductionGrade.Remove(deductionGrade);
            await _context.SaveChangesAsync();

            return deductionGrade;
        }

        private bool DeductionGradeExists(int id)
        {
            return _context.DeductionGrade.Any(e => e.DeductionGradeId == id);
        }
    }
}
