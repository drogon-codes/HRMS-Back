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
    public class EmployeeGradeAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public EmployeeGradeAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeGradeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeGrade>>> GetEmployeeGrade()
        {
            return await _context.EmployeeGrade.ToListAsync();
        }

        // GET: api/EmployeeGradeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGrade>> GetEmployeeGrade(int id)
        {
            var employeeGrade = await _context.EmployeeGrade.FindAsync(id);

            if (employeeGrade == null)
            {
                return NotFound();
            }

            return employeeGrade;
        }

        // PUT: api/EmployeeGradeAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeGrade(int id, EmployeeGrade employeeGrade)
        {
            if (id != employeeGrade.EmployeeGradeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeGradeExists(id))
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

        // POST: api/EmployeeGradeAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeGrade>> PostEmployeeGrade(EmployeeGrade employeeGrade)
        {
            _context.EmployeeGrade.Add(employeeGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeGrade", new { id = employeeGrade.EmployeeGradeId }, employeeGrade);
        }

        // DELETE: api/EmployeeGradeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeGrade>> DeleteEmployeeGrade(int id)
        {
            var employeeGrade = await _context.EmployeeGrade.FindAsync(id);
            if (employeeGrade == null)
            {
                return NotFound();
            }

            _context.EmployeeGrade.Remove(employeeGrade);
            await _context.SaveChangesAsync();

            return employeeGrade;
        }

        private bool EmployeeGradeExists(int id)
        {
            return _context.EmployeeGrade.Any(e => e.EmployeeGradeId == id);
        }
    }
}
