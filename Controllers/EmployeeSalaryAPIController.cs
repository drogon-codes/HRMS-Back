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
    public class EmployeeSalaryAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public EmployeeSalaryAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSalaryAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSalary>>> GetEmployeeSalary()
        {
            return await _context.EmployeeSalary.ToListAsync();
        }

        // GET: api/EmployeeSalaryAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSalary>> GetEmployeeSalary(int id)
        {
            var employeeSalary = await _context.EmployeeSalary.FindAsync(id);

            if (employeeSalary == null)
            {
                return NotFound();
            }

            return employeeSalary;
        }

        // PUT: api/EmployeeSalaryAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSalary(int id, EmployeeSalary employeeSalary)
        {
            if (id != employeeSalary.SalaryId)
            {
                return BadRequest();
            }

            _context.Entry(employeeSalary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeSalaryExists(id))
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

        // POST: api/EmployeeSalaryAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeSalary>> PostEmployeeSalary(EmployeeSalary employeeSalary)
        {
            _context.EmployeeSalary.Add(employeeSalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSalary", new { id = employeeSalary.SalaryId }, employeeSalary);
        }

        // DELETE: api/EmployeeSalaryAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSalary>> DeleteEmployeeSalary(int id)
        {
            var employeeSalary = await _context.EmployeeSalary.FindAsync(id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            _context.EmployeeSalary.Remove(employeeSalary);
            await _context.SaveChangesAsync();

            return employeeSalary;
        }

        private bool EmployeeSalaryExists(int id)
        {
            return _context.EmployeeSalary.Any(e => e.SalaryId == id);
        }
    }
}
