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
    public class SalaryPaymentAPIController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public SalaryPaymentAPIController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/SalaryPaymentAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryPayment>>> GetSalaryPayment()
        {
            return await _context.SalaryPayment.ToListAsync();
        }

        // GET: api/SalaryPaymentAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryPayment>> GetSalaryPayment(int id)
        {
            var salaryPayment = await _context.SalaryPayment.FindAsync(id);

            if (salaryPayment == null)
            {
                return NotFound();
            }

            return salaryPayment;
        }

        // PUT: api/SalaryPaymentAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryPayment(int id, SalaryPayment salaryPayment)
        {
            if (id != salaryPayment.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(salaryPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryPaymentExists(id))
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

        // POST: api/SalaryPaymentAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalaryPayment>> PostSalaryPayment(SalaryPayment salaryPayment)
        {
            _context.SalaryPayment.Add(salaryPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryPayment", new { id = salaryPayment.TransactionId }, salaryPayment);
        }

        // DELETE: api/SalaryPaymentAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaryPayment>> DeleteSalaryPayment(int id)
        {
            var salaryPayment = await _context.SalaryPayment.FindAsync(id);
            if (salaryPayment == null)
            {
                return NotFound();
            }

            _context.SalaryPayment.Remove(salaryPayment);
            await _context.SaveChangesAsync();

            return salaryPayment;
        }

        private bool SalaryPaymentExists(int id)
        {
            return _context.SalaryPayment.Any(e => e.TransactionId == id);
        }
    }
}
